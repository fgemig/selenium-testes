using FGemig.WebSite.Selenium.Fixtures;
using OpenQA.Selenium;
using System.Linq;
using Xunit;

namespace FGemig.WebSite.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private readonly IWebDriver _driver;
        private readonly string _url;

        public AoNavegarParaHome(TestFixture fixture)
        {
            _driver = fixture.Driver;
            _url = "https://localhost:44305/";
        }

        private void NavegarParaHome()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        [Fact]
        public void DeveMostrarPlanosNaBarraDeTitulo()
        {
            NavegarParaHome();

            Assert.Contains("Planos", _driver.Title);
        }

        [Fact]
        public void DeveExibirOTituloNossosPlanos()
        {
            NavegarParaHome();

            var elemento = _driver.FindElement(By.XPath("//div[contains(@class,'section-title')]/h2"));

            var elementoTexto = elemento.Text;

            Assert.Equal("NOSSOS PLANOS", elementoTexto);
        }

        [Fact]
        public void DeveMostrarAsInformacoesDoPlanoBasico()
        {
            NavegarParaHome();

            var planos = _driver.FindElements(By.XPath("//div[contains(@class,'price-title')]/h4"));

            var existePlanoBasico = planos.Any(c => c.Text.Contains("BÁSICO"));           

            Assert.True(existePlanoBasico);
        }

        [Fact]
        public void DeveMostrarAsInformacoesDoPlanoIntermediario()
        {
            NavegarParaHome();

            var planos = _driver.FindElements(By.XPath("//div[contains(@class,'price-title')]/h4"));

            var existePlanoBasico = planos.Any(c => c.Text.Contains("INTERMEDIÁRIO"));

            Assert.True(existePlanoBasico);
        }

        [Fact]
        public void DeveMostrarAsInformacoesDoPlanoAvancado()
        {
            NavegarParaHome();

            var planos = _driver.FindElements(By.XPath("//div[contains(@class,'price-title')]/h4"));

            var existePlanoBasico = planos.Any(c => c.Text.Contains("AVANÇADO"));

            Assert.True(existePlanoBasico);
        }
    }
}
