namespace Core.Configuration;

public class RealUserConfig : IConfiguration
{
    public string SectionName => "RealUser";

    public string RealUserEmail { get; set; }
    public string RealUserPassword { get; set; }
}

