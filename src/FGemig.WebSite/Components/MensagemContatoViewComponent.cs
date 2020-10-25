using Microsoft.AspNetCore.Mvc;

namespace FGemig.WebSite.Components
{
    public class MensagemContatoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string nome)
        {
            ViewBag.Nome = nome;

            return View();
        }
    }
}
