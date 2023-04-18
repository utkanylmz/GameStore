using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserValidator:AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.TelNumber).NotNull();
        }
    }
}
