using Clientes.DTOs;
using Clientes.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthProblemController : ControllerBase
    {
        private readonly IHealthProblemsService _healthProblemService;
        public HealthProblemController(IHealthProblemsService healthProblemService)
        {
            _healthProblemService = healthProblemService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _healthProblemService.GetById(id);
                if(result == null) return NoContent();
                return Ok(result);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar recuperar problema de saude",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPut]
        public async Task<IActionResult> SaveHealthProblems(HealthProblemDTO[] models, long clientId)
        {
            try
            {
                var result = await _healthProblemService.SaveHealthProblems(models, clientId);
                return Ok(result);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar salvar problemas de saude",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _healthProblemService.Delete(id);
                return Ok(result);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar deletar problema de saude",
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}