using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Assignment.hooks
{
    [Binding]
    public sealed class BrowserHook
    {
        private static ExtentReports extentReports;
        private static ExtentHtmlReporter extentHtmltReporter;
        private static ScenarioContext _scenarioContext;
        private static FeatureContext _featureContext;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        [BeforeTestRun]
        public static void Before_test_run()
        {
            extentHtmltReporter = new ExtentHtmlReporter(@"C:\Data\Log\Test_Result.html");
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmltReporter);
        }

        [BeforeFeature]
        public static void Before_feature(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                _feature = extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }



        [BeforeScenario]
        public static void BeforeScenarioWithTag()
        {
            Base.driver = new ChromeDriver();
            Base.driver.Manage().Window.Maximize();
            Base.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [BeforeScenario]
        public static void Before_scenario(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
        }

        [AfterStep]
        public static void afterEachstep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                    break;



                case ScenarioBlock.When:
                    _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                    break;



                case ScenarioBlock.Then:
                    _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                    break;



                default:
                    _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                    break;
            }
        }


        [AfterTestRun]
        public static void aftertest()
        {
            extentReports.Flush();
        }


        [AfterScenario]
        public void AfterScenario()
        {
            
        }
    }
}