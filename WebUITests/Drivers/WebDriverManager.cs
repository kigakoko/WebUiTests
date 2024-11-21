﻿using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace WebUITests.Drivers;

public static class WebDriverManager
{
	public static IWebDriver GetFirefoxDriver()
	{
		FirefoxOptions options = new();
		return new FirefoxDriver(options);
	}
}
