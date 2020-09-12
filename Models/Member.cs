using System;
using System.Collections.Generic;
using System.Text;

namespace wsKooshDaroo.Models
{
    public class Member
    {
        public int id { get; set; }
        public string PhoneNo { get; set; }
        public bool isInactive { get; set; }
        public string Name { get; set; }
    }
}
