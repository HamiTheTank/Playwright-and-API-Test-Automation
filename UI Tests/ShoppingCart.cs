using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Test__Playwright_
{
    internal class ShoppingCart
    {

        private readonly IPage _page;
        private readonly ILocator _checkoutBtn;
        private readonly ILocator _firstNameInput;
        private readonly ILocator _lastNameInput;
        private readonly ILocator _zipCodeInput;
        private readonly ILocator _continueBtn;
        private readonly ILocator _finstBtn;
        private readonly ILocator _continueShoppingBtn;

        public ShoppingCart(IPage page)
        {
            _page = page;
            _checkoutBtn = page.Locator(Constants.checkoutBtn);
            _firstNameInput = _page.Locator(Constants.firstNameInput);
            _lastNameInput = _page.Locator(Constants.lastNameInput);
            _zipCodeInput = _page.Locator(Constants.zipCodeInput);
            _continueBtn = _page.Locator(Constants.continueBtn);
            _finstBtn = _page.Locator(Constants.finishBtn);
            _continueShoppingBtn = _page.Locator(Constants.continueShoppingBtn);
        }


        public async Task Checkout()
        {
            await _checkoutBtn.ClickAsync();
            await _page.WaitForURLAsync("**/checkout-step-one.html");
        }

        public async Task FillInfo()
        {
            await _firstNameInput.TypeAsync("firstname");
            await _lastNameInput.TypeAsync("lastname");
            await _zipCodeInput.TypeAsync("12345");
            await _continueBtn.ClickAsync();
            await _page.WaitForURLAsync("**/checkout-step-two.html");
        }

        public async Task ClickFinishBtn()
        {
            await _finstBtn.ClickAsync();
            await _page.WaitForURLAsync("**/checkout-complete.html");
        }

        public async Task<int> GetItemCount()
        {
            var cartItem = _page.Locator(Constants.cartItem);
            return await cartItem.CountAsync();
        }

        public async Task ClickContinueShoppingBtn()
        {
            await _continueShoppingBtn.ClickAsync();
        }

    }
}
