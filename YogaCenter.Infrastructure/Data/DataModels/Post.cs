using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace YogaCenter.Infrastructure.Data.DataModels
{

    /// <summary>
    /// Post from Teacher
    /// </summary>
    public class Post
    {

        /// <summary>
        /// Id of Post
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Title of Post
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Short Summary for the Post
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Summary { get; set; } = null!;

        /// <summary>
        /// Description of the Post
        /// </summary>
        [Required]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Time when the Post is created
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// Id of Teacher who create the Post
        /// </summary>
        [Required]
        public int TeacherId { get; set; }

        /// <summary>
        /// ForeignKey to the Teacher
        /// </summary>
        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; } = null!;



    }
}
