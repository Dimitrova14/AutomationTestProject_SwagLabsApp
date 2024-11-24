using OpenQA.Selenium;
using AutomationTestProject_SwagLabsApp.Pages;

namespace AutomationTestProject_SwagLabsApp.Tests
{
    [TestFixture]
    public class CheckoutTests : BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            Login("standard_user", "secret_sauce");
            inventoryPage.AddToCartByIndex(0);
            inventoryPage.ClickCartLink();
            cartPage.ClickCheckout();
        }

        [Test]
        public void VerifyCheckoutPageIsDisplayed()
        {
            Assert.That(checkoutPage.IsPageLoaded(), Is.True, "The checkout page did not load correctly.");
        }

        [Test]
        public void VerifyContinueBtn()
        {
            string firstName = "John";
            string lastName = "Doe";
            string zipCode = "12345";

            checkoutPage.EnterFirstName(firstName);
            checkoutPage.EnterLastName(lastName);
            checkoutPage.EnterPostalCode(zipCode);
            checkoutPage.ClickContinue();

            Assert.That(driver.Url.Contains("checkout-step-two.html"), Is.True, "The user was not redirected to the next step in the checkout process.");
        }

        [Test]
        public void VerifyCompletingTheOrder()
        {
            string firstName = "John";
            string lastName = "Doe";
            string zipCode = "12345";

            checkoutPage.EnterFirstName(firstName);
            checkoutPage.EnterLastName(lastName);
            checkoutPage.EnterPostalCode(zipCode);
            checkoutPage.ClickContinue();

            checkoutPage.ClickFinish();

            Assert.That(driver.Url.Contains("checkout-complete.html"), Is.True, "The user was not redirected to the checkout complete page.");

            Assert.That(checkoutPage.IsCheckoutComplete(), Is.True, "The order completion message was not displayed.");
        }
    }
}