using Redis.OM.Modeling;
using System.Net;

namespace Redis_OM.Data.Model
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Users" }, IndexName = "UsersIndex")]
    //[Document(StorageType = StorageType.Json, Prefixes = new[] { "Users" })]

    public class Users
    {
        // Id Field, also indexed, marked as nullable to pass validation
        [RedisIdField]
        [Indexed] 
        public string? Id { get; set; }

        // Indexed for exact text matching
        [Indexed] public string? FirstName { get; set; }
        [Indexed] public string? LastName { get; set; }

        //Indexed for numeric matches
        [Indexed] public int Age { get; set; }

        //Indexed for Full Text matches
        [Searchable] public string? PersonalStatement { get; set; }

        //Index for membership
        [Indexed] public string[] Skills { get; set; } = Array.Empty<string>();

        //Index an object down 1 level
        [Indexed(JsonPath = "$.City")]
        [Indexed(JsonPath = "$.PostalCode")]
        public Address? Address { get; set; }
    }
}
