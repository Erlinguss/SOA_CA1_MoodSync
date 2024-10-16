using Microsoft.Playwright;

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
            await page.WaitForTimeoutAsync(3000);
            await page.ClickAsync("Text=Log In");
            await page.WaitForTimeoutAsync(2000);
         
            await page.FillAsync("#username", "user");
            await page.FillAsync("#password", "user123");
        
            await page.ClickAsync("text=Login");

            await page.WaitForURLAsync("**/dashboard");
            var title = page.GetByText("Get Recommendation");

            Assert.Equals("Get Recommendation",title);
        }
    }
}

