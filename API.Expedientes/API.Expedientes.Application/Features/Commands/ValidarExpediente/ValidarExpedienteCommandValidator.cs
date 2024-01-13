using FluentValidation;

namespace API.Expedientes.Application.Features.Commands.ValidarExpediente
{
    public class ValidarExpedienteCommandValidator: AbstractValidator<ValidarExpedienteCommand>
    {
        public ValidarExpedienteCommandValidator()
        {
            RuleFor(x => x.IdExpediente)
             .NotEmpty()
             .WithMessage("El campo IdExpediente es obligatorio.");

            RuleFor(x => x.IdUsuario)
                .NotEmpty()
                .WithMessage("El campo IdUsuario es obligatorio.");


        }
    }
}
