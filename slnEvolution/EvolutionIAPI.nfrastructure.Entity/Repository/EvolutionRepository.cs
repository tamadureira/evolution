using EvolutionAPI.Core.Interfaces.Repository;
using System;
using EvolutionAPI.Core.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using EvolutionAPI.Infrastructure.Entity.Entities;
using System.Linq;
using System.Data;
using EvolutionAPI.Core.Interfacecs.Validation;
using EvolutionAPI.Core.Interfaces.Exceptions;

namespace EvolutionAPI.Infrastructure.Entity.Repository
{
    public class EvolutionRepository : IEvolutionRepository
    {
        private readonly EvolutionContext _context;
        private readonly IValidatorFactory _validatorFactory;

        public EvolutionRepository(EvolutionContext context, IValidatorFactory validatorFactory)
        {
            _context = context;
            _validatorFactory = validatorFactory;
        }

        public ITeste ObterDescricaoV1(Guid codigo)
        {
            var descricao = (from e in _context.Teste
                   where e.Codigo == codigo
                   select e).FirstOrDefault();

            if (descricao == null)
            {
                ValidationResult validationResult = _validatorFactory.CreateValidationResult();
                validationResult.AddValidationError("DescricaoNaoLocalizada", Mensagens.DescricaoNaoLocalizada);
                throw new NotFoundCoreException(validationResult);
            }

            return descricao;
        }

        public ITeste ObterDescricaoV2(Guid codigo)
        {
            var sqlQuery = (@"select Codigo, DataCadastro, Descricao from Teste where Codigo = '" + codigo + "'");
            var descricao = _context.Teste.FromSql(sqlQuery).AsNoTracking().SingleOrDefault();

            //IDEAL
            //var param = new SqlParameter
            //{
            //    ParameterName = "codigoTeste",
            //    DbType = DbType.Guid,
            //    Value = codigo,
            //    SqlValue = codigo
            //};

            //var descricao = _context.Teste.FromSql(
            //    @"select Codigo, DataCadastro, Descricao from Teste where Codigo = @codigoTeste"
            //    , param).AsNoTracking().SingleOrDefault();


            if (descricao == null)
            {
                ValidationResult validationResult = _validatorFactory.CreateValidationResult();
                validationResult.AddValidationError("DescricaoNaoLocalizada", Mensagens.DescricaoNaoLocalizada);
                throw new NotFoundCoreException(validationResult);
            }

            return descricao;
        }
    }
}
