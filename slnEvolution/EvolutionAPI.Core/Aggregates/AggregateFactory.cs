using System;
using EvolutionAPI.Core.Interfaces.Aggregates;

namespace EvolutionAPI.Core.Aggregates
{
    public class AggregateFactory : IAggregateFactory
    {
        public ITeste CarregarDescricao(string descricao)
        {
            return new Teste(descricao);
        }
    }
}
