using API.Expedientes.Application.Features.Commands.CreateExpediente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Expedientes.Application.Features.Commands.UpdateExpediente
{
    public class UpdateExpedienteCommandValidator : AbstractValidator<UpdateExpedienteCommand>
    {
        public UpdateExpedienteCommandValidator()
        {
            RuleFor(x => x.IdExpediente)
             .NotEmpty()
             .WithMessage("El campo IdExpediente es obligatorio.");

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
