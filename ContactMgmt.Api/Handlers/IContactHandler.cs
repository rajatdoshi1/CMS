using System.Collections.Generic;
using ContactMgmt.Api.Models;

namespace ContactMgmt.Api.Handlers
{
    public interface IContactHandler
    {
        IEnumerable<BasicContactInformation> GetBasicContactInformation(string searchString);
        BasicContactInformation GetContactInformation(long id);
        IEnumerable<BasicContactInformation> FirstNameStartsWith(string searchString);
        void Save(FullContactInformation contactInformation);
        void DeleteContact(long id);
    }
}