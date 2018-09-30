using OpenQA.Selenium;

namespace TestFramework.Pages
{
    public class MyAccountPage : BasePage
    {
        private By OrderHistoryBtn = By.CssSelector("[title='Orders']");

        private By SignOutBtn = By.CssSelector("[title='Log me out']");

        public bool CheckIfOrderExits()
        {
            return IfElementVisible(OrderHistoryBtn);
        }

        public SignInPage SignOut()
        {
            Click(SignOutBtn);
            return new SignInPage();
        }

        

    }
}