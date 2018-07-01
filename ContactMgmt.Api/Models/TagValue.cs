namespace ContactMgmt.Api.Models
{
    public class TagValue : Tag
    {
        public string Value { get; set; }
    }

    public class Tag
    {
        public int TagTypeId { get; set; }
        public string TagName { get; set; }
    }

    public class TagConfig : Tag
    {
        public string ValidatorRegEx { get; set; }
    }
}