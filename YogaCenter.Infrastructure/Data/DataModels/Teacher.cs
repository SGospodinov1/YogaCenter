using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace YogaCenter.Infrastructure.Data.DataModels
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Description { get; set; }


        public List<YogaClass> YogaClasses { get; set; } = new List<YogaClass>();

        public List<Post> Posts { get; set; } = new List<Post>();

        [Required]
        public string AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }
    }
}
