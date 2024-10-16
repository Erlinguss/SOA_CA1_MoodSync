using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodSync.PlaywrightTests
{
    public class  IncorrectCredentialTest

    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test_IncorrectLoginCredentials()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://localhost:7121");

            var loginLink = page.Locator("a.nav-link:text-is('Log In')");
            await loginLink.ClickAsync();
   
            await page.WaitForSelectorAsync("input[placeholder='Username']");
            await page.FillAsync("input[placeholder='Username']", "wronguser");
            await page.FillAsync("input[placeholder='Password']", "wrongpassword");
            await page.ClickAsync("text=Login");

            var errorMessage = await page.Locator(".error-message").TextContentAsync();
            Assert.That(errorMessage, Is.EqualTo("Invalid username or password!"));

            await page.WaitForTimeoutAsync(2000);
            await browser.CloseAsync();
        }
    }
}
