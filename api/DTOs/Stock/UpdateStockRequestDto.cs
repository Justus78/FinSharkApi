using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol must be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(10, ErrorMessage = "Company name must be over 10 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001, 100000)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "Industry cannot be over 12 characters")]
        public string Industry { get; set; } = string.Empty;
        
        [Range(1, 1000000000)]
        public long MarketCap { get; set; }
    }
}