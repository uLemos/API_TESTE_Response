using Microsoft.AspNetCore.Mvc;
using System.Net;
using TesteCore.Models;
using TesteCore.Services;

namespace TesteCore.Controllers
{
    [Route("send-text")]
    [ApiController]
    public class SendTextController : ControllerBase
    {
        private readonly ISendTextService _sendTextService;
        public SendTextController(ISendTextService sendTextService)
        {
            _sendTextService = sendTextService;
        }

        [HttpPost]
        public async Task<ActionResult> EnviarMensagem([FromBody] SendTextModel model)
        {
            var response = await _sendTextService.EnviaMensagem(model);

            if (response.CodigoHttp == HttpStatusCode.OK)
                return Ok(response.DadosRetorno);
            else
                return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }
    }
}
