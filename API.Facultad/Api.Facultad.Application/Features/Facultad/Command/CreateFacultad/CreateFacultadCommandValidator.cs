using FluentValidation;

namespace Api.Facultad.Application.Features.Facultad.Command.CreateFacultad
{
    public class CreateFacultadCommandValidator : AbstractValidator<CreateFacultadCommand>
    {
        public CreateFacultadCommandValidator()
        {
            RuleFor(p => p.Nombre)
                 .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                 .NotNull()
                 .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caracteres");
        }
    }
}
