using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoLab2.Pages;

public class ProductsPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public ProductsPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private By TitleLocator => By.CssSelector(".title");

    public bool IsDisplayed() =>
        _driver.Url.Contains("inventory.html") && _driver.FindElements(TitleLocator).Count > 0;

    public string GetTitle() =>
        _wait.Until(d => d.FindElement(TitleLocator)).Text;
}
