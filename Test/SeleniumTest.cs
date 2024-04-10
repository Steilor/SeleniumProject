using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Interfaces;

namespace SelemiumProject.Test
{
    public class SeleniumTest
    {
        
        [Test]
        public void SeleniumTest1()
        {
            IWebDriver driver = new ChromeDriver(); 
            string screenshotPath = "C:\\Users\\steil\\Desktop\\Big Data\\BD\\SelemiumProject\\Images";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            //Test1 : Navegar a la pagina web
            driver.Navigate().GoToUrl("https://www.amazon.com/");
            screenshot.SaveAsFile(screenshotPath + "TestOpenWeb.png");
            Thread.Sleep(8000);

            //Test2: Buscar Productos mediante un nombre 
            var imputSearch = driver.FindElement(By.Id("twotabsearchtextbox"));
            imputSearch.SendKeys("Monitor");
            imputSearch.Submit();
            screenshot.SaveAsFile(screenshotPath + "TestBuscarProducto.png");
            Thread.Sleep(8000);

            //Test3: Seleccionar producto deseado
            var linkElement = driver.FindElement(By.CssSelector("a.a-link-normal.s-no-outline"));
            var linkUrl = linkElement.GetAttribute("href");
            driver.Navigate().GoToUrl(linkUrl);
            screenshot.SaveAsFile(screenshotPath + "TesteSelectProduct.png");
            Thread.Sleep(8000);

            //Test4: Agregar producto deseado al carrito
            var AgregarAlCarrito = driver.FindElement(By.Id("add-to-cart-button"));
            AgregarAlCarrito.Click();
            screenshot.SaveAsFile(screenshotPath + "TestAddToCart.png");
            Thread.Sleep(8000);
            
            //Test5: Entrar al carrito donde se encuentra nuestor producto deseado
            var cartLink = driver.FindElement(By.CssSelector("a#nav-cart"));
            cartLink.Click();
            screenshot.SaveAsFile(screenshotPath + "TestIrCarr.png");

            Thread.Sleep(4000);
            driver.Quit();
        }  

    }
}
