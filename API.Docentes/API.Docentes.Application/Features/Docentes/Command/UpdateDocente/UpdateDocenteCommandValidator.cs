

using API.Docentes.Application.Features.Docentes.Command.CreateDocente;
using FluentValidation;

namespace API.Docentes.Application.Features.Docentes.Command.UpdateDocente
{
    public class UpdateDocenteCommandValidator : AbstractValidator<UpdateDocenteCommand>
    {
        public UpdateDocenteCommandValidator()
        {
            RuleFor(x => x.IdDocente)
               .NotEmpty()
               .WithMessage("El campo IdDocente es obligatorio.");

            RuleFor(x => x.IdFacultad)
               .NotEmpty()
               .WithMessage("El campo IdFacultad es obligatorio.");

            RuleFor(x => x.IdEscuela)
                .NotEmpty()
                .WithMessage("El campo IdEscuela es obligatorio.");

            RuleFor(x => x.NombreCompleto)
                .NotEmpty()
                .WithMessage("El campo Nombre Completo es obligatorio.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El campo Email es obligatorio.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("El campo Email no cumple el formato.");

            RuleFor(x => x.IdUsuario)
                .NotEmpty()
                .WithMessage("El campo IdUsuario es obligatorio.");

            RuleFor(x => x.NumeroDocumento)
                .NotEmpty()
                .WithMessage("El campo Numero Documento es obligatorio.")
                .MinimumLength(8)
                .WithMessage("El campo Numero Documento no cumple el formato.");
        }
    }
}
