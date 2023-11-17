using Trainmate.Common.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainmate.Common.Dto;

namespace Trainmate.Common.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage("The userName is required");
            RuleFor(x => x.Password)
                    .NotEmpty().WithMessage("The password is required");

        }
    }
}
