using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoLab2.Pages;
using TechTalk.SpecFlow;

namespace SauceDemoLab2.Steps;

[Binding]
public class LoginSteps
{
    private readonly LoginPage _loginPage;
    private readonly ProductsPage _productsPage;

    public LoginSteps(IWebDriver driver)
    {
        _loginPage = new LoginPage(driver);
        _productsPage = new ProductsPage(driver);
    }

    [Given(@"I open the SauceDemo login page")]
    public void GivenIOpenTheLoginPage() => _loginPage.Open();

    [When(@"I log in with username ""(.*)"" and password ""(.*)""")]
    public void WhenILogIn(string username, string password) =>
        _loginPage.Login(username, password);

    [When(@"I close the error message")]
    public void WhenICloseTheErrorMessage() => _loginPage.CloseError();

    [Then(@"I should stay on the login page")]
    public void ThenIShouldStayOnLoginPage() =>
        Assert.That(_loginPage.IsLoginPageDisplayed(), Is.True,
            "Користувач залишив сторінку логіну, хоча вхід має бути заблоковано.");

    [Then(@"I should see the error message ""(.*)""")]
    public void ThenIShouldSeeErrorMessage(string expected) =>
        Assert.That(_loginPage.GetErrorMessage(), Is.EqualTo(expected));

    [Then(@"the products page should not be displayed")]
    public void ThenProductsPageNotDisplayed() =>
        Assert.That(_productsPage.IsDisplayed(), Is.False);

    [Then(@"no error message should be displayed")]
    public void ThenNoErrorDisplayed() =>
        Assert.That(_loginPage.IsErrorDisplayed(), Is.False);

    [Then(@"I should see the products page")]
    public void ThenIShouldSeeProductsPage()
    {
        Assert.That(_productsPage.IsDisplayed(), Is.True);
        Assert.That(_productsPage.GetTitle(), Is.EqualTo("Products"));
    }
}
