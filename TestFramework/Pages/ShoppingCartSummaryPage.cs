using OpenQA.Selenium;

namespace TestFramework.Pages
{
    public class ShoppingCartSummaryPage : BasePage 
    {

        private By QuantityOfAddedElements = By.CssSelector("[class*='cart_quantity_input']");


        public string getQuantityOfAddedElements()
        {
            return GetValueAttributeFromElement(QuantityOfAddedElements);
        }

    }
}