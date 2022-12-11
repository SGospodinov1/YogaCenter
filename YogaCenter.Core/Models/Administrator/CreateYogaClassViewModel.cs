using System.ComponentModel.DataAnnotations;
using YogaCenter.Infrastructure.Data.DataModels;

namespace YogaCenter.Core.Models.Administrator
{

    /// <summary>
    /// CreateYogaClassViewModel collect information that Teacher fill in the form and gives information when Teacher want to edit the YogaClass
    /// </summary>
    public class CreateYogaClassViewModel
    {

        /// <summary>
        /// Give Id of the YogaClass
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Give Name of the YogaClass
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Give Date of the YogaClass as string
        /// </summary>
        [Required]
        public string Date { get; set; }

        /// <summary>
        ///Give StartTime of the YogaClass as string
        /// </summary>
        [Required]
        public string StartTime { get; set; }

        /// <summary>
        /// Give EndTime of the YogaClass as string
        /// </summary>
        [Required]
        public string EndTime { get; set; }

        /// <summary>
        /// Give Price of the YogaClass
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Give Id of the Teacher who will lead the YogaClass
        /// </summary>
        [Required]
        public int TeacherId { get; set; }

        /// <summary>
        /// Give Id of the Category
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Give List of All Categories for the dropdown row in View
        /// </summary>
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
