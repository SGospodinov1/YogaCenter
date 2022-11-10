using System.ComponentModel.DataAnnotations;

namespace YogaCenter.Infrastructure.Data.DataModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null!;

        public List<YogaClass> YogaClasses { get; set; } = new List<YogaClass>();


    }
}
