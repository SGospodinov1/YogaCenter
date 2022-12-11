using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace YogaCenter.Infrastructure.Data.DataModels
{

    /// <summary>
    /// YogaClass
    /// </summary>
    public class YogaClass
    {

        /// <summary>
        /// Id of the YogaClass
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the class
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Start time of the class
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time of the class
        /// </summary>
        [Required]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Price for the class
        /// </summary>
        [Required]
        [Precision(18,2)]
        public decimal Price { get; set; }

        /// <summary>
        /// Id of class Category
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// ForeignKey to the Category
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        /// <summary>
        /// Id of the Teacher who will leаd this class
        /// </summary>
        [Required]
        public int TeacherId { get; set; }

        /// <summary>
        /// ForeignKey of the Teacher
        /// </summary>
        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; } = null!;

        /// <summary>
        /// List of all Users that will be on the class
        /// </summary>
        public List<AppUserYogaClass> AppUsersYogaClasses { get; set; } = new List<AppUserYogaClass>();

        /// <summary>
        /// Comments for this class
        /// </summary>
        public List<Comment> Comments { get; set; } = new List<Comment>();

        
    }
}
