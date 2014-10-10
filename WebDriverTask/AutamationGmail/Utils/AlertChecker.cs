using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutamationGmail.Utils
{
    public class AlertChecker
    {
        IWebDriver driver;
        public AlertChecker(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void AlertCheck()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                IAlert alert = driver.SwitchTo().Alert();
                if (driver.SwitchTo().Alert() != null)
                {
                    alert.Accept();
                }
            }
            catch (Exception e)
            {}
           
        }
    }
}
