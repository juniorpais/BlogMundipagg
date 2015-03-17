using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMundiPagg.Repository.Entities
{
    public class PostTag
    {
        public int PostTagID { get; set; }

        public Tag Tag { get; set; }
        public Post Post { get; set; }
    }
}