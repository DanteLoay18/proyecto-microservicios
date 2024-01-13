using FluentValidation;

namespace API.Expedientes.Application.Features.Commands.CreateExpediente
{
    public class CreateExpedienteCommandValidator : AbstractValidator<CreateExpedienteCommand>
    {
        public CreateExpedienteCommandValidator()
        {
            RuleFor(x => x.IdFacultad)
              .NotEmpty()
              .WithMessage("El campo IdFacultad es obligatorio.");

            RuleFor(x => x.IdEscuela)
                .NotEmpty()
                .WithMessage("El campo IdEscuela es obligatorio.");

            RuleFor(x => x.Tipo)
                .NotEmpty()
                .WithMessage("El campo Tipo es obligatorio.");

            RuleFor(x => x.IdUsuario)
                .NotEmpty()
                .WithMessage("El campo IdUsuario es obligatorio.");

            RuleFor(x => x.NumeroExpediente)
                .NotEmpty()
                .WithMessage("El campo Numero Expediente es obligatorio.");

            RuleForEach(x => x.Estudiantes).ChildRules(p =>
            {
                p.RuleFor(x => x.Nombre)
                    .NotEmpty()
                    .WithMessage("Se requiere el nombre del estudiante."); 

                p.RuleFor(x => x.Dni)
                    .NotEmpty()
                    .WithMessage("Se requiere el Dni del estudiante.")
                    .MinimumLength(8)
                    .WithMessage("El campo Dni no cumple el formato.");
            });
        }
    }
}
