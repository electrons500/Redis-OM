using Redis.OM.Modeling;

namespace Redis_OM.Data.Model
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Address" }, IndexName = "AddressIndex")]
    public class Address
    {
        [Indexed]
        public string? StreetName { get; set; }

        [Searchable]
        public string? City { get; set; }

        [Indexed]
        public string? State { get; set; }

        [Indexed]
        public string? PostalCode { get; set; }

        [Indexed]
        public string? Country { get; set; }
       
    }
}
