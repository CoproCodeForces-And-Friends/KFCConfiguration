using System.Threading.Tasks;
using KFCConfigurationService.Models;
using KFCConfigurationService.Services;
using Microsoft.AspNetCore.Mvc;

namespace KFCConfigurationService.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IJiraConfigurationService _jiraConfiguration;
        private readonly ITrelloConfigurationService _trelloConfiguration;

        public ConfigurationController(IJiraConfigurationService jiraConfiguration,
            ITrelloConfigurationService trelloConfiguration)
        {
            _jiraConfiguration = jiraConfiguration;
            _trelloConfiguration = trelloConfiguration;
        }

        [HttpPost("CreateHook")]
        public async Task CreateWebhook([FromBody] ConfigurationModel model)
        {
            switch (model.ServiceName)
            {
                case "Trello":
                    await _trelloConfiguration.CreateWebhook(model.WebHookModel);
                    break;
                case "Jira":
                    await _jiraConfiguration.CreateWebhook(model.WebHookModel);
                    break;
            }
        }
    }
}