using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowDemo.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDemo
{

    [Binding]
    public class GameTwistSteps : BaseStepDefinitions
    {

        LoginPageObject objlogin;
        HomePageObject objhome;
        SlotsPageObject objSlots;

        [Given(@"I open url as '(.*)'")]
        public void OpenUrlAs(string url)
        {
            objlogin = new LoginPageObject(this.Driver);
            objhome = new HomePageObject(this.Driver);
            objSlots = new SlotsPageObject(this.Driver);
            objlogin.OpenWebsite(url);
        }

        [When(@"I enter username '(.*)' and password '(.*)'")]
        public void EnterPasswordAndUsername(string username, string password)
        {
            objlogin.EnterTheUsernameAndPassword(username, password);
        }
        
        [When(@"I click on Login Button")]
        public void ClickOnLoginButton()
        {
            objlogin.ClickLoginButton();
        }

        [Then(@"I should see home page for game twist with nickname as '(.*)'")]
        public void CheckHomePageForGameTwist(string nickname)
        {
            objhome.ValidateHomePageForGameTwist(nickname);
        }

        [When(@"I click on Slots link")]
        public void ClickSlotsLink()
        {
            objhome.ClickOnSlotsLink();
        }

        [When(@"I click on Bingo link")]
        public void ClickBingoLink()
        {
            objhome.ClickOnBingoLink();
        }

        [When(@"I click on Casino link")]
        public void ClickCasinoLink()
        {
            objhome.ClickOnCasinoLink();
        }

        [When(@"I click on Poker link")]
        public void ClickPokerLink()
        {
            objhome.ClickOnPokerLink();
        }


        [When(@"I search for game '(.*)' from search game section")]
        public void SearchTheGame(string gamename)
        {
            objhome.SearchGame(gamename);
        }

        [Then(@"I should be navigated to '(.*)' page")]
        public void CheckSlotsPage(string pagetitle)
        {
            objSlots.ValidateSelectedPage(pagetitle);
        }

        [Then(@"I change language to German")]
        public void  ChangeTheLanguage()
        {
            objhome.ChangeLanguage();
        }

        [Then(@"I select and validate the selected game")]
        public void  SelectAndValidateTheGame()
        {
            objhome.SelectAndValidateGame();
        }

        [Then(@"I logout from application")]
        public void LogoutFromTheApplication()
        {
            objhome.LogoutFromApplication();
        }
    }
}
