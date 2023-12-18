using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zummit.Auth.Identity.Constants;
using Zummit.Conta.Attributes;
using Zummit.Conta.Services;
using Zummit.Conta.ViewModels;

namespace Zummit.Conta.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        readonly IContaBancariaService contaBancariaService;

        public ContaController(IContaBancariaService contaBancariaService)
        {
            this.contaBancariaService = contaBancariaService;
        }

        [HttpGet(Name = "GetSaldo")]
        [ClaimsAuthorize(ClaimTypes.Conta, "Ler")]
        public string GetSaldoFormatado()
        {
           return contaBancariaService.RetornaSaldoFormatado();
        }

        [HttpGet(Name = "GetDataAbertura")]
        [ClaimsAuthorize(ClaimTypes.Conta, "Ler")]
        public string GetDataAberturaConta()
        {
            return contaBancariaService.RetornaDataAberturaFormatada();
        }

        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ClaimsAuthorize(ClaimTypes.Conta, "Inserir")]
        [HttpPost]
        public async Task Depositar([FromBody] ContaBancariaVM contaBancaria)
        {
            await contaBancariaService.Depositar(contaBancaria.Quantia);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ClaimsAuthorize(ClaimTypes.Conta, "Atualizar")]
        [HttpPost]
        public async Task Sacar([FromBody] ContaBancariaVM contaBancaria)
        {
            await contaBancariaService.Sacar(contaBancaria.Quantia);
        }
    }
}