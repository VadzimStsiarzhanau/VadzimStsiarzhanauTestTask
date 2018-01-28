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
using OpenQA.Selenium.Support.UI;

namespace VadzimStsiarzhanauTestTask.PageObjects
{
    class Homepage
    {
        private IWebDriver driver;

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
            [FindsBy(How = How.XPath, Using = "/html/body/header/section/div/nav[2]/div/div/div[4]/ul[1]/li[5]/a[1]")]  private IWebElement careers;
            [FindsBy(How = How.LinkText, Using = "Roles and Locations")] private IWebElement roles;

        public void goToHomePage()
        {
            driver.Navigate().GoToUrl("https://www.avanade.com/en");
        }

       

        public void goToRoles()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(careers).Build().Perform();
       
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => roles.Displayed);

            roles.Click();
        }
       
    }
}

