using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    public class SignInPage : BasePage
    {
        private By emailTxt = By.Id("email");

        private By passwordTxt = By.Id("passwd");

        

        public MyAccountPage enterEmailAndPasswordAndClickOk()
        {
            SendTextToElement(emailTxt, "zzz@z.com");
            SendTextToElement(passwordTxt, "zzzzz");
            Click(signInBtn);
            return new MyAccountPage();

        }

        public bool IfSignInExists()
        {
            return IfElementVisible(signInBtn);
        }
    }
}
