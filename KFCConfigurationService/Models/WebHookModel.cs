namespace KFCConfigurationService.Models
{
    public class WebHookModel
    {
        public string Password { get; set; }
        public string Login { get; set; }
        public string BugTrackerUrl { get; set; }
        public string WebHookName { get; set; }
        public string WebHookUrl { get; set; }
        public WebHookEventType[] Events { get; set; }
        public string JqlFilter { get; set; }
        public bool ExcludeIssueDetails { get; set; }
    }
}