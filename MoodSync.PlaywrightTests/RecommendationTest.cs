using Microsoft.Playwright;
using NUnit.Framework;

namespace MoodSync.PlaywrightTests
{
    public class RecommendationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test2()
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
            await page.FillAsync("input[placeholder='Username']", "user");
            await page.FillAsync("input[placeholder='Password']", "user123");
            await page.ClickAsync("text=Login");
            await page.WaitForLoadStateAsync();
            await page.GotoAsync("https://localhost:7121/dashboard");
          
            var moodDropdown = page.Locator("#mood");
            await moodDropdown.SelectOptionAsync(new[] { "Sad" });
            var locationInput = page.Locator("#location");
            await locationInput.FillAsync("Drogheda");

            var getRecommendationsButton = page.Locator("button.primary-btn");
            await getRecommendationsButton.ClickAsync();
            var recommendationSection = page.Locator(".recommendation-cards-container.show");
            await recommendationSection.ScrollIntoViewIfNeededAsync();
            var suggestedTodayHeading = page.Locator("h6:text-is('Suggested today:')");
            var isHeadingVisible = await suggestedTodayHeading.IsVisibleAsync();

            Assert.IsTrue(isHeadingVisible, "The heading 'Suggested today:' should be visible.");

            await page.WaitForTimeoutAsync(2000);
            await browser.CloseAsync();
        }
    }
}
