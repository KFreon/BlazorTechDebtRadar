using Microsoft.AspNetCore.Components.Web;
using System.Collections.Immutable;
using TechDebtify.Services;

namespace TechDebtify.Pages;

public partial class TechDebtItemList
{
    private string? SearchText { get; set; }
    private IReadOnlyCollection<InMemoryStorageItem> Items = new List<InMemoryStorageItem>();

    private System.Timers.Timer searchInputTimer = new System.Timers.Timer()
    {
        Interval = 0.2 * 1000
    };

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Items = storage.GetItems();
        searchInputTimer.Elapsed += (_, _) =>
        {
            Console.WriteLine($"Searching for {SearchText}");
            searchInputTimer.Stop();
            Console.Out.Flush();

            PerformSearch();
        };
    }

    private void PerformSearch()
    {
        var allItems = storage.GetItems();
        if (SearchText is null)
        {
            Items = allItems;
            return;
        }

        Items = allItems
            .Where(item => item.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
                || item.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
            ).ToImmutableArray();

        InvokeAsync(() => StateHasChanged());
    }

    public void OnSearchTextChanged(KeyboardEventArgs arg)
    {
        searchInputTimer.Stop();
        searchInputTimer.Start();
    }

    public void AddNewItem()
    {
        navigator.NavigateTo("/new-item");
    }
}
