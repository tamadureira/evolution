using EvolutionAPI.Core.Interfaces.Entities;
using System;

namespace EvolutionAPI.Core.Interfaces.Repository
{
    public interface IEvolutionDapperRepository
    {
        ITeste ObterTeste(string descricao);
    }
}
