using EvolutionAPI.Core.Interfaces.Repository;
using System;
using EvolutionAPI.Core.Interfaces.Entities;
using EvolutionAPI.Infrastructure.Dapper.Entities;
using Dapper;
using System.Data;
using System.Linq;

namespace EvolutionAPI.Infrastructure.Dapper.Repository
{
    public class EvolutionDapperRepository : IEvolutionDapperRepository
    {
        private readonly EvolutionContextDapper _context;

        public EvolutionDapperRepository(EvolutionContextDapper context)
        {
            _context = context;
        }
        public ITeste ObterTeste(string descricao)
        {
            var parametros = new DynamicParameters();
            parametros.Add("descricao", descricao, DbType.AnsiString, ParameterDirection.Input);

            string query = @"select Codigo, DataCadastro, Descricao from Teste where Descricao = @descricao";

            return _context.Query<Teste>(query, parametros).FirstOrDefault();
        }
    }
}
