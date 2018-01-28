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
    class UsaCareers
    {
        private IWebDriver driver;

        public UsaCareers(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[placeholder='Keyword or city']")] private IWebElement inputForm;
        [FindsBy(How = How.CssSelector, Using = "[ps-default='All categories']")] private IWebElement category;
        [FindsBy(How = How.CssSelector, Using = "[value = 'Software Engineering']")] private IWebElement softwareEngineering;
        [FindsBy(How = How.LinkText, Using = "Entry Level Software Engineer, Seattle")] private IWebElement entryLevelEngineer;
        [FindsBy(How = How.XPath, Using = "//*[@id=\"page\"]/div/div[2]/div[2]/div[3]/div[3]/div[1]/div[2]/ul[2]")] private IWebElement skills;
        public void InputCity(string city)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[placeholder = 'Keyword or city']")));
            wait.Until(driver => inputForm.Displayed);
            inputForm.SendKeys(city);
        }

        public void InputCategory()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));
            wait.Until(driver => category.Displayed);
            category.Click();
            softwareEngineering.Click();
        }

        public void VerifySeattleResults(string expectedSkill)
        {
            Thread.Sleep(2000);
            entryLevelEngineer.Click();

            IReadOnlyCollection<IWebElement> skillsCollection = skills.FindElements(By.TagName("li"));

            int x = 0;
            foreach (var item in skillsCollection)
            {
                if (item.Text != expectedSkill)
                {
                    x++;
                }
            }
            if (x==skillsCollection.Count)
            {
                throw new AssertionException("No such element");
            }
            
            







        }
    }
}
