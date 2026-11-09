using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoLab2.Pages;

public class LoginPage
{
    private const string Url = "https://www.saucedemo.com/";
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    // Локатори
    private IWebElement UsernameInput => _driver.FindElement(By.Id("user-name"));
    private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
    private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));
    private By ErrorLocator => By.CssSelector("[data-test='error']");
    private By ErrorCloseLocator => By.CssSelector(".error-button");

    // Дії
    public void Open() => _driver.Navigate().GoToUrl(Url);

    public void Login(string username, string password)
    {
        UsernameInput.Clear();
        UsernameInput.SendKeys(username);
        PasswordInput.Clear();
        PasswordInput.SendKeys(password);
        LoginButton.Click();
    }

    public void CloseError() => _driver.FindElement(ErrorCloseLocator).Click();

    // Перевірки
    public string GetErrorMessage() =>
        _wait.Until(d => d.FindElement(ErrorLocator)).Text;

    public bool IsErrorDisplayed() => _driver.FindElements(ErrorLocator).Count > 0;

    public bool IsLoginPageDisplayed() =>
        _driver.Url.TrimEnd('/') == Url.TrimEnd('/') && LoginButton.Displayed;
}
