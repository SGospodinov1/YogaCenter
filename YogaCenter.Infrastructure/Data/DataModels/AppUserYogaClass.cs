using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace YogaCenter.Infrastructure.Data.DataModels
{
    public  class AppUserYogaClass
    {
        
        public string AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; } = null!;

        
        public int YogaClassId { get; set; }

        [ForeignKey(nameof(YogaClassId))]
        public YogaClass YogaClass { get; set; } = null!;
    }
}
