using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCenter.Infrastructure.Data.DataModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        public List<UserYogaClass> UsersYogaClasses { get; set; } = new List<UserYogaClass>();

        [Required]
        public string AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

    }
}
