<h1 style="color: #007aff; font-size: 40px; text-align: center; font-weight: bold;">MoodSync</h1>

<p style="text-align: justify;">
MoodSync is a web application Personalized Mental Wellness & Lifestyle Assistant. It provides personalized suggestions to the users for their well-being based on their prevailing mood, location, and real-time weather. The application integrates several third-party APIs to provide an extended experience in bringing together information from Google Maps, Weather services, and Geolocation APIs.
</p>

<h2 style="color: #005fcb; font-size: 30px; border-bottom: 2px solid #007aff;">Features</h2>
<ul style="padding-left: 20px;">
    <li>Mood-based recommendations</li>
    <li>Location-based suggestions using Google Geocoding & Nearby Places APIs</li>
    <li>Real-time weather data integration</li>
    <li>Historical recommendations tracking</li>
</ul>

<h2 style="color: #005fcb; font-size: 30px; border-bottom: 2px solid #007aff;">Prerequisites</h2>
<ul style="padding-left: 20px;">
    <li>.NET SDK (version 6.0 or higher)</li>
    <li>Google Cloud API keys for Maps, Places, and Geocoding</li>
    <li>Openweathermap key for weather description.</li>
    <li>Internet access for accessing third-party services</li>
</ul>

<h2 style="color: #005fcb; font-size: 30px; border-bottom: 2px solid #007aff;">Setup</h2>
<ol style="padding-left: 20px;">
    <li>Install XAMPP</li>
    <li>Clone Repository</li>
    <li>Install required packages using the following commands in Visual Studio 2022:
        <pre><code>
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.Playwright
        </code></pre>
    </li>
    <li>Setup your "appsetting.json with the required API keys
        <pre><code>
{
    "GoogleAPIKey": "your-google-api-key",
    "WeatherAPIKey": "your-weather-api-key"
}
        </code></pre>
    </li>
    <li>Run the following command to initialize Playwright:
        <pre><code>
npx playwright install
        </code></pre>
    </li>
</ol>

<h2 style="color: #005fcb; font-size: 30px; border-bottom: 2px solid #007aff;">Running the Application</h2>
<p style="text-align: justify;">
1. Ensure XAMPP is installed and running.<br>
2. Start the project using Visual Studio or <code>dotnet run</code>.<br>
3. Access the application on <code>https://localhost:7121</code>.
</p>

<h2 style="color: #005fcb; font-size: 30px; border-bottom: 2px solid #007aff;">Running Playwright Tests</h2>
<p style="text-align: justify;">
To run Playwright tests, use:
<pre><code>
dotnet test
</code></pre>
Ensure your local server is running when executing tests.
</p>

<h2 style="color: #005fcb; font-size: 30px; border-bottom: 2px solid #007aff;">References</h2>
<p style="text-align: justify;">
YouTube. (n.d.) .NET Microservices – Full Course for Beginners. Available at: <a href="https://www.youtube.com">https://www.youtube.com</a> (Accessed: 07 October 2024).<br>
Stack Overflow. (n.d.) c# - Send HTTP POST request in .NET. Available at: <a href="https://stackoverflow.com/questions/4015324/send-http-post-request-in-net">https://stackoverflow.com</a> (Accessed: 08 October 2024).<br>
Microsoft Learn. (n.d.) Microsoft Edge Playwright. Available at: <a href="https://learn.microsoft.com/en-us/microsoft-edge/playwright/">https://learn.microsoft.com</a> (Accessed: 16 October 2024).<br>
Microsoft Learn. (n.d.) CSS isolation in Blazor components. Available at: <a href="https://learn.microsoft.com/en-us/aspnet/core/blazor/components/css-isolation?view=aspnetcore-8.0">https://learn.microsoft.com</a> (Accessed: 11 October 2024).<br>
Microsoft Learn. (n.d.) Dependency injection in ASP.NET Core. Available at: <a href="https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection">https://learn.microsoft.com</a> (Accessed: 09 October 2024).<br>
Microsoft Learn. (n.d.) Asynchronous programming scenarios - C#. Available at: <a href="https://learn.microsoft.com/en-us/dotnet/csharp/async">https://learn.microsoft.com</a> (Accessed: 08 October 2024).<br>
Google Developers. (n.d.) Google Maps JavaScript API Overview. Available at: <a href="https://developers.google.com/maps/documentation/javascript/overview">https://developers.google.com</a> (Accessed: 09 October 2024).<br>
Bing Images. (n.d.) Many cities in the same images. Available at: <a href="https://www.bing.com/images">https://www.bing.com/images</a> (Accessed: 10 October 2024).<br>
Bing Images. (n.d.) Weather icons. Available at: <a href="https://www.bing.com/images">https://www.bing.com/images</a> (Accessed: 10 October 2024).<br>
Canva. (n.d.) Available at: <a href="https://www.canva.com">https://www.canva.com</a> (Accessed: 10 October 2024).<br>
Pexels Stock Photos. (n.d.) 100,000+ Best Weather Photos. Available at: <a href="https://www.pexels.com">https://www.pexels.com</a> (Accessed: 11 October 2024).
</p>
