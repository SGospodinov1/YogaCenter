using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace YogaCenter.Infrastructure.Data.DataModels
{
    /// <summary>
    /// Many to many relation class between AppUser and YogaClass
    /// </summary>
    public  class AppUserYogaClass
    {
        
        /// <summary>
        /// Id of AppUser 
        /// </summary>
        public string AppUserId { get; set; }

        /// <summary>
        /// ForeignKey to the AppUser
        /// </summary>
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; } = null!;

        
        /// <summary>
        /// Id of YogaClass
        /// </summary>
        public int YogaClassId { get; set; }

        /// <summary>
        /// ForeignKey to the YogaClass
        /// </summary>
        [ForeignKey(nameof(YogaClassId))]
        public YogaClass YogaClass { get; set; } = null!;
    }
}
