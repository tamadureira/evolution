using EvolutionAPI.Core.Interfacecs.Validation;

namespace EvolutionAPI.Core.Validation
{
    public class Validator<Target, V> : IValidator<Target>
       where V : FluentValidation.IValidator<Target>, new()
    {
        private readonly FluentValidation.IValidator<Target> validator;

        public Validator()
        {
            validator = new V();
        }

        public ValidationResult Validate(Target target)
        {
            ValidationResult validationResult = new ValidationResult();

            if (target == null)
            {
                validationResult.AddValidationError(string.Empty, "Objeto é nulo");
                return validationResult;
            }

            var fluent = validator.Validate(target);

            foreach (var item in fluent.Errors)
            {
                validationResult.AddValidationError(item.PropertyName, item.ErrorMessage);
            }

            return validationResult;
        }
    }
}
