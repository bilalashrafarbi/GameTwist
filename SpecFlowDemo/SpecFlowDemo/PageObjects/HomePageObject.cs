using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlowDemo.PageObjects
{
    class HomePageObject
    {
         private  IWebDriver driver;

         public HomePageObject(IWebDriver driver)
        {
          this.driver = driver;
         PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "nickname")]
        public IWebElement labelnickname;

        [FindsBy(How = How.ClassName, Using = "js-logout")]
        public IWebElement lnklogout;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/games/slots/')]")]
        public IWebElement linkslots;

        [FindsBy(How = How.XPath, Using = "(//div[@class='select-language flyout'])[2]/span")]
        public IWebElement languagebutton;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/games/bingo/')]")]
        public IWebElement linkbingo;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_cphNavAndSearch_ctl01_gameSearch']")]
        public IWebElement txtboxsearch;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/games/casino/')]")]
        public IWebElement linkcasino;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/games/poker/')]")]
        public IWebElement linkpoker;

        [FindsBy(How = How.ClassName, Using = "btn btn--secondary js-cookie-accept-btn")]
        public IList<IWebElement> btnsessionaccept;

        [FindsBy(How = How.XPath, Using = "//ol[@class='nav breadcrumb']")]
        public IWebElement gamebreadcrumb;

        public void ValidateHomePageForGameTwist(string nickname)
        {
            Thread.Sleep(5000);

            IList<IWebElement> popupcloseicon = driver.FindElements(By.Id("wof_close_x"));
            IList<IWebElement> acceptcookie = driver.FindElements(By.ClassName("js-cookie-accept-btn"));

            if (popupcloseicon.Count > 0)
            {
                popupcloseicon[0].Click();
            }

            if (acceptcookie.Count > 0)
            {
                acceptcookie[0].Click();
            }

            Assert.IsTrue(labelnickname.Text.Contains(nickname), nickname + "is not visible");
        
        }

        public void ClickOnSlotsLink()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(ExpectedConditions.ElementToBeClickable(linkslots));
            linkslots.Click();
        }

        public void SelectAndValidateGame()
        {
            IList<IWebElement> gamesCount = driver.FindElements(By.XPath("//ul[contains(@class,'js-game-search-list')]/li"));
            String secondgamename = gamesCount[2].Text;
            gamesCount[2].Click();
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(ExpectedConditions.ElementToBeClickable(gamebreadcrumb));
            Assert.IsTrue(gamebreadcrumb.Text.Contains(secondgamename), "Correct game is not selected");
        }

        public void ClickOnBingoLink()
        {
            linkbingo.Click();
        }

        public void ClickOnCasinoLink()
        {
            linkcasino.Click();
        }

        public void SearchGame(string game)
        {
            txtboxsearch.SendKeys(game);
            Thread.Sleep(5000);
        }

        public void ClickOnPokerLink()
        {
            linkpoker.Click();
        }

        public void ChangeLanguage()
        {
            Thread.Sleep(5000);
            Actions action = new Actions(driver);
            action.ContextClick(txtboxsearch).Perform();
             Thread.Sleep(5000);
            Actions builder = new Actions(driver);
            builder.MoveToElement(languagebutton).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("(//a[@data-lang='de'])[2]/b")).Click();
        }

        public void LogoutFromApplication()
        {
            Thread.Sleep(5000);
            labelnickname.Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", lnklogout);  
        }
    }
}
