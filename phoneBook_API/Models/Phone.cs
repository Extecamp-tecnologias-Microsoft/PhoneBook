namespace phoneBook_API.Models
{
    public class Phone
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string? AlternativePhone { get; set; }

    }
}
