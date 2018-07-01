namespace ContactMgmt.Api.Models
{
    public class BasicContactInformation
    {
        public long ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryContact { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
    }
}