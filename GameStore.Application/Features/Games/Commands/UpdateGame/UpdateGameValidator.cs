using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Commands.UpdateGame
{
    public class UpdateGameValidator:AbstractValidator<UpdateGameCommand>
    {
        public UpdateGameValidator()
        {
            RuleFor(g => g.Name).NotNull().MinimumLength(2);
            RuleFor(g => g.Price).NotNull();
            RuleFor(g => g.ReleaseDate).NotNull();
            RuleFor(g => g.Platform).NotNull().MinimumLength(2);
        }
    }
}
