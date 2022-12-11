using System.ComponentModel.DataAnnotations;

namespace YogaCenter.Infrastructure.Data.DataModels
{
    /// <summary>
    /// Category for YogaClass
    /// </summary>
    public class Category
    {

        /// <summary>
        /// Id of category
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of category
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// List of YogaClasses from this Category
        /// </summary>
        public List<YogaClass> YogaClasses { get; set; } = new List<YogaClass>();


    }
}
