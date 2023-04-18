using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameDevelopers.Commands.UpdateGameDeveloper
{
    public class UpdateGameDeveloperValidator:AbstractValidator<UpdateGameDeveloperCommand>
    {
        public UpdateGameDeveloperValidator()
        {
            RuleFor(gd => gd.DeveloperCompanyMail).NotNull().MinimumLength(5);
            RuleFor(gd => gd.DeveloperCompanyName).NotNull().MinimumLength(5);
            RuleFor(gd => gd.DeveloperCompanyCountry).NotNull().MinimumLength(5);
        }
    }
}
