using Clientes.DTOs;
using Clientes.Pagination;
using Clientes.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPaged([FromQuery] PageParams pageParams)
        {
            try
            {
                var result = await _clientService.GetAllPaged(pageParams);
                if(result == null) return NoContent();
                return Ok(result);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar recuperar clientes",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _clientService.GetById(id);
                if(result == null) return NoContent();
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar recuperar cliente",
                    details = ex.Message
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet("HealthScoreRisk")]
        public async Task<IActionResult> GetHealthRiskScore()
        {
            try
            {
                var result = await _clientService.GetHealthScoreRisk();
                if(result == null) return NoContent();
                return Ok(result);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar recuperar cliente com maior score de risco saude"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClientDTO model)
        {
            try
            {
                var result = await _clientService.Create(model);
                return Ok(result);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar criar cliente",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(ClientDTO model)
        {
            try
            {
                var result = await _clientService.Update(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar alterar cliente",
                    de = ex.Message
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _clientService.Delete(id);
                return Ok(result);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar deletar cliente",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}