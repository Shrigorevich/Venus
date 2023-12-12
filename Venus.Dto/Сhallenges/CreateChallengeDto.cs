namespace Venus.Dto;

public class CreateChallengeDto
{
    /// <summary>
    /// Challenge name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Challenge description
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Date representation in ISO format
    /// </summary>
    /// <example>2023-10-05T14:48:00.000Z</example>
    public string StartDate { get; set; }
    
    /// <summary>
    /// Date representation in ISO format
    /// </summary>
    /// <example>2023-11-06T14:48:00.000Z</example>
    public string? EndDate { get; set; }
}