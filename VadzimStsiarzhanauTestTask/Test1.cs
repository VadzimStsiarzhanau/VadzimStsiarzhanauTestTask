using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VadzimStsiarzhanauTestTask.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace VadzimStsiarzhanauTestTask
{
    public class Test1
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void KrakowResults()
        {
            Homepage home = new Homepage(driver);
            home.goToHomePage();
            home.goToRoles();
            RolesAndLocations roles = new RolesAndLocations(driver);
            roles.SelectPoland();
            PolishCareers careers = new PolishCareers(driver);
            careers.InputCity("Krakow");
            careers.VerifyKrakowResults();
        }

        [Test]
        public void WarsawResults()
        {
            Homepage home = new Homepage(driver);
            home.goToHomePage();
            home.goToRoles();
            RolesAndLocations roles = new RolesAndLocations(driver);
            roles.SelectPoland();
            PolishCareers careers = new PolishCareers(driver);
            careers.InputCity("Warsaw");
            careers.VerifyWarsawResults();
        }

        [Test]
        public void SeattleResults()
        {
            Homepage home = new Homepage(driver);
            home.goToHomePage();
            home.goToRoles();
            RolesAndLocations roles = new RolesAndLocations(driver);
            roles.SelectUsa();
            UsaCareers careers = new UsaCareers(driver);
            careers.InputCity("Seattle");
            careers.InputCategory();
            careers.VerifySeattleResults("Strong time management skills");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}

