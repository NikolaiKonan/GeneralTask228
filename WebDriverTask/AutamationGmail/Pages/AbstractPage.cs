using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutamationGmail.Pages
{
    public abstract class AbstractPage
    {
        public const string BASE_URL = "https://accounts.google.com/ServiceLogin?service=mail&continue=https://mail.google.com/mail/";



        public abstract void OpenPage();
        
        public bool IsElementPresent(By locator)
        {
            return Configuration.DriverInstance.GetInstance().FindElements(locator).Count > 0;
        }

    }
}
