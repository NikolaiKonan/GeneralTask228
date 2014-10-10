using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutamationGmail.Pages
{
    public class LoginPage : AbstractPage
    {
            
        #region Locators
        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "Passwd")]
        private IWebElement inputPassword;


        [FindsBy(How = How.XPath, Using = "//input[@value='Sign in']")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.XPath, Using = "//a[@class='gb_A gb_8 gb_f gb_2']")]
        private IWebElement linkLoggedInUser;

        [FindsBy(How = How.XPath, Using = "//span[@class='gb_Fa']")]
        public IWebElement gmailLocator;
        #endregion

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }
        public void Login(string username, string password)
        {
            Utils.AlertChecker alertChecker = new Utils.AlertChecker(this.driver);
            Utils.WaitSomeElement waitSomeElement = new Utils.WaitSomeElement(this.driver);
            OpenPage();
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();
            waitSomeElement.WaitElement(gmailLocator, 5);
        }
    }
}
