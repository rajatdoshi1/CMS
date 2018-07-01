using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ContactMgmt.Api.Models;
using ContactMgmt.DbManager;

namespace ContactMgmt.Api.Handlers
{
    public class ContactHandler : IContactHandler
    {
        private IDbHandler _dbHandler;
        public ContactHandler(IDbHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }

        public IEnumerable<BasicContactInformation> GetBasicContactInformation(string searchString)
        {
            return _dbHandler.GetBasicContactInformation(searchString)
                                .Select(Mapper.Map<Contact, BasicContactInformation>);
        }

        public IEnumerable<BasicContactInformation> FirstNameStartsWith(string searchString)
        {
            return _dbHandler.FirstNameStartsWith(searchString)
                .Select(Mapper.Map<Contact, BasicContactInformation>);
        }

        public void Save(FullContactInformation contactInformation)
        {
            _dbHandler.Save(contactInformation);
        }

        public void DeleteContact(long id)
        {
            _dbHandler.DeleteContact(id);
        }

        public BasicContactInformation GetContactInformation(long id)
        {
            var contact = _dbHandler.GetFullContactById(id);
            if (contact.Any())
                return contact.Select(Mapper.Map<Contact, FullContactInformation>).First();
            return null;
        }
    }
}