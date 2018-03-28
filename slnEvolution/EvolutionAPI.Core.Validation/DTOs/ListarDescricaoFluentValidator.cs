using EvolutionAPI.Core.Interfaces.DTOs;
using FluentValidation;

namespace EvolutionAPI.Core.Validation.DTOs
{
    public class ListarDescricaoFluentValidator : AbstractValidator<ListaDescricaoGet>
    {
        public ListarDescricaoFluentValidator()
        {
            RuleFor(c => c.Codigo)
                .NotNull().WithMessage(Mensagens.CodigoNotNull);
        }
    }
}
