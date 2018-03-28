using EvolutionAPI.Core.Interfaces.Services;
using System;
using EvolutionAPI.Core.Interfaces.Aggregates;
using EvolutionAPI.Core.Interfacecs.Validation;
using EvolutionAPI.Core.Interfaces.Repository;
using EvolutionAPI.Core.Interfacecs.Exceptions;
using EvolutionAPI.Core.Interfaces.DTOs;

namespace EvolutionAPI.Core.Services
{
    public class EvolutionService : IEvolutionService
    {
        private readonly IEvolutionRepository _mensagemRepository;
        private readonly IAggregateFactory _aggregateFactory;        
        private readonly IValidatorFactory _validationFactory;

        public EvolutionService(IEvolutionRepository mensagemRepository,
            IAggregateFactory aggregateFactory,
            IValidatorFactory validationFactory)
        {
            _mensagemRepository = mensagemRepository;
            _aggregateFactory = aggregateFactory;
            _validationFactory = validationFactory;
        }

        public ITeste ObterDescricaoV1(ListaDescricaoGet listaDescricaoGet)
        {
            try
            {
                var descricao = _mensagemRepository.ObterDescricaoV1(listaDescricaoGet.Codigo);

                return _aggregateFactory.CarregarDescricao(descricao.Descricao);
            }
            catch (CoreException ex)
            {
                ValidationResult validationResult = _validationFactory.CreateValidationResult();
                validationResult.AddValidationError("ObterDescricao", ex.Message);
                throw new CoreException(validationResult);
            }
        }

        public ITeste ObterDescricaoV2(ListaDescricaoGet listaDescricaoGet)
        {
            try
            {
                var descricao = _mensagemRepository.ObterDescricaoV2(listaDescricaoGet.Codigo);

                return _aggregateFactory.CarregarDescricao(descricao.Descricao);
            }
            catch (CoreException ex)
            {
                ValidationResult validationResult = _validationFactory.CreateValidationResult();
                validationResult.AddValidationError("ObterDescricao", ex.Message);
                throw new CoreException(validationResult);
            }
        }
    }
}
