using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace YogaCenter.Infrastructure.Data.DataModels
{
    /// <summary>
    /// Extended User for the project
    /// </summary>
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// FirstName of the User
        /// </summary>
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName of the User
        /// </summary>
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        /// <summary>
        /// Collection of YogaClasses that the User joined
        /// </summary>
        public List<AppUserYogaClass> AppUsersYogaClasses { get; set; } = new List<AppUserYogaClass>();

        /// <summary>
        /// Collection of User Comments
        /// </summary>
        public List<Comment> Comments { get; set; } = new List<Comment>();


    }
}
