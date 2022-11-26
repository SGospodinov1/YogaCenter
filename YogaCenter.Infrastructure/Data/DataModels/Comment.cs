using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCenter.Infrastructure.Data.DataModels
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Descrtiption { get; set; }

        [Required]
        public string AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        [Required]
        public int YogaClassId { get; set; }

        [ForeignKey(nameof(YogaClassId))]
        public YogaClass YogaClass { get; set; }
    }
}
