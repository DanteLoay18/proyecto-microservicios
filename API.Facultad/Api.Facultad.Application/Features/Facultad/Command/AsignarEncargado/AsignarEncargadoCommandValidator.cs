
using FluentValidation;

namespace Api.Facultad.Application.Features.Facultad.Command.AsignarEncargado
{
    public class AsignarEncargadoCommandValidator : AbstractValidator<AsignarEncargadoCommand>
    {

        public AsignarEncargadoCommandValidator()
        {
            RuleFor(x => x.IdFacultad)
            .NotEmpty()
            .WithMessage("El campo IdFacultad es obligatorio.");

            RuleFor(x => x.IdUsuario)
            .NotEmpty()
            .WithMessage("El campo IdUsuario es obligatorio.");

            RuleFor(x => x.IdEncargado)
               .NotEmpty()
               .WithMessage("El campo IdUsuario es obligatorio.");
        }
    }
}
