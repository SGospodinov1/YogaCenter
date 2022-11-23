using System.ComponentModel.DataAnnotations;


namespace YogaCenter.Core.Models.Administrator
{
    public class NewTeacherViewModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string AppUserId { get; set; }
    }
}
