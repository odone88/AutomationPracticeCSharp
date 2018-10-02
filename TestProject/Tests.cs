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
            //test = extent.CreateTest("blabla1");
            MainPage mainPage = new MainPage();
            SignInPage signInPage = mainPage.ClickOnSignIn();
            MyAccountPage myAccountPage = signInPage.enterEmailAndPasswordAndClickOk();
            Assert.IsTrue(myAccountPage.CheckIfOrderExits());
        }

        [Test]
        public void ShouldUserSignOut()
        {
            //test = extent.CreateTest("blabla2");
            MainPage mainPage = new MainPage();
            SignInPage signInPage = mainPage.ClickOnSignIn();
            MyAccountPage myAccountPage = signInPage.enterEmailAndPasswordAndClickOk();
            SignInPage signInPage2 = myAccountPage.SignOut();
            Assert.IsTrue(signInPage2.IfSignInExists());
        }

        [Test]
        public void ShouldUserAddBlouseToTheCart()
        {
            MainPage mainPage = new MainPage();
            ConfirmationBuyingPage confirmationBuyingPage = mainPage.MouseOverBlouse().ClickAddToCartButton();
            ShoppingCartSummaryPage shoppingCartSummaryPage = confirmationBuyingPage.ClickOnProceedToCheckoutBtn();
            Assert.AreEqual("1", shoppingCartSummaryPage.getQuantityOfAddedElements(), "Item was not added to the cart. Please investigate.");
        }
    }
}
