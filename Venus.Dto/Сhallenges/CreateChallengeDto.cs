namespace Venus.Dto;

public class CreateChallengeDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
}