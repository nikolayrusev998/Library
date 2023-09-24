using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Pages
{
    public class CreateNewGetABookPage
    {
        private readonly IWebDriver _driver;

        public CreateNewGetABookPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "select#UserId")]
        private IWebElement getANewBookUserIdField {  get; set; }


        [FindsBy(How = How.CssSelector, Using = "select#BookId")]
        private IWebElement getANewBookBookIdField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='Create']")]
        private IWebElement getANewBookCreateButton {  get; set; }

        [FindsBy(How = How.LinkText, Using = "Back to List")]
        private IWebElement getANewBookBackToList {  get; set; }

        public CreateNewGetABookPage fillGetANewBookUserId(String userId)
        {
            getANewBookUserIdField.Click();
            getANewBookUserIdField.SendKeys(userId);  
            return this;

        }

        public CreateNewGetABookPage fillGetANewBookBookId(String Bookid)
        {

            getANewBookBookIdField.Click();
            getANewBookBookIdField.SendKeys(Bookid); 
            return this;
        }

        public CreateNewGetABookPage clickOnCreateButton ()
        { 
            getANewBookCreateButton.Click();
            return this;
        }

       public CreateNewGetABookPage clickOnBackToListingButton()
        {
            getANewBookBackToList.Click();
            return this;
        }
    }
}
