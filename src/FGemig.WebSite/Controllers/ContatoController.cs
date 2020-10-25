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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("Nome, Assunto, Email, Telefone, Mensagem")] ContatoViewModel viewModel)
        {
            ViewBag.Mensagem = $"Olá, {viewModel.Nome}! Obrigado por entrar em contato!";

            return View();
        }
    }
}
