using FGemig.WebSite.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace FGemig.WebSite.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; }

        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelpers.CaminhoDriver);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
