using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCenter.Infrastructure.Data.DataModels
{

    /// <summary>
    /// Comment for YogaClass
    /// </summary>
    public class Comment
    {

        /// <summary>
        /// Id of Comment
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Comment description
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Descrtiption { get; set; }

        /// <summary>
        /// Id of User who write the Comment
        /// </summary>
        [Required]
        public string AppUserId { get; set; }

        /// <summary>
        /// ForeignKey to the User
        /// </summary>
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        /// <summary>
        /// Id of YogaClass where this Comment belongs
        /// </summary>
        [Required]
        public int YogaClassId { get; set; }

        /// <summary>
        /// ForeignKey to the YogaClass
        /// </summary>
        [ForeignKey(nameof(YogaClassId))]
        public YogaClass YogaClass { get; set; }
    }
}
