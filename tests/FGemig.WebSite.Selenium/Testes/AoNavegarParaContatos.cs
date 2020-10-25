using FGemig.WebSite.Selenium.Fixtures;
using FGemig.WebSite.Selenium.Helpers;
using OpenQA.Selenium;
using Xunit;

namespace FGemig.WebSite.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaContatos
    {
        private readonly IWebDriver _driver;
        private readonly string _url;

        public AoNavegarParaContatos(TestFixture fixture)
        {
            _driver = fixture.Driver;
            _url = $"{TestHelpers.UrlBase}/Contato";
        }

        private void NavegarParaContato()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        [Fact]
        public void DeveMostrarContatoNaBarraDeTitulo()
        {
            NavegarParaContato();

            Assert.Contains("Contato", _driver.Title);
        }

        [Fact]
        public void DeveExibirOTituloContato()
        {
            NavegarParaContato();

            Assert.Contains("Fale Conosco", _driver.PageSource);
        }
      
        [Theory]
        [InlineData("Pessoa 1", "Assunto Pessoa 1", "pessoa1@email.com", "(11) 11111-1111", "Mensagem formulário pessoa 1")]
        [InlineData("Pessoa 2", "Assunto Pessoa 2", "pessoa2@email.com", "(11) 22222-2222", "Mensagem formulário pessoa 2")]
        [InlineData("Pessoa 3", "Assunto Pessoa 3", "pessoa3@email.com", "(11) 33333-3333", "Mensagem formulário pessoa 3")]
        public void DadoInformacoesValidasDeveEnviarInformacoesDeContato(
            string nome, 
            string assunto, 
            string email, 
            string telefone, 
            string mensagem)
        {
            NavegarParaContato();

            var inputNome = _driver.FindElement(By.Id("Nome"));
            var inputAssunto = _driver.FindElement(By.Id("Assunto"));
            var inputEmail = _driver.FindElement(By.Id("Email"));
            var inputTelefone = _driver.FindElement(By.Id("Telefone"));
            var inputMensagem = _driver.FindElement(By.Id("Mensagem"));

            inputNome.SendKeys(nome);
            inputAssunto.SendKeys(assunto);
            inputEmail.SendKeys(email);
            inputTelefone.SendKeys(telefone);
            inputMensagem.SendKeys(mensagem);

            var inputSubmit = _driver.FindElement(By.XPath("//button[@type='submit']"));
            inputSubmit.Click();

            var mensagemEsperada = $"Olá, {nome}! Obrigado por entrar em contato!";

            Assert.Contains(mensagemEsperada, _driver.PageSource);
        }      
    }
}
