using EvolutionAPI.Core.Interfaces.Entities;
using System;

namespace EvolutionAPI.Infrastructure.Dapper.Entities
{
    public class Teste : ITeste
    {
        public Guid Codigo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
    }
}
