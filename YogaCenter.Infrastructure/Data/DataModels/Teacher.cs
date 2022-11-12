using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace YogaCenter.Infrastructure.Data.DataModels
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        public string Description { get; set; }



        public List<YogaClass> YogaClasses { get; set; } = new List<YogaClass>();

        public List<Post> Posts { get; set; } = new List<Post>();

       
    }
}
