using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store
{
    public partial class MinSysReqRamsize
    {
        public int RamsizeId { get; set; }
        public int GameId { get; set; }

        public virtual Games Game { get; set; }
        public virtual Ramsizes Ramsize { get; set; }
    }
}
