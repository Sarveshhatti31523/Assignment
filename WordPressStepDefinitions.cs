using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace Assignment.WordPressStepDefinitions
{
    [Binding]
    public class WordPressStepDefinitions : Base
    {
        public Pageobjects rp;

        [Given(@"User Launch Chrome Browser")]
        public void GivenUserLaunchChromeBrowser()
        {
            rp = new Pageobjects(driver);
        }

        [When(@"User opens url  ""([^""]*)""")]
        public void WhenUserOpensUrl(string p0)
        {
            driver.Navigate().GoToUrl(p0);
        }

        [When(@"Hover on Product button and enter product as ""([^""]*)"" and verify the content")]
        public void WhenHoverOnProductButtonAndEnterProductAsAndVerifyTheContent(string productName)
        {
            var path = @"C:\Users\sarvesh.hatti\source\repos\Assignment\Json File\Json_Ex.json";
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(path));
            var list = jsonFile["Products"];
            for (int i = 0; i < list.Count; i++)
            {
                if ((list[i].ToString()).Equals(productName))
                {
                    rp.productButton();
                    Thread.Sleep(5000);
                    object a = driver.FindElement(By.XPath("//li/a/span[text()='" + productName + " ']"));
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                    executor.ExecuteScript("arguments[0].click();", a);
                    break;
                }
              
            }
        }

        [Then(@"verify the product as ""([^""]*)""")]
        public void ThenVerifyTheProductAs(string Product)
        {
            if (Product.Equals("Health"))
            {
                Assert.AreEqual("Healthcare & Life Sciences", driver.FindElement(By.XPath("//div[@class='leftnav-heading']/h2")).Text);
            }
            else if (Product.Equals("Customer 360"))
            {
                Assert.AreEqual("Meet Customer 360 with Slack.", driver.FindElement(By.XPath("//*[@id='meet-customer-360-with-slack']")).Text);
            }
            else if (Product.Equals("Platform"))
            {
                Assert.AreEqual("Salesforce Platform", driver.FindElement(By.XPath("//h2[@id='salesforce-platform']")).Text);
            }
            else if (Product.Equals("Financial Services"))
            {
                Assert.AreEqual("Financial Services", driver.FindElement(By.XPath("//*[@id='financial-services']")).Text);
            }
            else
            {
                Console.WriteLine("No such product found!!!");
            }
        }

        [Given(@"User Logs in Using ""([^""]*)""")]
        public void GivenUserLogsInUsing(string p0)
        {
            driver.Navigate().GoToUrl(p0);
        }

        [When(@"Uses email as ""([^""]*)"" and Password as ""([^""]*)""")]
        public void WhenUsesEmailAsAndPasswordAs(string user, string pass)
        {
            Thread.Sleep(5000);
            rp.username(user);
            rp.pass(pass);
            driver.FindElement(By.XPath("//*[@id='rememberUn']")).Click();
            rp.login();
            Thread.Sleep(15000);
            driver.FindElement(By.XPath("//*[@value='Verify']")).Click();
        }


        [When(@"User hovers on chart , user enters date as ""([^""]*)"" and able to see price")]
        public void WhenUserHoversOnChartUserEntersDateAsAndAbleToSeePrice(string p0)
        {
            Thread.Sleep(5000);
            Actions action = new Actions(driver);
            IWebElement element = driver.FindElement(By.XPath("(//*[local-name()='svg']//*[name()='g' and @class='highcharts-series highcharts-series-0 highcharts-area-series'])[1]"));
            //X and Y co-ordinates to hover through the graph
            int Y = (element.Size.Height) / 2;
            int X = (element.Size.Width) / 2;

            rp.context();
            //Date format DateTime(Year,Month,day,Hour,min,sec)
            //DateTime test = new DateTime(2021,12,28,2,10,0);
            //DateTime test1= new DateTime(2021,12,28,2,10, 0);


            for (int i = 0; i < element.Size.Width; i++)
            {

                action.MoveToElement(element, X + i, Y+i).Perform();
                string data = driver.FindElement(By.XPath("//div[@class=('highcharts-label highcharts-tooltip chart-tooltip highcharts-color-undefined')]/span/span[@class='date']")).Text;
                if (data == p0)
                {
                    Console.WriteLine(driver.FindElement(By.XPath("//div[@class=('highcharts-label highcharts-tooltip chart-tooltip highcharts-color-undefined')]/span/span[@class='price']")).Text);
                    break;
                }
                //if(data == test1.ToString("d MMM yyyy, HH:mm 'GMT+5:30'"))
                //{
                //    Console.WriteLine(driver.FindElement(By.XPath("//div[@class=('highcharts-label highcharts-tooltip chart-tooltip highcharts-color-undefined')]/span/span[@class='price']")).Text);
                //    break;
                //}

            }


        }

       


    }
}
