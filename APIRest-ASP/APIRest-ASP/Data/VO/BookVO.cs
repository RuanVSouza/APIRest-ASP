using APIRest_ASP.Hypermedia.Abstract;
using APIRest_ASP.HyperMedia;
using System.Text.Json.Serialization;

namespace APIRest_ASP.Data.VO
{
    public class BookVO : ISuportHypermedia
    {
        [JsonPropertyName("code")]
        public long Id { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Author")]
        public string Author { get; set; }

        [JsonPropertyName("Price")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public DateTime LaunchDate { get; set; }
        
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
