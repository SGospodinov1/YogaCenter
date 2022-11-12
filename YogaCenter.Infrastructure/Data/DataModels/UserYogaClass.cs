using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace YogaCenter.Infrastructure.Data.DataModels
{
    public  class UserYogaClass
    {
        [Required] 
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Required]
        public int YogaClassId { get; set; }

        [ForeignKey(nameof(YogaClassId))]
        public YogaClass YogaClass { get; set; }
    }
}
