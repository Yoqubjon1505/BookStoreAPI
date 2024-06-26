using System.Text.Json.Serialization;

namespace BookStoreAPI.Models
{
    public class Category:BaseEntity
    {
      public ICollection<Book> Books { get; set; }
    }
}
