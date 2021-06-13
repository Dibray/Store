using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store
{
    public partial class GpuVrams
    {
        public GpuVrams()
        {
            Gpus = new HashSet<Gpus>();
        }

        public int Id { get; set; }
        public int? SizeMb { get; set; }

        public virtual ICollection<Gpus> Gpus { get; set; }
    }
}
