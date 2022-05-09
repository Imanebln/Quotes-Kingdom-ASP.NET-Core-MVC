using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jokes3.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public Quote()
        {

        }
    }
}