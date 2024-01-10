

using FluentValidation;

namespace API.Docentes.Application.Features.Docentes.Command.CreateDocente
{
    public class CreateDocenteCommandValidator : AbstractValidator<CreateDocenteCommand>
    {
        public CreateDocenteCommandValidator()
        {
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
