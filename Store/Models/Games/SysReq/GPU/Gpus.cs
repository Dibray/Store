using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store
{
    public partial class Gpus
    {
        public int Id { get; set; }
        public int? ManufacturerId { get; set; }
        public int? ModelId { get; set; }
        public int? SeriesId { get; set; }
        public int? FrequencyMghId { get; set; }
        public int? VramMbId { get; set; }

        public virtual GpuclockFreqs FrequencyMgh { get; set; }
        public virtual Gpumanufacturers Manufacturer { get; set; }
        public virtual Gpumodels Model { get; set; }
        public virtual Gpuseries Series { get; set; }
        public virtual GpuVrams VramMb { get; set; }
    }
}
