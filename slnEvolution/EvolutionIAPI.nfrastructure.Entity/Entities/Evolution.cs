using EvolutionAPI.Core.Interfaces.Entities;

namespace EvolutionAPI.Infrastructure.Entity.Entities
{
    public class Evolution : IEvolution
    {
        public Evolution()
        {

        }
        public string Mensagem { get; set; }
    }
}
