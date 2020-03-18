using Newtonsoft.Json;

namespace AQSOwnerCheckIn.Models
{
    public class Credentials
    {
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName;

        [JsonProperty(PropertyName = "LastName")]
        public string LastName;

        [JsonProperty(PropertyName = "PhoneNumber")]
        public string PhoneNumber;





        public Credentials() { }
    }
}
