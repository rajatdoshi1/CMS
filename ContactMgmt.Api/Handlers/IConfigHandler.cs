using ContactMgmt.Api.Models;

namespace ContactMgmt.Api.Handlers
{
    public interface IConfigHandler
    {
        ContactConfig GetContactConfig();
    }
}