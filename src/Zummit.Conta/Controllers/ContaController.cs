using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zummit.Auth.Identity.Constants;
using Zummit.Conta.Attributes;
using Zummit.Conta.Response;
using Zummit.Conta.Services;
using Zummit.Conta.ViewModels;

namespace Zummit.Conta.Controllers
{
    //[Authorize(Roles= Roles.Admin)]
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        readonly IContaBancariaService contaBancariaService;

        public ContaController(IContaBancariaService contaBancariaService)
        {
            this.contaBancariaService = contaBancariaService;
        }

        [ClaimsAuthorize(ClaimTypes.Conta, "Atualizar")]
        [Route("/deposito")]
        [HttpPost]
        public async Task<IActionResult> Depositar([FromBody] ContaBancariaVM contaBancariaVM)
        {
            await contaBancariaService.Depositar(contaBancariaVM.ClienteId, contaBancariaVM.Quantia);
            var contaBancaria = await contaBancariaService.ObterContaBancaria(contaBancariaVM.ClienteId);
            return Ok(contaBancaria.ClienteId);
        }

        [ClaimsAuthorize(ClaimTypes.Conta, "Atualizar")]
        [Route("/sacar")]
        [HttpPost]
        public async Task<ActionResult<ContaBancariaResponse>> Sacar([FromBody] ContaBancariaVM contaBancaria)
        {
            await contaBancariaService.Sacar(contaBancaria.ClienteId,contaBancaria.Quantia);

            return Ok(new ContaBancariaResponse()
            {
                Saldo = contaBancariaService.RetornaSaldoFormatado(contaBancaria.ClienteId),
                DataAbertura = contaBancariaService.RetornaDataAberturaFormatada(contaBancaria.ClienteId),
            });
        }
    }
}