using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutamationGmail.Pages
{
    class MainPage : AbstractPage
    {

        #region Elements
        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji T-I-KE L3']")]
        private IWebElement сomposeButton;

        [FindsBy(How = How.XPath, Using = "//textarea[@class='vO'][@aria-label='To']")]
        private IWebElement destinationField;

        [FindsBy(How = How.XPath, Using = "//input[@class='aoT']")]
        private IWebElement objectField;

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji aoO T-I-atl L3']")]
        private IWebElement sendMessageButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='gb_A gb_8 gb_f gb_2']")]
        private IWebElement popupWindow;

        [FindsBy(How = How.XPath, Using = "//a[@class='gb_0b gb_6b gb_V']")]
        private IWebElement signOutButton;

        [FindsBy(How = How.XPath, Using = "//tr[@class='zA zE']")]
        private IWebElement newLetter;

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji nN T-I-ax7 T-I-Js-Gs T-I-Js-IF ar7']")]
        private IWebElement spamReportButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='asa']")]
        private IWebElement refreshButton;

        [FindsBy(How = How.XPath, Using = "//img[@class='hA T-I-J3']")]
        private IWebElement openListButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='cj'][@act='9']")]
        private IWebElement spamButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='cj'][@act='11']")]
        private IWebElement deleteButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='gbqfq']")]
        private IWebElement searchField;

        [FindsBy(How = How.XPath, Using = "//button[@id='gbqfb']")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//td[@class='anO anN']/span")]
        private IWebElement getEmail;

        [FindsBy(How = How.XPath, Using = "//div[@class='T-Jo-auh'][@role='presentation']")]
        private IWebElement markAllLettersButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='ar9 T-I-J3 J-J5-Ji']")]
        private IWebElement deleteMarkedLettersButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='xS']")]
        private IWebElement letterLocator;

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji aFk T-I-ax7   ar7'][@role='button']")]
        private IWebElement removeFromSpamButton;

        [FindsBy(How = How.XPath, Using = "//span[@class='gb_Fa']")]
        public IWebElement gmailLocator;

        #endregion

        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().Refresh();

        }

        //public void SendMessage(string destinationAdress)
        //{
        //    Utils.WaitSomeElement waitSomeElement = new Utils.WaitSomeElement(driver);
        //    сomposeButton.Click();
        //    destinationField.SendKeys(destinationAdress);
        //    objectField.SendKeys(Tools.RandomTextGenerator.GetRandomString(15));
        //    driver.SwitchTo().Frame(10);
        //    messageField.SendKeys(Tools.RandomTextGenerator.GetRandomString(45));
        //    driver.SwitchTo().ParentFrame();
        //    sendMessageButton.Click();

        //}

        public void SendMessage(string destinationAdress)
        {
            Utils.WaitSomeElement waitSomeElement = new Utils.WaitSomeElement(this.driver);
            //GoToInboxFolder();
            //waitSomeElement.WaitElement(gmailLocator,10);
            сomposeButton.Click();
            destinationField.SendKeys(destinationAdress);
            objectField.SendKeys(Tools.RandomTextGenerator.GetRandomString(15));
            sendMessageButton.Click();
        }

        public void MarkLetterAsSpam()
        {
            newLetter.Click();
            spamReportButton.Click();
        }

        public void SignOut()
        {
            Utils.AlertChecker alertChecker = new Utils.AlertChecker(this.driver);
            alertChecker.AlertCheck();
            driver.Manage().Cookies.DeleteAllCookies();
            alertChecker.AlertCheck();
            OpenPage();
            driver.Manage().Cookies.DeleteAllCookies();
            OpenPage();
            OpenPage();
        }

        public void GoToSpamFolder()
        {
            Utils.AlertChecker alertChecker = new Utils.AlertChecker(this.driver);
            alertChecker.AlertCheck();
            driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/#spam");
        }
        public void ReportAsSpam()
        {
            Utils.WaitSomeElement waitSomeElement = new Utils.WaitSomeElement(this.driver);

            waitSomeElement.WaitElement(newLetter, 15);
            newLetter.Click();
            openListButton.Click();
            spamButton.Click();
        }

        public void CheckUnreadLetterInSpamFolder()
        {
            Utils.WaitSomeElement waitSomeElement = new Utils.WaitSomeElement(this.driver);
            waitSomeElement.WaitElement(newLetter, 15);
            newLetter.Click();
        }

        public void DeleteAllLetters()
        {
            Utils.WaitSomeElement waitSomeElement = new Utils.WaitSomeElement(this.driver);
            OpenPage();
            waitSomeElement.WaitElement(gmailLocator, 5);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            try
            {
                if (letterLocator.Displayed)
                {
                    markAllLettersButton.Click();
                    deleteMarkedLettersButton.Click();
                }

            }
            catch (Exception e)
            {
                if (e is ElementNotVisibleException || e is NoSuchElementException)
                {
                }
            }
        }
        public string GetFirstUserNameEmail()
        {
            return getEmail.GetAttribute("title");
        }
        public void GoToInboxFolder()
        {
            Utils.AlertChecker alertChecker = new Utils.AlertChecker(this.driver);
            Utils.WaitSomeElement waitSomeElement = new Utils.WaitSomeElement(this.driver);
            alertChecker.AlertCheck();
            driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/#inbox");
            waitSomeElement.WaitElement(gmailLocator, 5);
        }

        public void UnmarkLettersAsSpam()
        {
            Utils.WaitSomeElement waitSomeElement = new Utils.WaitSomeElement(this.driver);
            OpenPage();
            waitSomeElement.WaitElement(gmailLocator, 5);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            try
            {
                if (letterLocator.Displayed)
                {
                    markAllLettersButton.Click();
                    removeFromSpamButton.Click();
                }
            }
            catch (Exception e)
            { }
        }
    }
}