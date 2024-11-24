using AutomationTestProject_SwagLabsApp.Pages;

namespace AutomationTestProject_SwagLabsApp.Tests
{
    [TestFixture]
    public class LoginPageTests : BaseTest
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            Login("standard_user", "secret_sauce");

            Assert.That(inventoryPage.IsPageLoaded(), Is.True, "The inventory page did not load after login with valid credentials.");
    }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            Login("invalid_user", "invalid_password");
                
            string errorMessage = loginPage.GetErrorMessage();
                
            Assert.That(errorMessage, Contains.Substring("Epic sadface: Username and password do not match any user in this service"));
        }

        [Test]
        public void LoginWithLockedOutUser()
        {
            Login("locked_out_user", "secret_sauce");

            string errorMessage = loginPage.GetErrorMessage();
                
            Assert.That(errorMessage, Contains.Substring("Epic sadface: Sorry, this user has been locked out."));
        }
    }
 }