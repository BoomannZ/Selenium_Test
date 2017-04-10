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
    public class DeleteRepository
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

            public void DeleteRepo()
            {

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
                rep.Click();

                By settings = By.LinkText("Settings");
                IWebElement settingsTab = _driver.FindElement(settings);
                settingsTab.Click();

                By deleteBtn = By.XPath(".//*[@id='options_bucket']//div/button[3]");
                IWebElement deleteButon = _driver.FindElement(deleteBtn);
                deleteButon.Click();
            
                Assert.AreEqual("Test_repo", rep.Text);

            }
        }
}
