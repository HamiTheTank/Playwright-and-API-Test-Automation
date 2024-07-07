using Microsoft.Playwright;

namespace UI_Test__Playwright_
{
    internal class InventoryPage
    {
        private readonly IPage _page;
        private readonly ILocator _shoppingCartIcon;
        private readonly ILocator _backpackAddtoCartBtn;
        private readonly ILocator _bikeAddtoCartBtn;
        private readonly ILocator _removeBackPackBtn;

        public InventoryPage(IPage page)
        {
            _page = page;
            _shoppingCartIcon = page.Locator(Constants.shoppingCartIcon);
            _backpackAddtoCartBtn = page.Locator(Constants.backpackAddtoCartBtn);
            _bikeAddtoCartBtn = page.Locator(Constants.bikeAddtoCartBtn);
            _removeBackPackBtn = page.Locator(Constants.removeBackPackBtn);
        }

        public async Task AddBackpackToCart()
        {
            await _backpackAddtoCartBtn.ClickAsync();
        }

        public async Task AddBikeToCart()
        {
            await _bikeAddtoCartBtn.ClickAsync();
        }

        public async Task ClickShoppingCart()
        {
            await _shoppingCartIcon.ClickAsync();
            await _page.WaitForURLAsync("**/cart.html");
        }

        public async Task ClickRemoveBackPackBtn()
        {
            await _removeBackPackBtn.ClickAsync();
        }

    }
}
