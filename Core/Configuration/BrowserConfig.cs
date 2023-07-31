namespace Core.Configuration
{
    public class BrowserConfig : IConfiguration
    {
        public string SectionName => "Browser";

        public bool Headless { get; set; }
        public string Type { get; set; }
        public int TimeOut { get; set; }

    }
}
