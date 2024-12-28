using Bogus;
using Enfinity_Automation.BaseTest;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity_Automation.PageObjects.HRMS.HRCore
{
    public class DesignationPage
    {
        private readonly IWebDriver _driver;
        public Faker faker;

        // Constructor
        public DesignationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Web Elements
        private IWebElement SetupsMenu => _driver.FindElement(By.XPath("//span[normalize-space()='Setups']"));
        private IWebElement DesignationMenu => _driver.FindElement(By.XPath("//span[normalize-space()='Designation']"));
        private IWebElement NewButton => _driver.FindElement(By.XPath("//span[normalize-space()='New']"));
        private IWebElement CodeField => _driver.FindElement(By.Name("Code"));
        private IWebElement NameField => _driver.FindElement(By.Name("Name"));
        private IWebElement SaveButton => _driver.FindElement(By.XPath("//span[normalize-space()='Save']"));
        private IWebElement filterCell => _driver.FindElement(By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[5]/div[1]/table[1]/tbody[1]/tr[2]/td[2]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]"));
        private IWebElement result => _driver.FindElement(By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[2]/span[1]/a[1]"));

        
        string designation = BaseClass.faker.Name.JobTitle();
        // Methods
        public void NavigateToDesignation()
        {
            SetupsMenu.Click();
            DesignationMenu.Click();
        }

        string code = "1005";
        string desg = "TestDesg5";
        //public void CreateDesignation()
        //{
        //    NewButton.Click();
        //    CodeField.SendKeys(code);
        //    NameField.SendKeys(desg);
        //    SaveButton.Click();
        //}


        public void ClkNewBtn()
        {
            NewButton.Click();
        }

        public void EnterCode(string code)
        {
            //faker = new Faker();
            CodeField.SendKeys(code);
            //CodeField.SendKeys(BaseClass.faker.Random.AlphaNumeric(5));
        }

        
        public void EnterDesignation(string desg)
        {
            NameField.SendKeys(desg);            
            //NameField.SendKeys(designation);
        }

        public void ClkSaveBtn()
        {
            SaveButton.Click();
        }


        public bool isDesgCreated()
        {
            BaseClass.Driver.Navigate().Back();
            filterCell.SendKeys(designation);
            Thread.Sleep(2000);
            string actdesg = result.Text;

            if (desg.Equals(actdesg))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
