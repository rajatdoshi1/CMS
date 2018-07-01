using System.Collections.Generic;
using System.Web.Http;
using ContactMgmt.Api.Handlers;
using ContactMgmt.Api.Models;

namespace ContactMgmt.Api.Controllers
{
    [RoutePrefix("Contact")]
    public class ContactController : ApiController
    {
        private IContactHandler _contactHandler;
        public ContactController(IContactHandler contactHandler)
        {
            _contactHandler = contactHandler;
        }

        [HttpGet]
        [Route("search/{searchString}")]
        public IEnumerable<BasicContactInformation> Search(string searchString)
        {
            return _contactHandler.GetBasicContactInformation(searchString);
        }

        [HttpGet]
        [Route("startsWith/{searchString}")]
        public IEnumerable<BasicContactInformation> FirstNameStartsWith(string searchString)
        {
            return _contactHandler.FirstNameStartsWith(searchString);
        }

        [HttpGet]
        [Route("get/{id}")]
        public BasicContactInformation Get(long id)
        {
            return _contactHandler.GetContactInformation(id);
        }

        [HttpPost]
        [Route("save")]
        public int Save(FullContactInformation contactInformation)
        {
            _contactHandler.Save(contactInformation);
            return 1;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public int Delete(long id)
        {
            _contactHandler.DeleteContact(id);
            return 1;
        }

    }
}