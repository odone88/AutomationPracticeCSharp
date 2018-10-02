using OpenQA.Selenium;

namespace TestFramework.Pages
{
    public class ConfirmationBuyingPage : BasePage
    {
        private By SuccessElement = By.XPath("//div[starts-with(@class, 'layer_cart_product')]//h2");

        private By ProceedToCheckoutBtn = By.XPath("//*[contains(text(), 'Proceed')]");

        public ShoppingCartSummaryPage ClickOnProceedToCheckoutBtn()
        {
            Click(ProceedToCheckoutBtn);
            return new ShoppingCartSummaryPage();
        }






    }
}