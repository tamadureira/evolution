using System;

namespace EvolutionAPI.Core.Interfaces.Entities
{
    public interface ITeste
    {
        Guid Codigo { get; set; }
        DateTime DataCadastro { get; set; }
        string Descricao { get; set; }
    }
}
