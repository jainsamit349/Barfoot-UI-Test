using System.Text.RegularExpressions;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualBasic;
using playwrightTests.pageobjects;
namespace PlaywrightTests;

public class Tests : PageTest
{

    // This test is to search for properties filtered out on Suburb, no of Bedrooms and no of Bathrooms

    [Test]
    public async Task VerifyPropertySearchFunctionality()
    {

        await Page.GotoAsync("https://www.barfoot.co.nz/");
        await Expect(Page).ToHaveTitleAsync(new Regex("Barfoot & Thompson"));
        var searchPropertiesPage = new SearchPropertiesPage(Page);
        await searchPropertiesPage.SearchPropertiesScenario1("New Lynn");
        await Expect(Page).ToHaveTitleAsync(new Regex("New Lynn"));
    }

    // This test is to search for properties filtered out on Suburb, Property Type, Price Range and Land Area
    [Test]
    public async Task VerifyPropertySearchFunctionalityPriceArea()
    {

        await Page.GotoAsync("https://www.barfoot.co.nz/");
        await Expect(Page).ToHaveTitleAsync(new Regex("Barfoot & Thompson"));
        var searchPropertiesPage = new SearchPropertiesPage(Page);
        await searchPropertiesPage.SearchPropertiesScenario2("New Lynn");
        await Expect(Page).ToHaveTitleAsync(new Regex("New Lynn"));
    }
}