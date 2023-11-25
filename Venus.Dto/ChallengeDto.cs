﻿using Venus.Common;

namespace Venus.Dto;

public class ChallengeDto
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public ChallengeStatus Status { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public List<ChallengeDayDto> Days { get; set; }
}