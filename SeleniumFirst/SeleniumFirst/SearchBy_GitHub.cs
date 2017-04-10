using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SeleniumFirst
{
    public class SearchBy_GitHub    {

        private IWebDriver _driver;

        public void CheckByUsers()
        {           
            _driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");

            _driver.Url = "https://github.com/";
            

            By elementSearch = By.XPath("//div//input[@name='q']");

            string searchName = "kpapian";

            IWebElement elemment = _driver.FindElement(elementSearch);
            elemment.SendKeys(searchName + Keys.Enter);
            
            By tabUsers = By.XPath("//div//nav//a[6]");

            IWebElement element1 = _driver.FindElement(tabUsers);
            element1.Click();

            WebDriverWait waitLoading = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement lable = waitLoading.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id("user_search_results")));
            
            try
            {
                Assert.AreEqual(searchName, lable.FindElement(By.XPath(".//div[2]/div/a")).Text);
                Console.WriteLine("Names are equal");
            }
            catch (Exception notEqual)
            {
                Console.WriteLine(notEqual);
            }

            _driver.Close();
        }

    }
}
