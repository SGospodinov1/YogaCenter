using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaCenter.Core.Models
{
    public class YogaClassViewModel
    {
        
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime DateTime { get; set; }

        public string DayOfWeek { get; set; }

        
        public string Date { get; set; }

        
        public string StartTime { get; set; }

        
        public string EndTime { get; set; }

        
        public decimal Price { get; set; }

        public int TeacherId { get; set; }

        public string Teacher { get; set; }

        
        public string Category { get; set; }

        public List<string> Users { get; set; } = new List<string>();
    }
}
