using System.ComponentModel.DataAnnotations;


namespace YogaCenter.Core.Models
{
    /// <summary>
    /// TeacherViewModel give information for the teacher to the User and public View
    /// </summary>
    public class TeacherViewModel
    {
        /// <summary>
        /// Give Id of the Teacher
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Give FullName of the Teacher
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Give description for the Teacher
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Give email of the Teacher
        /// </summary>
        public string Email { get; set; }
    }
}
