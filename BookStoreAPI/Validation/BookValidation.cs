using BookStoreAPI.Models;
using FluentValidation;

namespace BookStoreAPI.Validation
{
    public class BookValidation: AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(b=>b.Price)
        .NotEqual(0).WithMessage("цена не может быть нолю")
        .GreaterThan(0).WithMessage("цена должен больше нолю.");
            RuleFor(b => b.BookAuthors).NotEmpty().WithMessage("Введите автора книг");
        }
    }
}
