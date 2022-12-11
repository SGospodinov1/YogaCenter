

namespace YogaCenter.Core.Models
{
    /// <summary>
    /// YogaClassViewModel give detailed information about YogaCLass
    /// </summary>
    public class YogaClassViewModel
    {
        /// <summary>
        /// Give Id of the YogaClass
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Give Name of the YogaClass
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Give DateTime which is equal to entity StartTime and is used to filter classes that are not past
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Give information about day of week 
        /// </summary>
        public string DayOfWeek { get; set; }

        /// <summary>
        /// Give information about Date
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Give information about starting hour
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// Give information about ending hour
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// Give information about price 
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Give Id of the Teacher
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// Give Fullname of the Teacher
        /// </summary>
        public string Teacher { get; set; }

        /// <summary>
        /// Give information about class category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Give information about Users that will participate to the class
        /// </summary>
        public List<string> Users { get; set; } = new List<string>();

        /// <summary>
        /// Give count of all participants
        /// </summary>
        public int Participants
        {
            get { return Users.Count; }
        }
    }

}
