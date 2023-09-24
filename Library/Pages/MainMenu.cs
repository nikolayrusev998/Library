using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Pages
{
    public class MainMenu
    {

        private readonly IWebDriver _driver;

        public MainMenu(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }


        [FindsBy(How = How.LinkText, Using = "Library")]
        private IWebElement libraryButton {  get; set; }

        [FindsBy(How = How.LinkText, Using = "Users")]
        private IWebElement usersButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Books")]
        private IWebElement booksButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Get a book")]
        private IWebElement getABookButton { get; set; }

        [FindsBy(How = How.XPath, Using = " //div[@class='navbar-right']/button[@type='button']")]
        private IWebElement cookieAccept {  get; set; }


        public MainMenu checkMainMenuItems() 
        {
            Assert.AreEqual(libraryButton.Text, "Library");
            Assert.AreEqual(usersButton.Text, "Users");
            Assert.AreEqual(booksButton.Text, "Books");
            Assert.AreEqual(getABookButton.Text, "Get a book");
            return this;
        }

        public MainMenu clickLibrary()
        {
            libraryButton.Click();
            return this;
        }
        public MainMenu clickUsers() { usersButton.Click(); 
            return this; }
        public MainMenu clickBooks() {  booksButton.Click(); 
            return this; }
        public MainMenu clickGetABookButton() {  getABookButton.Click(); return this;}

        public MainMenu cookieAcceptBtn() { cookieAccept.Click(); return this;}
       


    }
}
