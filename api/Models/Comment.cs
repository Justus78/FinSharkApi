using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        // properties to set up one to many relationship with Stock model
        public int? StockId { get; set; }
        // navigation property for one to many relationship
        public Stock? Stock { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}