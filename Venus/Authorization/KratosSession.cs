namespace Venus.Authorization;

public class KratosSession
{
    public bool Active { get; set; }
    public Identity Identity { get; set; }
}

public class Identity
{
    public string Id { get; set; }
}