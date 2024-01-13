
using FluentValidation;

namespace API.Expedientes.Application.Features.Commands.DeleteExpediente
{
    public class DeleteExpedienteCommandValidator : AbstractValidator<DeleteExpedienteCommand>
    {
        public DeleteExpedienteCommandValidator()
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
