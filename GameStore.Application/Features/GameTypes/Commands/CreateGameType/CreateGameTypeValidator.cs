using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameTypes.Commands.CreateGameType
{
    public class CreateGameTypeValidator:AbstractValidator<CreateGameTypeCommand>
    {
        public CreateGameTypeValidator()
        {
            RuleFor(gt => gt.TypeName).NotNull().MinimumLength(2);
            RuleFor(gt => gt.TypeDescription).NotNull().MinimumLength(10);
        }
       
    }
}
