namespace BookStoreAPI.Models
{
    public class Book 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
