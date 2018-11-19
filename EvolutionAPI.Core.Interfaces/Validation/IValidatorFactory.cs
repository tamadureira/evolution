namespace EvolutionAPI.Core.Interfacecs.Validation
{
    public interface IValidatorFactory
    {
        IValidator<T> CreateValidator<T>();

        ValidationResult CreateValidationResult();
    }
}
