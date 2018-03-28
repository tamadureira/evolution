using EvolutionAPI.Core.Interfaces.Repository;
using System;
using EvolutionAPI.Core.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using EvolutionAPI.Infrastructure.Entity.Entities;
using System.Linq;

namespace EvolutionAPI.Infrastructure.Entity.Repository
{
    public class EvolutionRepository : IEvolutionRepository
    {
        private readonly EvolutionContext _context;

        public EvolutionRepository(EvolutionContext context)
        {
            _context = context;
        }

        //public ITeste ObterDescricao(Guid codigo)
        //{
        //    throw new NotImplementedException();
        //}

        public ITeste ObterDescricao(Guid codigo)
        {
            return (from e in _context.Teste
                   where e.Codigo == codigo
                   select e).FirstOrDefault();
        }
    }
}
