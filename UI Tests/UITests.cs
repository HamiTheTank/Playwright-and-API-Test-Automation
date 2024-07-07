using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace UI_Test__Playwright_
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class UITests : PageTest
    {
        //SCENARIO 1# - incorrect login
        //SCENARIO 2# - add 1 item to cart, finish checkout
        //SCENARIO 3# - add 2 items to the cart, remove 1, check cart content

        [Test]
        public async Task LoginIncorrectCredentials()
        {
            //SETUP
            var loginPage = new LoginPage(Page);

            //ACT
            await loginPage.GotoAsync();
            await loginPage.EnterCredentials(Constants.standardUserName, Constants.incorrectPassword);
            await loginPage.ClickLoginBtn();

            //ASSERT
            var errorMessage = Page.Locator(Constants.errorMessageLocator);
            await Expect(errorMessage).ToContainTextAsync(Constants.errorMessageText);
        }


        [Test]
        public async Task TypicalWorkflow()
        {
            //SETUP
            var loginPage = new LoginPage(Page);
            var inventoryPage = new InventoryPage(Page);
            var shoppingCart = new ShoppingCart(Page);

            //ACT
            await loginPage.GotoAsync();
            await loginPage.Login(Constants.standardUserName, Constants.correctPassword);
            await inventoryPage.AddBackpackToCart();
            await inventoryPage.ClickShoppingCart();
            await shoppingCart.Checkout();  //step one
            await shoppingCart.FillInfo();  //step two
            await shoppingCart.ClickFinishBtn(); //checkout completed

            //ASSERT
            await Expect(Page).ToHaveURLAsync(new Regex(".*checkout-complete.*"));
            var backToHomeBtn = Page.Locator(Constants.backToHomeBtn);
            await Expect(backToHomeBtn).ToBeVisibleAsync();
        }

        [Test]
        public async Task TestRemoveItemWorks()
        {
            //SETUP
            var loginPage = new LoginPage(Page);
            var inventoryPage = new InventoryPage(Page);
            var shoppingCart = new ShoppingCart(Page);
            var cartItem = Page.Locator(Constants.cartItem);

            //ACT
            await loginPage.GotoAsync();
            await loginPage.Login(Constants.standardUserName, Constants.correctPassword);
            await inventoryPage.AddBackpackToCart();
            await inventoryPage.AddBikeToCart();
            await inventoryPage.ClickShoppingCart();
            await Expect(cartItem).ToHaveCountAsync(2);
            await shoppingCart.ClickContinueShoppingBtn();
            await inventoryPage.ClickRemoveBackPackBtn();

            //ASSERT
            await inventoryPage.ClickShoppingCart();
            await Expect(cartItem).ToHaveCountAsync(1);
        }
    }
}
