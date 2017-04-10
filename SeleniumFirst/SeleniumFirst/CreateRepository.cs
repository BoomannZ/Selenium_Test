using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

namespace SeleniumFirst
{
      public class CreateRepository
    {


        private IWebDriver _driver;

        public void CreateDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");

            _driver = new ChromeDriver(options);

        }


        public void LogInOnGitHub()
        {
            _driver.Url = "https://github.com/";

            IWebElement elSignIn = _driver.FindElement(By.LinkText("Sign in"));
            elSignIn.Click();

            IWebElement elLogin = _driver.FindElement(By.Id("login_field"));
            elLogin.SendKeys("kpapian");

            IWebElement elPassword = _driver.FindElement(By.Id("password"));
            elPassword.SendKeys("14151820a" + Keys.Enter);

        }


        public void CreateRepo()
        {
            _driver.FindElement(By.XPath(".//*[@id='user-links']//li[2]")).Click();

            IWebElement createNewRepo = _driver.FindElement(By.XPath(".//*[@id='user-links']//ul/a[1]"));
            Thread.Sleep(3000);

            createNewRepo.Click();

            IWebElement repoName = _driver.FindElement(By.Id("repository_name"));
            repoName.SendKeys("Test_repo");

            Thread.Sleep(2000);

            _driver.FindElement(By.XPath(".//*[@id='new_repository']/div[4]/button")).Submit();

            By elLocDropDown = By.XPath(".//*[@class='avatar']");
            IWebElement elementDropDown = _driver.FindElement(elLocDropDown);
            elementDropDown.Click();

            By elLocProfile = By.XPath(".//*[@id='user-links']//div/a[1]");
            IWebElement elementProfile = _driver.FindElement(elLocProfile);
            elementProfile.Click();

            By repositorys = By.XPath(".//div[3]/nav/a[2]");
            IWebElement repoTab = _driver.FindElement(repositorys);
            repoTab.Click();

            By newRepos = By.LinkText("Test_repo");
            IWebElement rep = _driver.FindElement(newRepos);

            Assert.AreEqual("Test_repo", rep.Text);

        }
    }
}
