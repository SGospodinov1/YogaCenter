

using System.ComponentModel.DataAnnotations;

namespace YogaCenter.Core.Models.Administrator
{
    public class MyInfoViewModel
    {
        [Required]
        public string AppUserId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
