using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Pages
{
    public class UsersPage
    {
        private readonly IWebDriver _driver;

        public UsersPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.LinkText, Using = ("Create New"))]
        private IWebElement createNewUser {  get; set; }

        public UsersPage clickCreateNewUser()
        {
            createNewUser.Click();
            return this;
        }

    }
}

   
