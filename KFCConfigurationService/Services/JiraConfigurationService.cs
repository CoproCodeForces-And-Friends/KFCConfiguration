using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using KFCConfigurationService.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KFCConfigurationService.Services
{
    public interface IJiraConfigurationService
    {
        Task CreateWebhook(WebHookModel settings);
    }
    
    public class JiraConfigurationService: IJiraConfigurationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _jiraConfigurationBaseUrl;
        public JiraConfigurationService(IOptionsSnapshot<AppSettings> settings)
        {
            _httpClient = new HttpClient();
            _jiraConfigurationBaseUrl = $"{settings.Value.JiraConfigurationServiceUrl}";

        }
        
        public async Task CreateWebhook(WebHookModel settings)
        {
            var url = API.JiraConfiguration.CreateWebhook(_jiraConfigurationBaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(settings), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(url, content);
        }
    }
}