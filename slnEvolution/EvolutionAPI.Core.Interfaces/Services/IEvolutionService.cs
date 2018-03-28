using EvolutionAPI.Core.Interfaces.Aggregates;
using EvolutionAPI.Core.Interfaces.DTOs;
using System;

namespace EvolutionAPI.Core.Interfaces.Services
{
    public interface IEvolutionService
    {
        ITeste ObterDescricao(ListaDescricaoGet listaDescricaoGet);
    }
}
