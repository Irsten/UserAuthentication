using FluentValidation;
using UserAuthentication.Entities;

namespace UserAuthentication.Models.Validators
{
    public class RegisterUserDtoValidators : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidators(ApplicationDbContext dbContext) 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if(emailInUse) 
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password);
        }
    }
}
