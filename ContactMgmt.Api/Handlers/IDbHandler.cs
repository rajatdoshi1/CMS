using System.Linq;
using ContactMgmt.Api.Models;
using ContactMgmt.DbManager;

namespace ContactMgmt.Api.Handlers
{
    public interface IDbHandler
    {
        IQueryable<Contact> GetBasicContactInformation(string searchString);
        IQueryable<Contact> GetFullContactById(long id);
        IQueryable<TagType> GetTagTypes();
        IQueryable<Contact> FirstNameStartsWith(string searchString);
        void Save(FullContactInformation contactInformation);
        void DeleteContact(long id);
    }
}