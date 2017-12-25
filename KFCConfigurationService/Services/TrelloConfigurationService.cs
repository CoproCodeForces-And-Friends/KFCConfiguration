using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KFCConfigurationService.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KFCConfigurationService.Services
{
    public interface ITrelloConfigurationService
    {
        Task CreateWebhook(WebHookModel settings);
    }
    
    public class TrelloConfigurationService:ITrelloConfigurationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _trelloConfigurationBaseUrl;
        public TrelloConfigurationService(IOptionsSnapshot<AppSettings> settings)
        {
            _httpClient = new HttpClient();
            _trelloConfigurationBaseUrl = $"{settings.Value.JiraConfigurationServiceUrl}";
        }
        
        public async Task CreateWebhook(WebHookModel settings)
        {
            var url = API.TrelloConfiguration.CreateWebhook(_trelloConfigurationBaseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(settings), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(url, content);
        }
    }
}