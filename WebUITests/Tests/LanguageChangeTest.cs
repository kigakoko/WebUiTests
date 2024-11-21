﻿using Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics;
using WebUITests.Drivers;

namespace WebUITests.Tests;

[TestFixture]
[Parallelizable]
[Category("LanguageChangeTest")]
public class LanguageChangeTest
{
	IWebDriver driver = null!;
	private Stopwatch stopwatch = null!;

	[SetUp]
	public void Setup()
	{
		driver = WebDriverManager.GetFirefoxDriver();
		driver.Manage().Window.Maximize();
		stopwatch = new Stopwatch();
	}

	[Test]
	[TestCase("https://en.ehu.lt/", ".language-switcher", "LT")]
	public void VerifyLanguageChangeToLithuanian(string url, string selector, string language)
	{
		stopwatch.Start();
		driver.Navigate().GoToUrl(url);

		IWebElement languageSwitcher = driver.FindElement(By.CssSelector(selector));
		languageSwitcher.Click();
		IWebElement lithuanianOption = driver.FindElement(By.LinkText(language));
		lithuanianOption.Click();

		Assert.That(driver.Url, Does.Contain("https://lt.ehu.lt/"));

		IWebElement header = driver.FindElement(By.TagName("h1"));
		Assert.That(header.Text, Does.Contain("Kodėl EHU?\r\nKas daro EHU unikaliu?"));
		stopwatch.Stop();
		TestLogger.LogExecutionTime("NUnit, VerifyLanguageChangeToLithuanian", stopwatch);
	}

	[TearDown]
	public void Teardown()
	{
		driver.Quit();
	}
}
