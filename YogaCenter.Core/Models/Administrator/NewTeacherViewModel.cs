using System.ComponentModel.DataAnnotations;


namespace YogaCenter.Core.Models.Administrator
{
    /// <summary>
    /// NewTeacherViewModel give information from View to create new Teacher
    /// </summary>
    public class NewTeacherViewModel
    {
        /// <summary>
        /// Give description for the Teacher
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Give Id of the User who will be teacher
        /// </summary>
        [Required]
        public string AppUserId { get; set; }
    }
}
