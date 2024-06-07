namespace BookStoreAPI.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get;}
        public DateTime Date { get;}
        protected BaseEntity()
        {
            Id= Guid.NewGuid();
            Date= DateTime.Now;
        }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
