using System.ComponentModel.DataAnnotations;


namespace YogaCenter.Infrastructure.Data.DataModels
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        public List<YogaClass> YogaClasses { get; set; } = new List<YogaClass>();

        public List<Post> Posts { get; set; } = new List<Post>();



    }
}
