using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace MoodSync.PlaywrightTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false 
            });

            var  page = await browser.NewPageAsync();
            await page.GotoAsync("https://localhost:7121");
            await page.WaitForTimeoutAsync(2000);
            var login = page.Locator("a.nav-link:text('Log In')");

            await login.IsVisibleAsync();
            await login.ClickAsync();
            await page.WaitForTimeoutAsync(2000);

            await page.FillAsync("input[placeholder='Username']", "user");
            await page.FillAsync("input[placeholder='Password']", "user123");
            await page.ClickAsync("text=Login");

            await page.WaitForURLAsync("**/dashboard");
            var locationLabel = await page.Locator("label[for='location']").TextContentAsync();
            Assert.That(locationLabel, Is.EqualTo("Enter your location"));
        }
    }
}

