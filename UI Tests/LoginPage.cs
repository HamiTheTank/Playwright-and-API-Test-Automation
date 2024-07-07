using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace UI_Test__Playwright_
{
    internal class LoginPage
    {

        private readonly IPage _page;
        private readonly ILocator _userNameTextBox;
        private readonly ILocator _passwordTextBox;
        private readonly ILocator _loginButton;

        public LoginPage(IPage page)
        {
            _page = page;
            _userNameTextBox = page.Locator(Constants.userNameTextBox);
            _passwordTextBox = page.Locator(Constants.passwordTextBox);
            _loginButton = page.Locator(Constants.loginButton);
        }

        public async Task GotoAsync()
        {
            await _page.GotoAsync(Constants.mainURL);            
        }

        public async Task Login(string username, string password)
        {
            await EnterCredentials(username, password);
            await ClickLoginBtn();
            await _page.WaitForURLAsync("**/inventory.html");
        }

        public async Task EnterCredentials(string username, string password)
        {
            await _userNameTextBox.TypeAsync(username);
            await _passwordTextBox.TypeAsync(password);
        }

        public async Task ClickLoginBtn()
        {
            await _loginButton.ClickAsync();
        }
    }
}
