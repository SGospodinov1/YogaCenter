using System.ComponentModel.DataAnnotations;


namespace YogaCenter.Core.Models
{
    public class TeacherViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
