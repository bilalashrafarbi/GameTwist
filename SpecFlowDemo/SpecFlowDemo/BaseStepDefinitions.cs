using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowDemo
{
   public class BaseStepDefinitions
    {

        public IWebDriver Driver { get; set; }
      

        [BeforeScenario]
        public void SetupTest()
        {


            var options = new ChromeOptions();

            options.AddArguments("chrome.switches", "--disable-notifications  --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            this.Driver = new ChromeDriver(options);
            this.Driver.Manage().Timeouts().PageLoad=TimeSpan.FromSeconds(90);
         
        }

        [AfterScenario]
        public void AfterScenario()
        {
            this.Driver.Close();
        }
    }
}
