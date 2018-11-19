using EvolutionAPI.Core.Interfaces.Aggregates;
using EvolutionAPI.Core.Interfaces.DTOs;

namespace EvolutionAPI.Core.Interfaces.Services
{
    public interface IEvolutionService
    {
        ITeste ObterDescricaoV1(DescricaoGet descricaoGet);
        ITeste ObterDescricaoV2(DescricaoGet descricaoGet);

        TesteResponse ObterTeste(DescricaoDapperGet descricaoDapperGet);
    }
}
