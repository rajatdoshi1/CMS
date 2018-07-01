using System.Collections.Generic;

namespace ContactMgmt.Api.Models
{
    public class FullContactInformation : BasicContactInformation
    {
        public IEnumerable<TagValue> TagValues { get; }

        public FullContactInformation()
        {
            TagValues = new List<TagValue>();
        }
    }
}