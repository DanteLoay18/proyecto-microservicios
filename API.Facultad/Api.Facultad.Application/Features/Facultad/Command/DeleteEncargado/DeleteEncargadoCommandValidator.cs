
using FluentValidation;

namespace Api.Facultad.Application.Features.Facultad.Command.DeleteEncargado
{
    public class DeleteEncargadoCommandValidator : AbstractValidator<DeleteEncargadoCommand>
    {
        public DeleteEncargadoCommandValidator()
        {
            RuleFor(x => x.IdFacultad)
            .NotEmpty()
            .WithMessage("El campo IdFacultad es obligatorio.");

            RuleFor(x => x.IdUsuario)
            .NotEmpty()
            .WithMessage("El campo IdUsuario es obligatorio.");
        }
    }
}
