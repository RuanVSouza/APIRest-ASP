using APIRest_ASP.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIRest_ASP.Data.VO
{
    public class BookVO
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
    }
}
