using System.Collections.Immutable;
using TechDebtify.Data;

namespace TechDebtify.Services;

public class InMemoryStorageItem : TechDebtItem
{
    public DateTimeOffset CreatedOn { get; set; }
    public string CreatedBy { get; set; }

    public InMemoryStorageItem(TechDebtItem item)
    {
        Title = item.Title;
        Description = item.Description;
        EstimatedDateOfIncident = item.EstimatedDateOfIncident;
        CreatedOn = DateTimeOffset.Now;
        CreatedBy = "MEEEE";
    }
}

public class InMemoryStorageService
{
    private readonly List<InMemoryStorageItem> _items = new List<InMemoryStorageItem>
        {
            new InMemoryStorageItem(new TechDebtItem
            {
                Title="Google Maps API deprecation",
                Description="Maps are getting deleted entirely cos Google.",
                EstimatedDateOfIncident=DateTimeOffset.Now.AddDays(2)
            }),
            new InMemoryStorageItem(new TechDebtItem
            {
                Title="Apple broke Cordova",
                Description="I don't have a mac to fix it :(",
                EstimatedDateOfIncident=DateTimeOffset.Now.AddDays(20)
            }),
        };

    public IReadOnlyCollection<InMemoryStorageItem> GetItems() => _items.ToImmutableArray();

    public void Add(InMemoryStorageItem item) => _items.Add(item);
}