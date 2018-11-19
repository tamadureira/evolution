using EvolutionAPI.Core.Interfaces.Aggregates;
using System;

namespace EvolutionAPI.Core.Aggregates
{
    public class Teste : ITeste
    {
        public Teste()
        {

        }
        public Teste(string descricao)
        {
            Descricao = descricao;
        }
        public string Descricao { get; private set; }
    }
}
