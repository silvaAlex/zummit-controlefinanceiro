using Microsoft.AspNetCore.Mvc;
using System.Net;
using Zummit.Auth.DTO.Request;
using Zummit.Auth.Identity.Services.Interfaces;
using Zummit.Auth.Controllers.Shared;
using Zummit.Auth.DTO.Response;

namespace Zummit.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IIdentityService identityService;

        public AuthController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [ProducesResponseType(typeof(CadastroUsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastrar([FromBody] CadastroUsuarioRequest cadastroUsuario)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await identityService.CadastrarUsuario(cadastroUsuario);

            if (result.Success)
                return Ok(result);

            else if (result.Erros.Count > 0)
            {
                var problemDetails = new CustomProblemDetails(HttpStatusCode.BadRequest, Request, errors: result.Erros);
                return BadRequest(problemDetails);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);

        }

        [ProducesResponseType(typeof(LoginUsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<ActionResult<LoginUsuarioResponse>> Login(LoginUsuarioRequest loginUsuario)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await identityService.LoginUsuario(loginUsuario);
            if (result.Sucess)
            {
                return Ok(result);
            }

            return Unauthorized();
        }
    }
}
