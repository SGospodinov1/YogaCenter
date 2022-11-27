using System.ComponentModel.DataAnnotations;


namespace YogaCenter.Core.Models
{
    public class TeacherViewModel
    {
        public int Id { get; set; }

        
        public string FullName { get; set; }

        
        public string Description { get; set; }

        
        public string Email { get; set; }
    }
}
