using System.ComponentModel.DataAnnotations;

namespace TechDebtify.Data;

public enum TechDebtItemStatus
{
    New = 1,
    Existing,
    Deleted
}

public class TechDebtItem
{
    public int Id { get; set; }

    public TechDebtItemStatus Status { get; set; } = TechDebtItemStatus.New;

    [Required]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "Title should be between 10-50")]
    public string Title { get; set; } = "";

    [Required]
    [StringLength(200, MinimumLength = 10, ErrorMessage = "Description should be between 10-200")]
    public string Description { get; set; } = "";

    [Required]
    public DateTimeOffset EstimatedDateOfIncident { get; set; } = DateTimeOffset.Now;
}
