using System;
using EvolutionAPI.Core.Interfaces.Entities;

namespace EvolutionAPI.Infrastructure.Entity.Entities
{
    public class Teste : ITeste
    {
        public Teste()
        {

        }
        public Guid Codigo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
    }
}
