using System.ComponentModel.DataAnnotations;


namespace YogaCenter.Core.Models.Administrator
{
    public class CreateNewPostViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(200, MinimumLength = 30)]
        public string Summary { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public int TeacherId { get; set; }




    }
}
