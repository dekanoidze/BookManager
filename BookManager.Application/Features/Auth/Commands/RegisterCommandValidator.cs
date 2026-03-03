using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BookManager.Application.Features.Auth.Commands
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator() {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(58).WithMessage("Name can not exceed 58 characters");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email adress");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Paswword is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        
        }

    }
}
