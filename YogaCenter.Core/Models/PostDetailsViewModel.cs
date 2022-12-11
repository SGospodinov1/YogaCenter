using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaCenter.Core.Models
{
    /// <summary>
    /// PostDetailsViewModel give detailed information of the Post
    /// </summary>
    public class PostDetailsViewModel
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
        /// Give Description of the Post
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Give information of the Post creator
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Give information of date of creation
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
