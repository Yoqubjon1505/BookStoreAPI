using BookStoreAPI.Models;
using FluentValidation;

namespace BookStoreAPI.Validation
{
    public class CategoryValidation: AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Введите категории");
        }
    }
}
