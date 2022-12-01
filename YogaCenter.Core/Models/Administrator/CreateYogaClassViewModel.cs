using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Models.Administrator
{
    public class CreateYogaClassViewModel
    {
        
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        public string Date { get; set; }

        [Required]
        public string StartTime { get; set; }

        [Required]
        public string EndTime { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int TeacherId { get; set; }


        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
