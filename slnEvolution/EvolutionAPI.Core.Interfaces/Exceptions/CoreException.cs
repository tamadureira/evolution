using EvolutionAPI.Core.Interfacecs.Validation;
using System;

namespace EvolutionAPI.Core.Interfacecs.Exceptions
{
    public class CoreException : Exception
    {
        public CoreException(ValidationResult validation)
        {
            Validation = validation;
        }

        public CoreException(string message) : base(message) { }

        public readonly ValidationResult Validation;
    }
}
