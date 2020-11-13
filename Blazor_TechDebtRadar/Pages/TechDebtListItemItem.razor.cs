using System;
using Microsoft.AspNetCore.Components;

namespace Blazor_TechDebtRadar.Pages
{
    public partial class TechDebtListItemItem
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public string Description { get; set; }
        [Parameter] public DateTimeOffset EstimatedDateOfIncident { get; set; }
        [Parameter] public DateTimeOffset CreatedOn { get; set; }
        [Parameter] public string CreatedBy { get; set; }
    }
}
