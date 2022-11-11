using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace YogaCenter.Infrastructure.Data.DataModels
{
    public class User : IdentityUser
    {
        public List<YogaClass> YogaClasses { get; set; } = new List<YogaClass>();
    }
}
