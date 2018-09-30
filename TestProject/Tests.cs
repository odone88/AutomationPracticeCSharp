using TestFramework.Pages;
using TestFramework;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public void ShouldUserSignIn()
        {
            test = extent.CreateTest("blabla1");
            MainPage mainPage = new MainPage();
            SignInPage signInPage = mainPage.ClickOnSignIn();
            MyAccountPage myAccountPage = signInPage.enterEmailAndPasswordAndClickOk();
            Assert.IsTrue(myAccountPage.CheckIfOrderExits());
        }

        [Test]
        public void ShouldUserSignOut()
        {
            test = extent.CreateTest("blabla1");
            MainPage mainPage = new MainPage();
            SignInPage signInPage = mainPage.ClickOnSignIn();
            MyAccountPage myAccountPage = signInPage.enterEmailAndPasswordAndClickOk();
            SignInPage signInPage2 = myAccountPage.SignOut();
            Assert.IsTrue(signInPage2.IfSignInExists());
        }
    }
}
