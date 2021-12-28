using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Assignment
{
        public class Pageobjects
        {
            public IWebDriver driver;



            public Pageobjects(IWebDriver redriver)
            {
                driver = redriver;
                PageFactory.InitElements(redriver, this);
            }




        //[FindsBy(How = How.LinkText, Using = "Hello world!")]
        //public IWebElement Recent_post;
        [FindsBy(How = How.XPath, Using = "//li[@id='products_menu_item']")]
        IWebElement Product;

        [FindsBy(How = How.XPath, Using = "//*[@id='username']")]
         IWebElement Username;

        [FindsBy(How = How.XPath, Using = "//*[@id='password']")]
         IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//*[@id='Login']")]
         IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//div[@data-ngname='chart_0']/div/*[@class='ps-container']")]
        IWebElement Pipeline;


        [FindsBy(How = How.XPath, Using = "(//*[local-name()='svg']//*[name()='g' and @class='highcharts-series highcharts-series-0 highcharts-area-series'])[1]")]
        IWebElement Contextclick;

        public void productButton()
        {
            Product.Click();
        }

        public void username(string user)
        {
            Username.SendKeys(user);
        }
        public void pass(string pass)
        {
           Password.SendKeys(pass);
        }
        public void login()
        {
            LoginButton.Click();
        }
        public void YearPipeline()
        {
            Pipeline.Click();
        }

        public void context()
        {
            Contextclick.Click();
        }



    }
}

