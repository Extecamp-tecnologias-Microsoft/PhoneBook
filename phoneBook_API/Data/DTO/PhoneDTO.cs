﻿namespace phoneBook_API.Data.DTO
{
    public class PhoneDTO
    {
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string? AlternativePhone { get; set; }
    }
}
