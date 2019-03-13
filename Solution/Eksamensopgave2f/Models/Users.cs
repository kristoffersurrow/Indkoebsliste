using System;
using System.Collections.Generic;

namespace Eksamensopgave2f.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Counter { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
