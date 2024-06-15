using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentFullname { get; set; }
        public string CommentEmail { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}