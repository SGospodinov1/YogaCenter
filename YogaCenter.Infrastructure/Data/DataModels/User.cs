using Microsoft.AspNetCore.Identity;

namespace YogaCenter.Infrastructure.Data.DataModels
{
    public class User : IdentityUser
    {
        public List<UserYogaClass> UsersYogaClasses { get; set; } = new List<UserYogaClass>();
    }
}
