using EvolutionAPI.Core.Interfaces.DTOs;
using FluentValidation;

namespace EvolutionAPI.Core.Validation.DTOs
{
    public class DescricaoFluentValidator : AbstractValidator<DescricaoGet>
    {
        public DescricaoFluentValidator()
        {
            RuleFor(c => c.Codigo)
                .NotNull().WithMessage(Mensagens.CodigoNotNull);
        }
    }
}
