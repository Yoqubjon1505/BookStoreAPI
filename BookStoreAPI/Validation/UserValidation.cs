using BookStoreAPI.Models;
using FluentValidation;

namespace BookStoreAPI.Validation
{
    public class UserValidation: AbstractValidator<User>
    {

        public UserValidation()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Введите категории");
        }

    }
}
