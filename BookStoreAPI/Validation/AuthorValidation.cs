using BookStoreAPI.Models;
using FluentValidation;

namespace BookStoreAPI.Validation
{
    public class AuthorValidation: AbstractValidator<Author>
    {
        public AuthorValidation()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull().WithMessage("Введите имя автора");
            RuleFor(a => a.BookAuthors).NotEmpty().WithMessage("Введите книг");
        }
    }
}
