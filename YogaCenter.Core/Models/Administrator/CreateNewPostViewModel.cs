using System.ComponentModel.DataAnnotations;


namespace YogaCenter.Core.Models.Administrator
{

    /// <summary>
    /// CreateNewPostViewModel collect information that Teacher fill in the form and gives information when Teacher want to edit the Post
    /// </summary>
    public class CreateNewPostViewModel
    {

        /// <summary>
        /// Give Id of the Post
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Give Title of the Post
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Give Summary of the post
        /// </summary>
        [Required]
        [StringLength(200, MinimumLength = 30)]
        public string Summary { get; set; } = null!;

        /// <summary>
        /// Give Description of the Post
        /// </summary>
        [Required]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Give information when the Post is created
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// Give information of Id of the Teacher
        /// </summary>
        [Required]
        public int TeacherId { get; set; }




    }
}
