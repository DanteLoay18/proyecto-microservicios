
using FluentValidation;

namespace Api.Facultad.Application.Features.Facultad.Command.UpdateFacultad
{
    public class UpdateFacultadCommandValidator : AbstractValidator<UpdateFacultadCommand>
    {
        public UpdateFacultadCommandValidator()
        {
            RuleFor(p => p.Nombre)
                 .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                 .NotNull()
                 .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caracteres");
            RuleFor(p => p.FacultadId)
                 .NotEmpty().WithMessage("{Facultad} no puede estar en blanco")
                 .NotNull();
        }
    }
}
