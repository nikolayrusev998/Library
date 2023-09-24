using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Pages
{
    public class CreateNewBookPage
    {
        private readonly IWebDriver _driver;

        public CreateNewBookPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//input[@id='Name']")]
        private IWebElement createBookNameInputField {  get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#Author")]
        private IWebElement createBookAuthorInputField { get; set; }


        [FindsBy(How = How.CssSelector, Using = "input#Genre")]
        private IWebElement createBookGenreInputField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#Quontity")]
        private IWebElement createBookQuantityInputField {  get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='Create']")]
        private IWebElement createBookButton {  get; set; }

        [FindsBy(How = How.LinkText, Using = "Back to List")]
        private IWebElement createBookBackToList {  get; set; }

        public CreateNewBookPage fillBookName (String bookName)
        {
            createBookNameInputField.Clear();
            createBookNameInputField.SendKeys(bookName);
            return this;
        }

        public CreateNewBookPage fillAuthorName (String authorName)
        {
            createBookAuthorInputField.Clear();
            createBookAuthorInputField.SendKeys(authorName);
            return this;
        }

        public CreateNewBookPage fillGenre(String genre)
        {
            createBookGenreInputField.Clear();
            createBookGenreInputField.SendKeys(genre);
            return this;
        }

        public CreateNewBookPage fillQuantity (String quantity)
        {
            createBookQuantityInputField.Clear();
            createBookQuantityInputField.SendKeys(quantity);
            return this;
        }

        public CreateNewBookPage clickOnCreateBookButton()
        {
            createBookButton.Click();
            return this;
        }

        public CreateNewBookPage clickOnBooksBackToTheList()
        {
            createBookBackToList.Click();
            return this;
        }

    }
}
