using System;

namespace EvolutionAPI.Core.Interfaces.Exceptions
{
    public class EvolutionException: Exception
    {
        public EvolutionException(string message) : base(message)
        {
        }

        public EvolutionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
