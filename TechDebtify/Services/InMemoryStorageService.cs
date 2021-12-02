using System.Collections.Immutable;
using TechDebtify.Data;

namespace TechDebtify.Services;

public class InMemoryStorageItem : TechDebtItem
{
    public DateTimeOffset CreatedOn { get; set; }
    public string CreatedBy { get; set; }

    public InMemoryStorageItem(TechDebtItem item)
    {
        Id = item.Id;
        Title = item.Title;
        Description = item.Description;
        EstimatedDateOfIncident = item.EstimatedDateOfIncident;
        CreatedOn = DateTimeOffset.Now;
        CreatedBy = "MEEEE";
        Status = TechDebtItemStatus.Existing;
    }
}

public class IDGeneratorService
{
    private int id = 3;
    public IEnumerable<int> GetNext()
    {
        while(true)
        {
            yield return id++;
        }
    }
}

public class InMemoryStorageService
{
    private readonly List<InMemoryStorageItem> _items = new List<InMemoryStorageItem>
        {
            new InMemoryStorageItem(new TechDebtItem
            {
                Id = 1,
                Title="Google Maps API deprecation",
                Description="Maps are getting deleted entirely cos Google.",
                EstimatedDateOfIncident=DateTimeOffset.Now.AddDays(2),
                Status = TechDebtItemStatus.Existing,
            }),
            new InMemoryStorageItem(new TechDebtItem
            {
                Id = 2,
                Title="Apple broke Cordova",
                Description="I don't have a mac to fix it :(",
                EstimatedDateOfIncident=DateTimeOffset.Now.AddDays(20),
                Status = TechDebtItemStatus.Existing,
            }),
        };

    public IReadOnlyCollection<InMemoryStorageItem> GetItems() => _items.ToImmutableArray();

    public void Add(InMemoryStorageItem item) => _items.Add(item);

    public void Update(InMemoryStorageItem item)
    {
        var index = _items.FindIndex(x => x.Id == item.Id);
        if (index >= 0)
        {
            _items.RemoveAt(index);
            _items.Insert(index, item);
        }
    }
}