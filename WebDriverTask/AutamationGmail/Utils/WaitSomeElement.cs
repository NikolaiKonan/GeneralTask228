using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutamationGmail.Utils
{
    public class WaitSomeElement
    {
        IWebDriver driver;
        public WaitSomeElement(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void WaitElement(IWebElement webElement, int time)
        {
            try
            {
                if (webElement.Displayed) { }
        
            }
            catch (Exception e)
            {
                if (e is ElementNotVisibleException || e is NoSuchElementException)
                {
                    driver.Navigate().Refresh();
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(time));
                    WaitElement(webElement, time);
                }
            }
        }
    }
}
