using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    public class Tests
    {
        public ChromeDriver Browser { get; private set; }

        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Test1()
        {
           

            

            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();

            //should open headless chrome
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");

            driver.Navigate().GoToUrl("https://staging.admin.emerchantpay.net/task_logs");

            Thread.Sleep(1000);

            //Will check if login is required
            if (driver.FindElement(By.Id(@"admin_user_login")).Displayed == true)
            {
                driver.FindElement(By.Id(@"admin_user_login")).SendKeys("zzhelev");

                driver.FindElement(By.Id(@"admin_user_password")).SendKeys("************}");

                driver.FindElement(By.CssSelector(@"#new_admin_user > div > div:nth-child(3) > input")).Click();
            }
           
            for (int i = 0; i < 3; i++)
            {

                ////This will find the element in Task Logs and will copy the information
                 
                string elementTaskLogs = driver.FindElement(By.XPath("/html/body/div[2]/div[2]")).Text;

                ////creates a csv file and pastes the containing of Task Logs copied previously
                string pathTaskLogs = @"C:\Users\zhelevz\Desktop\multiverse-master\TXT files\TaskLogsPSP-STG.csv";

                File.Delete(pathTaskLogs);

                Thread.Sleep(1000);

                if (!File.Exists(pathTaskLogs))
             {
               using (StreamWriter sw = File.CreateText(pathTaskLogs))
             {
                 sw.WriteLine(elementTaskLogs);
                }
            }
                    else
                    {
                        continue;
                    }
                

                Thread.Sleep(1000);
                {
                    ///Here it starts for the TRANSACTION ATTEMPTS
                    //driver.Navigate().GoToUrl("https://staging.admin.emerchantpay.net/api_logs/transaction_attempts");

                    ////This will find the element in transaction attempts and will copy the information

                    //  if (driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[3]/div[2]")).Displayed == true)
                    //{
                    //      var elementTransactionAttempts = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[3]/div[2]")).Text;

                    ////creates a json file and pastes the containing of transaction attempts copied previously
                    //  string pathTransactionAttempts = @"C:\Users\zhelevz\Desktop\multiverse-master\TXT files\TransactionAttemptsPSP-STG.csv";

                    // File.Delete(pathTransactionAttempts);

                    //  Thread.Sleep(1000);

                    //  if (!File.Exists(pathTransactionAttempts))
                    //  {
                    // using (StreamWriter sw = File.CreateText(pathTransactionAttempts))
                    // {
                    //  sw.WriteLine(elementTransactionAttempts);
                    //  }
                    //    }
                    // else
                    // {
                    //continue;
                    //     }

                    //}
                    //Thread.Sleep(1000);
                    ///Here it starts for the NOTIFICATIONS
                    // driver.Navigate().GoToUrl("https://staging.admin.emerchantpay.net/notifications/index?utf8=%E2%9C%93&cond%5Bpayment_unique_id%5D=&value%5Bpayment_unique_id%5D=&search%5Bstatus_in%5D%5B%5D=&search%5Bstatus_in%5D%5B%5D=new&search%5Bstatus_in%5D%5B%5D=in_progress&search%5Bcreated_at_gteq%5D=&search%5Bcreated_at_lteq%5D=&search%5Btype_in%5D%5B%5D=WpfNotification&search%5Btype_in%5D%5B%5D=ProcessingNotification&search%5Btype_in%5D%5B%5D=TransactionApmExternalEventNotification&search%5Btype_in%5D%5B%5D=FourStopKycServiceNotification&search%5Btype_in%5D%5B%5D=GeneralApmExternalEventNotification&add_filter=default&commit=Search");

                    ////This will find the element in notifications and will copy the information

                    // if (driver.FindElement(By.XPath("html/body/div[2]/div[2]/div/div[3]/div[1]")).Displayed == true)
                    // {
                    //  var elementNotifications = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div[3]/div[1]")).Text;

                    ////creates a json file and pastes the containing of notifications copied previously
                    // string pathNotifications = @"C:\Users\zhelevz\Desktop\multiverse-master\TXT files\NotificationsPSP-STG.csv";

                    //File.Delete(pathNotifications);

                    //Thread.Sleep(1000);

                    // if (!File.Exists(pathNotifications))
                    //  {
                    //using (StreamWriter sw = File.CreateText(pathNotifications))
                    // {
                    // sw.WriteLine(elementNotifications);
                    //  }
                    //  }
                    //    }
                    //     else
                    // {
                    //continue;
                    //}
                    //Thread.Sleep(1000);

                    ///Here it starts for the Declined 24 Hours
                    // driver.Navigate().GoToUrl("https://staging.admin.emerchantpay.net/system_status/index");

                    ////This will find the element in declines 24h and will copy the information

                    // if (driver.FindElement(By.CssSelector("#system_status_declined_reasons > div > div.table-responsive > table")).Displayed == true)

                    // { 
                    //var declined24 = driver.FindElement(By.CssSelector("#system_status_declined_reasons > div > div.table-responsive > table")).Text;

                    ////creates a json file and pastes the containing of Declined 24h table copied previously
                    //string path24 = @"C:\Users\zhelevz\Desktop\multiverse-master\TXT files\24hoursPSP-STG.json";

                    //File.Delete(path24);

                    // Thread.Sleep(1000);

                    //    if (!File.Exists(path24))
                    //    {
                    //        using (StreamWriter sw = File.CreateText(path24))
                    //       {
                    //          sw.WriteLine(declined24);
                    //     }

                    //  }

                    //}

                    Thread.Sleep(5000);

                      driver.Quit();
                }

            }
  
        }

    }
}
