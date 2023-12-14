using System.Text.Json.Serialization;

namespace WebClient
{
    public class CustomerCreateRequest
    {
        public CustomerCreateRequest()
        {
            FirstName = null;
            LastName = null;
            
        }

        [JsonConstructor]
        public CustomerCreateRequest(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [JsonPropertyName("firstName")]
        public string FirstName { get; init; }
        
        [JsonPropertyName("lastName")]
        public string LastName { get; init; }
    }
}