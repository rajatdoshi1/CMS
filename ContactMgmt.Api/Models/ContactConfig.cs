using System.Collections.Generic;

namespace ContactMgmt.Api.Models
{
    public class ContactConfig
    {
        public IEnumerable<TagConfig> TagConfig { get; set; }
    }
}