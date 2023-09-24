using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Library.Pages
{
    public class CreateUserPage
    {
        private readonly IWebDriver _driver;

        public CreateUserPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input#Name")]
        private IWebElement createUserNameInputFiedl {  get; set; } 

        [FindsBy(How = How.CssSelector, Using = "input[value='Create']")]
        private IWebElement createUserCreateButton {  get; set; }

        [FindsBy(How = How.LinkText, Using = "Back to List")]
        private IWebElement createUserBackToList { get; set; }

        public CreateUserPage fillUsername(String username)
        {

            createUserNameInputFiedl.SendKeys(username);
            return this;
            
        }

        public CreateUserPage clickOnCreateUserCreateButton()
        {
            createUserCreateButton.Click();
            return this;
        }

        public CreateUserPage clickOnbackToTheListButton()
        {
            createUserBackToList.Click();
            return
                this;
        }

        
    }
}
