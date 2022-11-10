using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaCenter.Infrastructure.Data.DataModels
{
    public class Mail
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        [EmailAddress]
        public string Email { get; set; } = null!;

    }
}
