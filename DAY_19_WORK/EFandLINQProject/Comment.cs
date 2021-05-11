using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLINQProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; }
    }
}
