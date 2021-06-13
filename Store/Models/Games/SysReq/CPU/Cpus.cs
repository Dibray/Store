using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store
{
    public partial class Cpus
    {
        public int Id { get; set; }
        public int? ManufacturerId { get; set; }
        public int? ModelId { get; set; }
        public int? SeriesId { get; set; }
        public int? FrequencyMghId { get; set; }

        public virtual CpuclockFreqs FrequencyMgh { get; set; }
        public virtual Cpumanufacturers Manufacturer { get; set; }
        public virtual Cpumodels Model { get; set; }
        public virtual Cpuseries Series { get; set; }
    }
}
