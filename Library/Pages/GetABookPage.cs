using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Pages
{
    public class GetABookPage
    {
        private readonly IWebDriver _driver;

        public GetABookPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Create New")]
        private IWebElement createNewGetABook {  get; set; }

        public GetABookPage clickOnCreateNewGetABookPage()
        {
            createNewGetABook.Click();
            return this;    
        }
    }
}
