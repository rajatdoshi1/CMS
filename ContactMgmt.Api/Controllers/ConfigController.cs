using System.Web.Http;
using ContactMgmt.Api.Handlers;
using ContactMgmt.Api.Models;

namespace ContactMgmt.Api.Controllers
{
    [RoutePrefix("Config")]
    public class ConfigController : ApiController
    {
        private IConfigHandler _configHandler;
        public ConfigController(IConfigHandler configHandler)
        {
            _configHandler = configHandler;
        }

        [Route("Get")]
        [HttpGet]
        public ContactConfig Get()
        {
            return _configHandler.GetContactConfig();
        }
    }
}