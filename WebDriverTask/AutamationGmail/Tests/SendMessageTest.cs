using log4net;
using log4net.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutamationGmail.Tests
{
    class SendMessageTest
    {
        private string username1 = "testautamationkonon1@gmail.com";
        private string username2 = "testautamationkonon2@gmail.com";
        private string password = "TestAutamationKonon12";

        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void GoToLoginPage()
        {
            steps.InitBrowser();
        }

        [Test]
        public void SendMessage()
        {
            steps.LogIn(username1, password);
            steps.SendMessage(username2);
            steps.SignOut();
            steps.LogIn(username2, password);
            steps.ReportMessageAsSpam();
            steps.SignOut();
            steps.LogIn(username1, password);
            steps.SendMessage(username2);
            steps.SignOut();
                steps.LogIn(username2, password);
                steps.GoToSpamFolder();
                steps.CheckUnreadLetterInSpamFolder();
                Assert.AreEqual(username1, steps.GetFirstUserEmail());

            }

            [TearDown]
            public void LettersDestroyer()
            {
                steps.SignOut();
                steps.LogIn(username2, password);
                steps.DeleteAllLetters();
            }
        
    }
}
