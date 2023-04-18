using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameTypes.Commands.UpdateGameType
{
    public class UpdateGameTypeValidators:AbstractValidator<UpdateGameTypeCommand>
    {
        public UpdateGameTypeValidators()
        {

            RuleFor(gt => gt.TypeName).NotNull().MinimumLength(2);
            RuleFor(gt => gt.TypeDescription).NotNull().MinimumLength(10);

        }
    }
}
