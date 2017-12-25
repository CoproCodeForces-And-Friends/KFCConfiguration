namespace KFCConfigurationService
{
    public static class API
    {
        public static class JiraConfiguration
        {
            public static string CreateWebhook(string baseUrl)
            {
                return $"{baseUrl}/api/configuration/CreateHook";
            }
        }

        public static class TrelloConfiguration
        {
            public static string CreateWebhook(string baseUrl)
            {
                return $"{baseUrl}/configuration/api/CreateHook";
            }
        }
    }
}