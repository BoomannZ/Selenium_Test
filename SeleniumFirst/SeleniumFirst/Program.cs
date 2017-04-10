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
    class Program
    {
        static void Main(string[] args)
        {

            //SearchBy_GitHub users = new SearchBy_GitHub();
            //users.CheckByUsers();

            CheckByCommit commit = new CheckByCommit();
            commit.CheckByCommmit();

            Console.ReadLine();

        }
    }
}
