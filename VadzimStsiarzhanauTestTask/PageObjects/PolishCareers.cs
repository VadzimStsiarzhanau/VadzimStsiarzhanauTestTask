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
using System.Threading;

namespace VadzimStsiarzhanauTestTask.PageObjects
{
    class PolishCareers
    {
        private IWebDriver driver;

        public PolishCareers(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[placeholder='Keyword or city']")] private IWebElement inputForm;
        [FindsBy(How = How.CssSelector, Using = "[ps-default='All categories']")] private IWebElement category;
        [FindsBy(How = How.CssSelector, Using = ".table-striped")] private IWebElement table;
        

        public void InputCity(string city)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[placeholder = 'Keyword or city']")));
            wait.Until(driver => inputForm.Displayed);
            inputForm.SendKeys(city);
        }
        
        public void VerifyKrakowResults()
        {
            var timeout = 2000;
            Thread.Sleep(timeout);  
            
            IReadOnlyCollection<IWebElement> totalRow = table.FindElements(By.TagName("tr"));
            int number = totalRow.Count;

            try
            {
                Assert.IsTrue(number > 5);
            }
            catch 
            {
                throw new AssertionException("There's not more than 5 positions for Krakow");
            }
        }


        public void VerifyWarsawResults()
        {
            var timeout = 2000;
            Thread.Sleep(timeout);
            IReadOnlyCollection<IWebElement> totalRow = table.FindElements(By.TagName("tr"));
            int number = totalRow.Count;
            try
            {
                Assert.IsTrue(number >= 1);
            }
            catch 
            {
                throw new AssertionException("There's not even 1 position for Warsaw");
            }
        }





    } 
}
