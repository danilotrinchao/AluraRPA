using AluraRPA.Domain.Entities;
using AluraRPA.Domain.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AluraRPA.Infra.CrossCutting.WebScrapping
{
    public class AluraScrappingService: IAluraScrappingService
    {
        private readonly IWebDriver _driver;
        private const string url = "https://www.alura.com.br/";

        public AluraScrappingService()
        {
            _driver = new ChromeDriver();
        }

        public Curso ObterDadosAlura(string termo)
        {
            try
            {
                _driver.Navigate().GoToUrl(url);

                IWebElement campoBusca = _driver.FindElement(By.Id("header-barraBusca-form-campoBusca"));

                campoBusca.SendKeys(termo);
                campoBusca.Submit();
             
                var resultados = _driver.FindElements(By.CssSelector("#busca-resultados > ul"));
                System.Threading.Thread.Sleep(5000);

                var curso = new Curso();
                if (resultados != null && resultados.Count > 0)
                {
                    foreach (var resultado in resultados)
                    {
                        var count = 1;
                        var tituloResult = resultado.FindElement(By.CssSelector($"#busca-resultados > ul > li:nth-child({count}) > a > div > h4")).Text;
                        if (tituloResult.Contains(termo))
                        {
                            resultado.Click();
                            System.Threading.Thread.Sleep(5000);
                            if (isBusy())
                            {
                                _driver.Navigate().Back();
                                continue;
                                resultado.FindElement(By.CssSelector("a")).Click();
                                System.Threading.Thread.Sleep(5000);

                            }
                            else
                            {
                                var professor = _driver.FindElement(By.XPath("/html/body/section[2]/div[1]/section/div/div/div/h3")).Text;
                                var carga = _driver.FindElement(By.XPath("/html/body/section[1]/div/div[2]/div[1]/div/div[1]/div/p[1]")).Text;
                                var descricao = _driver.FindElement(By.XPath("/html/body/section[2]/div[1]/div/ul")).Text;

                                curso.Id = Math.Min(1, 9999);
                                curso.titulo = tituloResult;
                                curso.professores = professor;
                                curso.cargaHoraria = carga;
                                curso.descricao = descricao;
                                
                            }

                        }


                    }
                }
                return curso;
            }
            finally
            {
                _driver.Quit();
            }
        }

        private bool isBusy()
         {
            try
            {
                _driver.FindElement(By.XPath("/html/body/div[1]/section/section[1]/h1"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            
        }

    }
}

