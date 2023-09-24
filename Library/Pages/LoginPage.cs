using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Library.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='username']")]
        private IWebElement usernameField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement passwordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[.='Sign In']")]
        private IWebElement signInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[.='Sign Up']")]
        private IWebElement signUpButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Here!")]
        private IWebElement forgotPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name='Error Message']")]
        private IWebElement errorMessage { get; set; }

        string baseUrl = "https://qa-task.immedis.com";

        public LoginPage GetLoginPage()
        {
            _driver.Navigate().GoToUrl(baseUrl);
            return this;
        }

        public LoginPage FillUsername(string username)
        {
            usernameField.Clear();
            usernameField.SendKeys(username);
            return this;
        }

        public LoginPage FillPassword(string password)
        {
            passwordField.SendKeys(password);
            return this;
        }

        public LoginPage ClickSignInButton()
        {
            signInButton.Click();
            return this;
        }

        public LoginPage ClickSignUpButton()
        {
            signUpButton.Click();
            return this;
        }

        public LoginPage ClickForgotPassword()
        {
            forgotPassword.Click();
            return this;
        }

        public LoginPage checkErrorMessage()
        {
            Assert.True(errorMessage != null);
            return this;
        }
    }
}
