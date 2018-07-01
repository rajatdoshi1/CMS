using System.Linq;
using AutoMapper;
using ContactMgmt.Api.Models;
using ContactMgmt.DbManager;

namespace ContactMgmt.Api.Handlers
{
    public class ConfigHandler : IConfigHandler
    {
        private IDbHandler _dbHandler;

        public ConfigHandler(IDbHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }

        public ContactConfig GetContactConfig()
        {
            return new ContactConfig()
            {
                TagConfig = _dbHandler.GetTagTypes()
                                .Select(Mapper.Map<TagType, TagConfig>)
            };
        }
    }
}