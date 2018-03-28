using EvolutionAPI.Core.Interfacecs.Validation;
using EvolutionAPI.Core.Interfaces.DTOs;
using EvolutionAPI.Core.Validation.DTOs;
using System;
using System.Collections.Generic;

namespace EvolutionAPI.Core.Validation
{
    public class ValidatorFactory : IValidatorFactory
    {
        private readonly Dictionary<Type, Type> _conversions = new Dictionary<Type, Type>() {
            { typeof(ListaDescricaoGet), typeof(Validator<ListaDescricaoGet, ListarDescricaoFluentValidator>)},
        };

        public ValidationResult CreateValidationResult()
        {
            return new ValidationResult();
        }

        public IValidator<T> CreateValidator<T>()
        {
            if (_conversions.ContainsKey(typeof(T)))
            {
                return (IValidator<T>)Activator.CreateInstance(_conversions[typeof(T)]);
            };

            throw new NotImplementedException(
                string.Format("Não existe um Validador implementado para a classe {0}.", typeof(T).ToString()));
        }
    }
}
