using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlowDemo.PageObjects
{
    class SlotsPageObject
    {
         private  IWebDriver driver;
         public SlotsPageObject(IWebDriver driver)
        {
          this.driver = driver;
         PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='CMSListMenuLinkHighlighted']")]
        public IWebElement selectedmenuitem;

        public void ValidateSelectedPage(string pagetitle)
        {
            Thread.Sleep(5000);
            Assert.IsTrue(selectedmenuitem.Text.Contains(pagetitle), pagetitle + "is not opened");
            String currentURL = driver.Url;
            Assert.IsTrue(currentURL.Contains(pagetitle.ToLower()), pagetitle + "is not opened");
        }
    }
}
