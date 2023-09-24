using Library.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Library.Tests
{
    [TestFixture]
    public class Tests
    {

        private IWebDriver driver;

        private string baseUrl = "https://qa-task.immedis.com/";

        LoginPage loginPage;
        BooksPage booksPage;
        CreateNewBookPage createNewBookPage;
        CreateNewGetABookPage createNewGetABookPage;
        CreateUserPage createUserPage;
        GetABookPage getABookPage;
        MainMenu mainMenu;
        UsersPage usersPage;





        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage = new LoginPage(driver);
            booksPage = new BooksPage(driver);
            mainMenu = new MainMenu(driver);
            usersPage = new UsersPage(driver);
            getABookPage = new GetABookPage(driver);
            createNewGetABookPage = new CreateNewGetABookPage(driver);
            createUserPage = new CreateUserPage(driver);
            createNewBookPage = new CreateNewBookPage(driver);


        }

        [Test, Order(1)]

        public void validCredentialsLogin()
        {
            loginPage.GetLoginPage();
            loginPage.FillUsername("admin");
            loginPage.FillPassword("123456");
            loginPage.ClickSignInButton();
            mainMenu.checkMainMenuItems();


        }


        [Test, Order(2)]
        public void createNewUser()
        {
            loginPage
                .GetLoginPage()
                .FillUsername("admin")
                .FillPassword("123456")
                .ClickSignInButton();

            mainMenu
                .cookieAcceptBtn();


            mainMenu
                .clickUsers();

            usersPage.clickCreateNewUser();

            createUserPage.fillUsername("Automation user");
            createUserPage.clickOnCreateUserCreateButton();

        }

        [Test, Order(3)]
        public void createNewBook()
        {
            loginPage.GetLoginPage()
                .FillUsername("admin")
                .FillPassword("123456")
                .ClickSignInButton();

            mainMenu
                .cookieAcceptBtn()
                .clickBooks();

            booksPage
                .clickOnCreateNewBook();

            createNewBookPage
                .fillBookName("AutomationTest book name")
                .fillAuthorName("AutomationTest author name")
                .fillGenre("AutomationTest Genre")
                .fillQuantity("10")
                .clickOnCreateBookButton();
        }

        [Test, Order(4)]
        public void createNewGetABookRequest()
        {
            loginPage.GetLoginPage()
                .FillUsername("admin")
                .FillPassword("123456")
                .ClickSignInButton();

            mainMenu
                .cookieAcceptBtn()
                .clickGetABookButton();

            getABookPage
                .clickOnCreateNewGetABookPage();

            createNewGetABookPage
                .fillGetANewBookBookId("AutomationTest book name")
                .fillGetANewBookUserId("Automation user")
                .clickOnCreateButton();

            Assert.Pass();


        }
        [Test, Order(5)]
        public void createNewUser_Invalid_MoreThan100()
        {
            loginPage
                .GetLoginPage()
                .FillUsername("admin")
                .FillPassword("123456")
                .ClickSignInButton();

            mainMenu
                .cookieAcceptBtn();


            mainMenu
                .clickUsers();

            usersPage.clickCreateNewUser();

            createUserPage.fillUsername("AutoTest1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
            createUserPage.clickOnCreateUserCreateButton();

            Assert.Fail();

        }

        [Test, Order(6)]
        public void createNewUser_Invalid_Empty()
        {
            loginPage
                .GetLoginPage()
                .FillUsername("admin")
                .FillPassword("123456")
                .ClickSignInButton();

            mainMenu
                .cookieAcceptBtn();


            mainMenu
                .clickUsers();

            usersPage.clickCreateNewUser();

            createUserPage.fillUsername("");
            createUserPage.clickOnCreateUserCreateButton();

            Assert.Fail();

        }

        [Test, Order(7)]
        public void createNewBook_Invalid_EmptyName()
        {
            loginPage.GetLoginPage()
                .FillUsername("admin")
                .FillPassword("123456")
                .ClickSignInButton();

            mainMenu
                .cookieAcceptBtn()
                .clickBooks();

            booksPage
                .clickOnCreateNewBook();

            createNewBookPage
                .fillBookName("")
                .fillAuthorName("AutomationTest author name")
                .fillGenre("AutomationTest Genre")
                .fillQuantity("10")
                .clickOnCreateBookButton();

            Assert.Fail();

        }

        [Test, Order(8)]
        public void createNewBook_Invalid_EmptyAuthor()
        {
            loginPage.GetLoginPage()
                .FillUsername("admin")
                .FillPassword("123456")
                .ClickSignInButton();

            mainMenu
                .cookieAcceptBtn()
                .clickBooks();

            booksPage
                .clickOnCreateNewBook();

            createNewBookPage
                .fillBookName("AutomationTest book name")
                .fillAuthorName("")
                .fillGenre("AutomationTest Genre")
                .fillQuantity("10")
                .clickOnCreateBookButton();

            Assert.Fail();

        }

        [Test, Order(9)]
        public void createNewBook_Invalid_EmptyGenre()
        {
            loginPage.GetLoginPage()
                .FillUsername("admin")
                .FillPassword("123456")
                .ClickSignInButton();

            mainMenu
                .cookieAcceptBtn()
                .clickBooks();

            booksPage
                .clickOnCreateNewBook();

            createNewBookPage
                .fillBookName("AutomationTest book name")
                .fillAuthorName("AutomationTest author name")
                .fillGenre("")
                .fillQuantity("10")
                .clickOnCreateBookButton();

            Assert.Fail();
        }

        [Test, Order(10)]
        public void createNewBook_Invalid_EmptyQuantity()
        {
            loginPage.GetLoginPage()
                .FillUsername("admin")
                .FillPassword("123456")
                .ClickSignInButton();

            mainMenu
                .cookieAcceptBtn()
                .clickBooks();

            booksPage
                .clickOnCreateNewBook();

            createNewBookPage
                .fillBookName("AutomationTest book name")
                .fillAuthorName("AutomationTest author name")
                .fillGenre("AutomationTest author name")
                .fillQuantity("")
                .clickOnCreateBookButton();

            var errorMsg = driver
                .FindElement(By.CssSelector("#Quontity-error"));

            Assert.That(errorMsg.Displayed);

        }




        [TearDown]
        public void CloseBrowser()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Quit();
        }
    }
}