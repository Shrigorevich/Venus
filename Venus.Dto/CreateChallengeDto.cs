namespace Venus.Dto;

public class CreateChallengeDto
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
}