namespace Venus.Database.Queries;

public static class BudgetQueries
{
    public static string CreateBudget()
    {
        return @"
			WITH new_budget AS (
				INSERT INTO budget (user_id, name, amount, period, currency_id)
				VALUES (@userId, @name, @amount, @period, @currencyId) RETURNING *
			 ), budget_tags AS (
				INSERT INTO budget_tag (budget_id, tag_id)
				SELECT new_budget.id, unnest(@tagIds::int[]) FROM new_budget RETURNING *
			 ), budget_purchases AS (
 				SELECT DISTINCT ON (p.id) bt.budget_id, p.price, p.discount
				FROM purchase p
				JOIN purchase_tag pt ON pt.purchase_id = p.id
				JOIN tag t ON pt.tag_id = t.id
				JOIN budget_tags bt ON bt.tag_id = t.id
				WHERE p.user_id = @userId and p.date >= date(@start) and p.date <= date(@end)
			 ), spent_amount AS (
				SELECT bp.budget_id, SUM(bp.price - bp.discount) 
				FROM budget_purchases bp GROUP BY bp.budget_id
			 )
			SELECT nb.id, nb.name, nb.amount AS plannedAmount, sa.sum AS spentAmount, nb.period, 
				c.id AS currencyId, c.code AS currencyCode, c.name AS currencyName,
				COALESCE(
					json_agg(json_build_object(
					'id', tag.id,
					'name', tag.name)
					) FILTER (WHERE tag.id IS NOT NULL), '[]'::JSON
				) as tags
			FROM new_budget nb
			LEFT JOIN budget_tags bt ON bt.budget_id = nb.id
			LEFT JOIN tag ON tag.id = bt.tag_id
			LEFT JOIN currency c ON c.id = nb.currency_id
			LEFT JOIN spent_amount sa ON sa.budget_id = nb.id
			GROUP BY nb.id, nb.name, nb.amount, nb.period, nb.currency_id, c.id, sa.sum";
    }

    public static string UpdateBudget()
    {
	    return @"
			DELETE FROM budget_tag WHERE budget_id = @id;
			WITH updated_budget AS (
				UPDATE budget SET
				name = @name,
				amount = @amount,
				period = @period,
				currency_id = @currencyId
				WHERE id = @id RETURNING *
			 ), budget_tags AS (
				INSERT INTO budget_tag (budget_id, tag_id)
				SELECT updated_budget.id, unnest(@tagIds::int[]) FROM updated_budget RETURNING *
			 ), budget_purchases AS (
				SELECT DISTINCT ON (p.id) bt.budget_id, p.price, p.discount
				FROM purchase p
				JOIN purchase_tag pt ON pt.purchase_id = p.id
				JOIN tag t ON pt.tag_id = t.id
				JOIN budget_tags bt ON bt.tag_id = t.id
				WHERE p.user_id = @userId and p.date >= date(@start) and p.date <= date(@end)
			 ), spent_amount AS (
				SELECT bp.budget_id, SUM(bp.price - bp.discount) 
				FROM budget_purchases bp GROUP BY bp.budget_id
			 )
			SELECT ub.id, ub.name, ub.amount AS plannedAmount, sa.sum AS spentAmount, ub.period, 
				c.id AS currencyId, c.code AS currencyCode, c.name AS currencyName,
				COALESCE(
					json_agg(json_build_object(
					'id', tag.id,
					'name', tag.name)
					) FILTER (WHERE tag.id IS NOT NULL), '[]'::JSON
				) as tags
			FROM updated_budget ub
			LEFT JOIN budget_tags bt ON bt.budget_id = ub.id
			LEFT JOIN tag ON tag.id = bt.tag_id
			LEFT JOIN currency c ON c.id = ub.currency_id
			LEFT JOIN spent_amount sa ON sa.budget_id = ub.id
			GROUP BY ub.id, ub.name, ub.amount, ub.period, ub.currency_id, c.id, sa.sum";
    }
    
    public static string GetBudgets()
    {
	    return @"
			WITH budget_purchases AS (
				SELECT DISTINCT ON (p.id, bt.budget_id) bt.budget_id, p.price, p.discount 
				FROM purchase p
				JOIN purchase_tag pt on pt.purchase_id = p.id
				JOIN tag t ON pt.tag_id = t.id
				JOIN budget_tag bt ON bt.tag_id = t.id
				WHERE p.user_id = @userId
			), spent_amount AS (
				SELECT bp.budget_id, SUM(bp.price - bp.discount) 
				FROM budget_purchases bp GROUP BY bp.budget_id
			)
			SELECT b.id, b.name, b.amount AS plannedAmount, sa.sum AS spentAmount, b.period, 
					c.id AS currencyId, c.code AS currencyCode, c.name AS currencyName,
					COALESCE(
					json_agg(json_build_object(
					'id', tag.id,
					'name', tag.name)
					) FILTER (WHERE tag.id IS NOT NULL), '[]'::JSON
				) AS tags
			FROM budget b
			LEFT JOIN budget_tag bt ON bt.budget_id =  b.id
			LEFT JOIN tag ON tag.id = bt.tag_id
			LEFT JOIN currency c ON c.id = b.currency_id
			JOIN spent_amount sa ON sa.budget_id = b.id
			WHERE b.user_id = @userId
			GROUP BY b.id, sa.sum, c.id";
    }
}