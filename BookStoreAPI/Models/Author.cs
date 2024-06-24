using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookStoreAPI.Models
{
    public class Author:BaseEntity 
    {
        
        public ICollection<BookAuthor> BookAuthors { get; set; }


    }
}
