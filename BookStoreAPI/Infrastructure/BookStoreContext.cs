using BookStoreAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BookStoreAPI.Infrastructure
{

    public class BookStoreContext : IdentityDbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options): base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Category> Categories { get; set; } 
        //public DbSet<User> Users { get; set; }
        //public DbSet<Reader> Readers { get; set; }
        //public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>();
            //modelBuilder.Entity<User>()
        //.HasKey(u => u.Id);
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId});

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)");

            
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);
           
            //modelBuilder.Entity<Admin>(entity =>
            //{
            //    entity.HasData(new Admin
            //    {
            //        Name = "Nabijon",
            //        UserName = "Azamov00",
            //        Role = "admin",
            //        Password = "123",
            //        Description = "1wws",
            //        RefreshToken = Guid.NewGuid().ToString() // Generate a random string

            //    });
            //});

            modelBuilder.Entity<Author>(entity => entity.HasKey(p => p.Id));
            modelBuilder.Entity<Book>(entity => entity.HasKey(p => p.Id));
            modelBuilder.Entity<Category>(entity => entity.HasKey(p => p.Id));
            
        }
    }



}
