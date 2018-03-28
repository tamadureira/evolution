using EvolutionAPI.Core.Interfacecs.Exceptions;
using EvolutionAPI.Core.Interfacecs.Validation;

namespace EvolutionAPI.Core.Interfaces.Exceptions
{
    public class NotFoundCoreException : CoreException
    {
        public NotFoundCoreException(ValidationResult validation) : base(validation) { }

        public NotFoundCoreException(string message) : base(message) { }
    }
}
