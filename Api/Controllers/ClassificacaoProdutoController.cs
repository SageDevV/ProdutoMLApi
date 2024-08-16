using AllClassification;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassificacaoProdutoController : ControllerBase
    {
        public ClassificacaoProdutoController()
        {
        }

        [HttpGet, Route("obter-classificacao-produto-all")]
        public IActionResult ObterClassificacaoProdutoAll(byte[] image)
        {
            var allClassificationClass = new AllClassificationClass();
            allClassificationClass.ObterAllClassificacoes();

            return Ok();
        }

        [HttpGet, Route("obter-classificacao-produto")]
        public IActionResult ObterClassificacaoProduto()
        {
            return default;
        }
    }
}
