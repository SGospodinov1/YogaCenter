﻿using System.ComponentModel.DataAnnotations;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Models.Administrator
{
    public class EditYogaClassViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        public DateTime DateTime { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string StartTime { get; set; }

        [Required]
        public string EndTime { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
