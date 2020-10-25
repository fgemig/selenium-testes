using System.IO;
using System.Reflection;

namespace FGemig.WebSite.Selenium.Helpers
{
    public static class TestHelpers
    {
        public static string CaminhoDriver = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location);
    }
}
