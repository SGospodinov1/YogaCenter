

namespace YogaCenter.Core.Models
{
    /// <summary>
    /// PostViewModel give short information of the Post
    /// </summary>
    public class PostViewModel
    {
        /// <summary>
        /// Give Id of the Post
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Give Title of the Post
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Give Summary of the Post
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Give information of the Post creator
        /// </summary>
        public string CreatedBy { get; set; }

    }
}
