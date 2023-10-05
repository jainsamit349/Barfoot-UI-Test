using Microsoft.Playwright;
namespace playwrightTests.pageobjects
{
    public class SearchPropertiesPage
    {

        private IPage _page;
        public SearchPropertiesPage(IPage page) => _page = page;
        private ILocator _filterButton => _page.Locator("[data-test-attr='showMoreFilters']");
        private ILocator _searchSuburb => _page.Locator("input[placeholder='Enter suburb or region']");
        private ILocator _selectSuburb => _page.Locator("div:text('New Lynn')");
        private ILocator _searchBedroom => _page.Locator("[for='bedrooms-4']");
        private ILocator _searchBathroom => _page.Locator("[for='bathroom-2']");
        private ILocator _searchButton => _page.Locator("[data-test-attr='runCustomFilterSearch']");
        private ILocator _selectHouse => _page.Locator("[for='checkGroupresidentialsold6-house']");
        private ILocator _selectPriceRange => _page.Locator("[role='slider']").Nth(0);
        private ILocator _selectLandArea => _page.Locator("[role='slider']").Nth(2);


        public async Task SearchPropertiesScenario1(String Suburb)

        {
            await _filterButton.ClickAsync();
            await _searchSuburb.FillAsync(Suburb);
            await _selectSuburb.ClickAsync();
            await _searchBedroom.ClickAsync();
            await _searchBathroom.ClickAsync();
            await _searchButton.ClickAsync();
        }

        public async Task SearchPropertiesScenario2(String Suburb)

        {
            await _filterButton.ClickAsync();
            await _searchSuburb.FillAsync(Suburb);
            await _selectSuburb.ClickAsync();
            await _selectHouse.ClickAsync();
            await _selectPriceRange.ClickAsync();
            await _selectPriceRange.PressAsync("ArrowRight");
            await _page.GetByText("$50,000").IsVisibleAsync();
            await _selectPriceRange.PressAsync("ArrowRight");
            await _page.GetByText("$100,000").IsVisibleAsync();
            await _selectLandArea.ClickAsync();
            await _selectLandArea.PressAsync("ArrowRight");
            await _page.GetByText("100m2").IsVisibleAsync();
            await _selectLandArea.PressAsync("ArrowRight");
            await _page.GetByText("200m2").IsVisibleAsync();
            await _selectLandArea.PressAsync("ArrowRight");
            await _searchButton.ClickAsync();
        }
    }
}