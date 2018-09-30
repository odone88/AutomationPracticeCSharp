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
        private By dressesBtn = By.XPath("//a[contains(@title, 'Log')]");

        public SignInPage ClickOnSignIn()
        {
            Click(dressesBtn);
            return new SignInPage();
        }



    }
}
