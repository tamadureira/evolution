using EvolutionAPI.Core.Interfaces.Services;
using System;
using EvolutionAPI.Core.Interfaces.Aggregates;
using EvolutionAPI.Core.Interfacecs.Validation;
using EvolutionAPI.Core.Interfaces.Repository;
using EvolutionAPI.Core.Interfacecs.Exceptions;
using EvolutionAPI.Core.Interfaces.DTOs;
using EvolutionAPI.Core.Interfaces.Entities;

namespace EvolutionAPI.Core.Services
{
    public class EvolutionService : IEvolutionService
    {
        private readonly IEvolutionRepository _mensagemRepository;
        private readonly IAggregateFactory _aggregateFactory;        
        private readonly IValidatorFactory _validationFactory;
        private readonly IEvolutionDapperRepository _evolutionDapperRepository;

        public EvolutionService(IEvolutionRepository mensagemRepository,
            IAggregateFactory aggregateFactory,
            IValidatorFactory validationFactory,
            IEvolutionDapperRepository evolutionDapperRepository)
        {
            _mensagemRepository = mensagemRepository;
            _aggregateFactory = aggregateFactory;
            _validationFactory = validationFactory;
            _evolutionDapperRepository = evolutionDapperRepository;
        }

        public Interfaces.Aggregates.ITeste ObterDescricaoV1(DescricaoGet descricaoGet)
        {
            try
            {
                var descricao = _mensagemRepository.ObterDescricaoV1(descricaoGet.Codigo);

                return _aggregateFactory.CarregarDescricao(descricao.Descricao);
            }
            catch (CoreException ex)
            {
                ValidationResult validationResult = _validationFactory.CreateValidationResult();
                validationResult.AddValidationError("ObterDescricao", ex.Message);
                throw new CoreException(validationResult);
            }
        }

        public Interfaces.Aggregates.ITeste ObterDescricaoV2(DescricaoGet descricaoGet)
        {
            try
            {
                var descricao = _mensagemRepository.ObterDescricaoV2(descricaoGet.Codigo);

                return _aggregateFactory.CarregarDescricao(descricao.Descricao);
            }
            catch (CoreException ex)
            {
                ValidationResult validationResult = _validationFactory.CreateValidationResult();
                validationResult.AddValidationError("ObterDescricao", ex.Message);
                throw new CoreException(validationResult);
            }
        }

        TesteResponse IEvolutionService.ObterTeste(DescricaoDapperGet descricaoDapperGet)
        {
            var testeEntitie = _evolutionDapperRepository.ObterTeste(descricaoDapperGet.Descricao);

            if (testeEntitie == null)
            {
                var validation = _validationFactory.CreateValidationResult();
                validation.AddValidationError("TesteNaoEncontrado", "Teste não enontrado.");
                throw new CoreException(validation);
            }
            TesteResponse testeResponse = new TesteResponse()
            {
                Codigo = testeEntitie.Codigo,
                DataCadastro = testeEntitie.DataCadastro,
                Descricao = testeEntitie.Descricao
            };

            return testeResponse;
        }
    }
}
