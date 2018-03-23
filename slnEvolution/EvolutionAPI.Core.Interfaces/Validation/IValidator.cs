namespace EvolutionAPI.Core.Interfacecs.Validation
{
    public interface IValidator<Target>
    {
        ValidationResult Validate(Target target);
    }
}
