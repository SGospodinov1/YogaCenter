using System.ComponentModel.DataAnnotations;

namespace YogaCenter.Core.Models.Administrator
{

    /// <summary>
    /// MyInfoViewModel give information for the Teacher
    /// </summary>
    public class MyInfoViewModel
    {

        /// <summary>
        /// Give Id of the Teacher
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Give Id of the User who is Teacher
        /// </summary>
        public string AppUserId { get; set; }

        
        /// <summary>
        /// Give FirstName of the Teacher
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Give LastName of the Teacher
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Give Email of the Teacher
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Give Teacher Description
        /// </summary>
        public string Description { get; set; }
    }
}
