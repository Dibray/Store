using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store
{
    public partial class Cpuseries
    {
        public Cpuseries()
        {
            Cpus = new HashSet<Cpus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cpus> Cpus { get; set; }
    }
}
