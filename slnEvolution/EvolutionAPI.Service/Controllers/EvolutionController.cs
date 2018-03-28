﻿using EvolutionAPI.Core.Interfacecs.Exceptions;
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

        /// <summary>
        /// Listar Descrição
        /// </summary>
        /// <param name="listaDescricaoGet"></param>
        /// <returns>Descrição</returns>
        /// <remarks>Este método devolve a descrição.</remarks>
        /// <response code="200">Visualização da descrição</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não existe descrição</response>
        /// <response code="500">Erro no servidor</response>
        /// 
        [HttpGet("Evolution/{Codigo}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult ObterMsgSMS(ListaDescricaoGet listaDescricaoGet)
        {
            IValidator<ListaDescricaoGet> validator = _validatorFactory.CreateValidator<ListaDescricaoGet>();
            var validationResult = validator.Validate(listaDescricaoGet);

            if (!validationResult.IsValid)
                return BadRequest(validationResult);

            try
            {
                var mensagem = _evolutionService.ObterDescricao(listaDescricaoGet);

                return Ok(mensagem.Descricao);
            }
            catch (CoreException ex)
            {
                return NotFound(ex.Validation);
            }
        }
    }
}
