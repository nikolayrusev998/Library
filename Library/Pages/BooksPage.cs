using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Pages
{
    public class BooksPage
    {
        private readonly IWebDriver _driver;

        public BooksPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Create New")]
        private IWebElement createNewBook { get; set; }

        public BooksPage clickOnCreateNewBook()
        {
            createNewBook.Click();
            return this;
        }
    }
}
