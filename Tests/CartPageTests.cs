using AutomationTestProject_SwagLabsApp.Pages;

namespace AutomationTestProject_SwagLabsApp.Tests
{
    [TestFixture]
    public class CartPageTests : BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            Login("standard_user", "secret_sauce");
            inventoryPage.AddToCartByIndex(0);
            inventoryPage.ClickCartLink();
        }

        [Test]
        public void VerifyCartItemIsDisplayed()
        {
            Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "The item was not displayed in the cart.");
        }

        [Test]
        public void VerifyCheckoutBtn()
        {
            cartPage.ClickCheckout();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-one.html"), "The checkout page did not load after clicking checkout.");
        }
    }
}
    

