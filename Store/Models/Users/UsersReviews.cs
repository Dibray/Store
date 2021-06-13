using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store
{
    public partial class UsersReviews
    {
        public long Id { get; set; }
        public DateTime DatetimeWritten { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }

        public virtual Games Game { get; set; }
        public virtual Microsoft.AspNetCore.Identity.IdentityUser User { get; set; }
    }
}
