namespace BookStoreAPI.Models
{
    public class Book:BaseEntity 
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
