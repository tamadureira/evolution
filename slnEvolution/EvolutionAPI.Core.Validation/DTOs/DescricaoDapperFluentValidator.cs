using EvolutionAPI.Core.Interfaces.DTOs;
using FluentValidation;

namespace EvolutionAPI.Core.Validation.DTOs
{
    public class DescricaoDapperFluentValidator : AbstractValidator<DescricaoDapperGet>
    {
        public DescricaoDapperFluentValidator()
        {
            RuleFor(c => c.Descricao)
                .NotNull().WithMessage(Mensagens.CodigoNotNull);
        }
    }
}
