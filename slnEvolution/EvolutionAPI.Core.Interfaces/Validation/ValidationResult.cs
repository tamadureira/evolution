using System.Collections.Generic;
using System.Linq;

namespace EvolutionAPI.Core.Interfacecs.Validation
{
    public class ValidationResult
    {
        public void AddValidationError(string key, string message)
        {
            Errors.Add(new ValidationError(key, message));
        }

        public bool IsValid => !Errors.Any();

        public List<ValidationError> Errors { get; set; }

        public ValidationResult()
        {
            Errors = new List<ValidationError>();
        }
    }
}
