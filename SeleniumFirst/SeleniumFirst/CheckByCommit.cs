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
    public class CheckByCommit
    {

        private IWebDriver _driver;

        public void CheckByCommmit()
        {
            _driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");

            _driver.Url = "https://github.com/";

            By signIn = By.LinkText("Sign in");
            IWebElement elSignIn = _driver.FindElement(signIn);
            elSignIn.Click();

            By login = By.Id("login_field");
            IWebElement elLogin = _driver.FindElement(login);
            elLogin.SendKeys("kpapian");

            By password = By.Id("password");
            IWebElement elPassword = _driver.FindElement(password);
            elPassword.SendKeys("14151820a");

            IWebElement submit = _driver.FindElement(By.Name("commit"));
            submit.Click();

            By elementSearch = By.XPath("//div//input[@name='q']");
            string searchCommit = " Site first commit-header done";

            IWebElement elemment = _driver.FindElement(elementSearch);
            elemment.SendKeys(searchCommit + Keys.Enter);

            By tabCommit = By.XPath("//div//nav//a[3]");
            IWebElement element1 = _driver.FindElement(tabCommit);
            element1.Click();

          
            WebDriverWait waitLoading = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement searchresult = waitLoading.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id("commit_search_results")));

            StringAssert.Contains("Site first commit-header done", searchresult.Text);
            StringAssert.Contains("kpapian", searchresult.FindElement(By.CssSelector(".f6")).Text);
                       
            
        }

    }
}
