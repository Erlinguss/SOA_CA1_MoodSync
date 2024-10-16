using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace MoodSync.PlaywrightTests
{
    public class ViewHistoryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test3()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://localhost:7121");
            await page.WaitForTimeoutAsync(2000);
            var login = page.Locator("a.nav-link:text('Log In')");

            await login.IsVisibleAsync();
            await login.ClickAsync();
            await page.WaitForTimeoutAsync(2000);

            await page.FillAsync("input[placeholder='Username']", "user");
            await page.FillAsync("input[placeholder='Password']", "user123");
            await page.ClickAsync("text=Login");

            await page.GotoAsync("https://localhost:7121/dashboard");
            var viewHistoryLink = page.Locator("a.nav-link:text-is('View History')");
            await viewHistoryLink.ClickAsync();

            await page.WaitForSelectorAsync("section.history-section");
            var historySection = page.Locator("section.history-section");
            await historySection.ScrollIntoViewIfNeededAsync();
            var historyHeading = page.Locator("h3:text-is('Recommendation History')");
            var isHistoryVisible = await historyHeading.IsVisibleAsync();

            Assert.IsTrue(isHistoryVisible, "The Recommendation History is visible.");
            var recommendationsList = page.Locator("div.history-card");
            var recommendationCount = await recommendationsList.CountAsync();

            Assert.IsTrue(recommendationCount > 0, "At least one recommendation in the history.");
            await page.WaitForTimeoutAsync(2000);
            await browser.CloseAsync();
        }
    }
}

