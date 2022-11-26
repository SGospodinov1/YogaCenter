

using System.ComponentModel.DataAnnotations;

namespace YogaCenter.Core.Models.Administrator
{
    public class MyInfoViewModel
    {
        
        public int Id { get; set; }

      
        public string AppUserId { get; set; }

        
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

        
        public string Email { get; set; }

        
        public string Description { get; set; }
    }
}
