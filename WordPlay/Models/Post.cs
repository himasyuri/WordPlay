using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordPlay.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
