using APIRest_ASP.Hypermedia.Abstract;
using APIRest_ASP.HyperMedia;
using APIRest_ASP.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIRest_ASP.Data.VO
{

    public class PersonVO : ISuportHypermedia
    {
        [JsonPropertyName("code")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonIgnore]
        public string Address { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        
        public List<HyperMediaLink> Links { get; set ; } = new List<HyperMediaLink>();
    }
}
