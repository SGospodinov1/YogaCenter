using System.ComponentModel.DataAnnotations;

namespace YogaCenter.Core.Models
{
    /// <summary>
    /// CommentViewModel is used for creating new Comment or show comment
    /// </summary>
    public class CommentViewModel
    {
        /// <summary>
        /// Give description for Comment
        /// </summary>
        [StringLength(200, MinimumLength = 10)]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Give FullName of the User
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Give Id of the User
        /// </summary>
        public string AppUserId { get; set; }

        /// <summary>
        /// Give Id of the YogaClass where it belongs
        /// </summary>
        public int YogaClassId { get; set; }

        
    }
}
