using EvolutionAPI.Core.Interfaces.Entities;
using System;

namespace EvolutionAPI.Core.Interfaces.Repository
{
    public interface IEvolutionRepository
    {
        ITeste ObterDescricaoV1(Guid codigo);
        ITeste ObterDescricaoV2(Guid codigo);
    }
}
