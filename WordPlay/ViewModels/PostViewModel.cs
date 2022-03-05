using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WordPlay.ViewModels
{
    public class PostViewModel
    {
        [Required]
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string UserName { get; set; }
    }
}
