using System.ComponentModel.DataAnnotations;

namespace YogaCenter.Core.Models
{
    public class CommentViewModel
    {
        [StringLength(200, MinimumLength = 10)]
        [Required]
        public string Description { get; set; }

        public string FullName { get; set; }

        public string AppUserId { get; set; }


        public int YogaClassId { get; set; }

        
    }
}
