using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor_TechDebtRadar.Data
{
    public class TechDebtItem
    {
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Title should be between 10-50")]
        public string Title { get; set; } = "";

        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Description should be between 10-200")]
        public string Description { get; set; } = "";

        [Required]
        public DateTimeOffset EstimatedDateOfIncident { get; set; } = DateTimeOffset.Now;
    }
}
