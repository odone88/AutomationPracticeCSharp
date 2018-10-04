using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestFramework
{
    public abstract class BasePage
    {
       
        protected By signInBtn = By.Id("SubmitLogin");

        protected Actions actions;


        public void Click(By by)
        {
            try
            {
                WaitForElement2(by, 20);
                DriverContext.Driver.FindElement(by).Click();
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                DriverContext.Driver.FindElement(by).Click();
            }

        }

        public void SendTextToElement(IWebDriver driver, By by, string text)
        {
            WaitForElement2(by, 20);
            DriverContext.Driver.FindElement(by).SendKeys(text);
        }

        public void SendTextToElement2(By by, string text)
        {
            WaitForElement2(by, 20);
            DriverContext.Driver.FindElement(by).SendKeys(text);
        }

        public void SelectElementByText(By by, string text)
        {
            WaitForElement2(by, 20);
            var productTypeDropdown = new SelectElement(DriverContext.Driver.FindElement(by));
            productTypeDropdown.SelectByText(text);
        }

        public void SelectElementByIndex(By by, int index)
        {
            WaitForElement2(by, 20);
            var productTypeDropdown = new SelectElement(DriverContext.Driver.FindElement(by));
            productTypeDropdown.SelectByIndex(index);
        }

        public void SelectElementByValue(By by, string value)
        {
            WaitForElement2(by, 20);
            var productTypeDropdown = new SelectElement(DriverContext.Driver.FindElement(by));
            productTypeDropdown.SelectByValue(value);
        }

        public IWebElement WaitForElement2(By elementSelector, int timeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(elementSelector));
                return DriverContext.Driver.FindElement(elementSelector);
            }
            catch (StaleElementReferenceException)
            {
                var wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(elementSelector));
                return DriverContext.Driver.FindElement(elementSelector);
            }

        }
        public bool IfElementVisible(By by)
        {
            if (DriverContext.Driver.FindElement(by).Displayed)
                return true;
            return false;
        }

        protected void MouseOver(By by)
        {
            WaitForElement2(by, 20);
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(DriverContext.Driver.FindElement(by)).Build().Perform();
        }

        protected string GetValueAttributeFromElement(By locator)
        {
            WaitForElement2(locator, 20);
            return DriverContext.Driver.FindElement(locator).GetAttribute("value");
        }
    }
}
