using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    public class MainPage : BasePage
    {
        private By DressesBtn = By.XPath("//a[contains(@title, 'Log')]");
        private By Blouse = By.CssSelector("img[title='Blouse']");
        private By AddToCartButton = By.CssSelector("a[data-id-product='2']");

        public SignInPage ClickOnSignIn()
        {
            Click(DressesBtn);
            return new SignInPage();
        }

        public MainPage MouseOverBlouse()
        {
            MouseOver(Blouse);
            return this;
        }

        public ConfirmationBuyingPage ClickAddToCartButton()
        {
            Click(AddToCartButton);
            return new ConfirmationBuyingPage();
        }
    }
}
