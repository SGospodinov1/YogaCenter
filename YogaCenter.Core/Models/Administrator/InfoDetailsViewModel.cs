using System.ComponentModel.DataAnnotations;


namespace YogaCenter.Core.Models.Administrator
{
    public class InfoDetailsViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
