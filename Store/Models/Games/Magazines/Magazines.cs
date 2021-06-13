using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store
{
    public partial class Magazines
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }
    }
}
