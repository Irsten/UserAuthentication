using FluentValidation;
using UserAuthentication.Entities;

namespace UserAuthentication.Models.Validators
{
    public class LoginDtoValidators : AbstractValidator<LoginDto>
    {
        public LoginDtoValidators(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}
