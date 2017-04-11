using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlowDemo.PageObjects
{
    class LoginPageObject
    {

        private  IWebDriver driver;
        public LoginPageObject(IWebDriver driver)
        {
          this.driver = driver;
         PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "login-nickname")]
        public IWebElement textboxusername;

        [FindsBy(How = How.Id, Using = "login-password")]
        public IWebElement textboxpassword;

        [FindsBy(How = How.XPath, Using = "(//button[@class='btn btn--primary']/span)[1]")]
        public IWebElement btnlogin;

        public void OpenWebsite(string url)
        {
            this.driver.Url = url;
        }

        public void EnterTheUsernameAndPassword(string username, string password)
        {
            textboxusername.SendKeys(username);
            textboxpassword.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            btnlogin.Click();
        }
    }
}
