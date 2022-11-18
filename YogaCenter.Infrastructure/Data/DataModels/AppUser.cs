using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace YogaCenter.Infrastructure.Data.DataModels
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        public List<AppUserYogaClass> AppUsersYogaClasses { get; set; } = new List<AppUserYogaClass>();

        public List<Comment> Comments { get; set; } = new List<Comment>();


    }
}
