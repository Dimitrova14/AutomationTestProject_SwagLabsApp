using AutomationTestProject_SwagLabsApp.Pages;

namespace AutomationTestProject_SwagLabsApp.Tests
{
    [TestFixture]
    public class InventoryPageTests : BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            Login("standard_user", "secret_sauce");
        }

        [Test]
        public void VerifyInventoryItemsAreDisplayed()
        {
            Assert.That(inventoryPage.IsInventoryDisplayed(), Is.True, "Inventory items are not displayed.");
        }

        [Test]
        public void AddItemToCartByIndex()
        {
            inventoryPage.AddToCartByIndex(0);

            inventoryPage.ClickCartLink();

            Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "The item was not added to the cart.");
        }

        [Test]
        public void AddItemToCartByName()
        {
            inventoryPage.AddToCartByName("Sauce Labs Backpack"); 

            inventoryPage.ClickCartLink();

            Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "The item was not added to the cart.");
        }

        [Test]
        public void VerifyPageTitle()
        {
            Assert.That(inventoryPage.IsPageLoaded(), Is.True, "The inventory page did not load correctly.");
        }

        
    }
}
        
