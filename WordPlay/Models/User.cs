using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WordPlay.Models
{

    public class User : IdentityUser
    {
        public DateTime CreateOn { get; set; } = DateTime.UtcNow;
    }
}
