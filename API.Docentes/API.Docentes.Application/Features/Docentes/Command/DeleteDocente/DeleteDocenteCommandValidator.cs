
using FluentValidation;

namespace API.Docentes.Application.Features.Docentes.Command.DeleteDocente
{
    public class DeleteDocenteCommandValidator : AbstractValidator<DeleteDocenteCommand>
    {
        public DeleteDocenteCommandValidator()
        {
            RuleFor(x => x.IdDocente)
               .NotEmpty()
               .WithMessage("El campo IdDocente es obligatorio.");

            RuleFor(x => x.IdUsuario)
                .NotEmpty()
                .WithMessage("El campo IdUsuario es obligatorio.");
        }
    }
}
