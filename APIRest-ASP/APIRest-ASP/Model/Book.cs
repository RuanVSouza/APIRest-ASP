using APIRest_ASP.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIRest_ASP.Model
{
    [Table("book")]
    public class Book : BaseEntity
    {

        [Column("title")]
        public string Title { get; set; }

        [Column("author")]
        public string Author { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
    }
}
