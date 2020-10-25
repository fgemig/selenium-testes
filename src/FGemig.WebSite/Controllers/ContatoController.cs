using FGemig.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FGemig.WebSite.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ILogger<ContatoController> _logger;

        public ContatoController(ILogger<ContatoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new ContatoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("Nome, Assunto, Email, Telefone, Mensagem")] ContatoViewModel viewModel)
        {
            _logger.LogDebug("Nova mensagem recebida via formulário de contato...");

            return View(viewModel);
        }
    }
}
