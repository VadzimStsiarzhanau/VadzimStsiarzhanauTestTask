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
    class RolesAndLocations
    {
        private IWebDriver driver;
       

        public RolesAndLocations(IWebDriver driver)
        {
            this.driver = driver;
            
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "list3")] private IWebElement countries;
        [FindsBy(How = How.Id, Using = "173fbf66-9fcf-4a3c-8f1e-6415cbf8af49")] private IWebElement poland;
        [FindsBy(How = How.Id, Using = "f0d730e9-ef62-4e15-b31e-4639fc8c45a7")] private IWebElement usa;
        [FindsBy(How = How.Id, Using = "jobsearchclick")] private IWebElement searchbutton;
       
        public void SelectPoland()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,50);");
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));
            countries.Click();
            poland.Click();
            searchbutton.Click();
        }


        public void SelectUsa()
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,50);");

            countries.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));
            wait.Until(driver => usa.Displayed);
            usa.Click();

            Thread.Sleep(1000);
            searchbutton.Click();
            Thread.Sleep(1000);
        }


    }
}
