using EvolutionAPI.Core.Interfacecs.Exceptions;
using EvolutionAPI.Core.Interfacecs.Validation;
using EvolutionAPI.Core.Interfaces.DTOs;
using EvolutionAPI.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvolutionAPI.Service.Controllers
{
    [Route("api/[controller]")]
    public class EvolutionController : Controller
    {
        private readonly IValidatorFactory _validatorFactory;
        private readonly IEvolutionService _evolutionService;

        public EvolutionController(IValidatorFactory validatorFactory,
            IEvolutionService evolutionService)
        {
            _validatorFactory = validatorFactory;
            _evolutionService = evolutionService;
        }

        #region Link

        #region GET - Padrão

        /// <summary>
        /// Listar Descrição - V1
        /// </summary>
        /// <param name="descricaoGet"></param>
        /// <returns>Descrição</returns>
        /// <remarks>Este método devolve a descrição.</remarks>
        /// <response code="200">Visualização da descrição</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não existe descrição</response>
        /// <response code="500">Erro no servidor</response>
        ///       
        [HttpGet("Evolution/ObterDescricaoV1/{Codigo}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult ObterDescricaoV1(DescricaoGet descricaoGet)
        {
            IValidator<DescricaoGet> validator = _validatorFactory.CreateValidator<DescricaoGet>();
            var validationResult = validator.Validate(descricaoGet);

            if (!validationResult.IsValid)
                return BadRequest(validationResult);

            try
            {
                var mensagem = _evolutionService.ObterDescricaoV1(descricaoGet);

                return Ok(mensagem.Descricao);
            }
            catch (CoreException ex)
            {
                return NotFound(ex.Validation);
            }
        }

        #endregion

        #region GET - AD HOC

        /// <summary>
        /// Listar Descrição - V2
        /// </summary>
        /// <param name="descricaoGet"></param>
        /// <returns>Descrição</returns>
        /// <remarks>Este método devolve a descrição.</remarks>
        /// <response code="200">Visualização da descrição</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não existe descrição</response>
        /// <response code="500">Erro no servidor</response>
        ///       
        [HttpGet("Evolution/ObterDescricaoV2/{Codigo}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult ObterDescricaoV2(DescricaoGet descricaoGet)
        {
            IValidator<DescricaoGet> validator = _validatorFactory.CreateValidator<DescricaoGet>();
            var validationResult = validator.Validate(descricaoGet);

            if (!validationResult.IsValid)
                return BadRequest(validationResult);

            try
            {
                var mensagem = _evolutionService.ObterDescricaoV2(descricaoGet);

                return Ok(mensagem.Descricao);
            }
            catch (CoreException ex)
            {
                return NotFound(ex.Validation);
            }
        }

        #endregion

        #endregion

        #region Dapper

        /// <summary>
        /// Listar Teste
        /// </summary>
        /// <param name="descricaoDapperGet"></param>
        /// <returns>Descrição</returns>
        /// <remarks>Este método devolve a descrição.</remarks>
        /// <response code="200">Visualização da descrição</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não existe descrição</response>
        /// <response code="500">Erro no servidor</response>
        ///       
        [HttpGet("Evolution/ObterTeste/{Descricao}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult ObterTeste(DescricaoDapperGet descricaoDapperGet)
        {
            IValidator<DescricaoDapperGet> validator = _validatorFactory.CreateValidator<DescricaoDapperGet>();
            var validationResult = validator.Validate(descricaoDapperGet);

            if (!validationResult.IsValid)
                return BadRequest(validationResult);

            try
            {
                var teste = _evolutionService.ObterTeste(descricaoDapperGet);

                return Ok(teste);
            }
            catch (CoreException ex)
            {
                return NotFound(ex.Validation);
            }
        }
        
        #endregion

    }
}
