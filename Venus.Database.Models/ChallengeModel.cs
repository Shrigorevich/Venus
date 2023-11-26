namespace Venus.Database.Models;

public class ChallengeModel
{
    public Guid Id { get; set; }
    public int Status { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Days { get; set; }
}