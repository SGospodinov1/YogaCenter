using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace YogaCenter.Infrastructure.Data.DataModels
{
    /// <summary>
    /// Teacher who work in the center
    /// </summary>
    public class Teacher
    {

        /// <summary>
        /// Id of the Teacher
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Teacher description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// List of Teacher YogaClasses
        /// </summary>
        public List<YogaClass> YogaClasses { get; set; } = new List<YogaClass>();

        /// <summary>
        /// List of Teacher Posts
        /// </summary>
        public List<Post> Posts { get; set; } = new List<Post>();

        /// <summary>
        /// Id of User who is Teacher
        /// </summary>
        [Required]
        public string AppUserId { get; set; }

        /// <summary>
        /// ForeignKey to the User
        /// </summary>
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        /// <summary>
        /// Property that show is this Teacher is active or not
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }
       
    }
}
