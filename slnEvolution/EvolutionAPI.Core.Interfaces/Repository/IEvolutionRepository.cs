using EvolutionAPI.Core.Interfaces.Entities;
using System;

namespace EvolutionAPI.Core.Interfaces.Repository
{
    public interface IEvolutionRepository
    {
        ITeste ObterDescricao(Guid codigo);
    }
}
