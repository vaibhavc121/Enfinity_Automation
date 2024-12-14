﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Enfinity_Automation.BaseTest
{
    public class BaseClass
    {
        public static IWebDriver Driver { get; private set; }
        public static Faker faker;

        [SetUp]
        public void Setup()
        {
            faker = new Faker();
            // Initialize WebDriver
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();

            // Navigate to the desired URL
            Driver.Navigate().GoToUrl("https://testhrms.onenfinity.com/HrCore/Home/GettingStarted");

            // Perform login
            Login("vaibhavc121@demo.com", "rohitc121");
        }

        private void Login(string username, string password)
        {
            try
            {
                IWebElement usernameField = Driver.FindElement(By.XPath("//input[@type='text']"));
                IWebElement passwordField = Driver.FindElement(By.XPath("//input[@type='password']"));
                IWebElement signInButton = Driver.FindElement(By.XPath("//div[@aria-label='Sign In']//div[@class='dx-button-content']"));

                usernameField.SendKeys(username);
                passwordField.SendKeys(password);
                signInButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Login failed: " + ex.Message);
                throw;
            }
        }

        [TearDown]
        public void Cleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}
