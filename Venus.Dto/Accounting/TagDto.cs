namespace Venus.Dto.Accounting;

/// <summary>
/// Represents purchase tag info
/// </summary>
public class TagDto
{
    /// <summary>
    /// Purchase tag identifier
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Tag name
    /// </summary>
    public string Name { get; set; }
}