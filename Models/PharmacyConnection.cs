using System;
using System.Collections.Generic;
using System.Text;

namespace wsKooshDaroo.Models
{
    public class PharmacyConnection
    {
        public int id { get; set; }
        public int PharmacyId { get; set; }
        public DateTime DateOfConnectionState { get; set; }
        public int StateOf { get; set; }

    }
}
