using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SauceDemoLab2.Hooks;

[Binding]
public class WebDriverHooks
{
    private readonly IObjectContainer _container;
    private IWebDriver? _driver;

    public WebDriverHooks(IObjectContainer container) => _container = container;

    [BeforeScenario]
    public void StartBrowser()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        
        _driver = new ChromeDriver(options); 
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        _container.RegisterInstanceAs<IWebDriver>(_driver);
    }

    [AfterScenario]
    public void StopBrowser()
    {
        Thread.Sleep(5000);
        _driver?.Quit();
        _driver?.Dispose();
    }
}
