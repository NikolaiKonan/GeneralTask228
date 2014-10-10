using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutamationGmail.Configuration;
using log4net;

namespace AutamationGmail.Steps
{
    public class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }


        public void LogIn(string username, string password)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.Login(username, password);
        }

        public void SendMessage(string destinationAdress)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.SendMessage(destinationAdress);
        }

        public void ReportMessageAsSpam() {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.ReportAsSpam();
        }

        public void SignOut() {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.SignOut();
        }

        public void GoToSpamFolder(){
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToSpamFolder();
    }

        public void CheckUnreadLetterInSpamFolder()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.CheckUnreadLetterInSpamFolder();
        }

        public string GetFirstUserEmail() {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.GetFirstUserNameEmail();
        }

        public void DeleteAllLetters() {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToSpamFolder();
            mainPage.UnmarkLettersAsSpam();
            mainPage.GoToInboxFolder();
            mainPage.DeleteAllLetters();
        }

    }
}
