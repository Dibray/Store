using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store
{
    public partial class Games
    {
        public Games()
        {
            GalleryImagesPaths = new HashSet<GalleryImagesPaths>();
            GalleryVideosPaths = new HashSet<GalleryVideosPaths>();
            UsersReviews = new HashSet<UsersReviews>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Discount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string FaviconPath { get; set; }
        public string CoverPath { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GalleryImagesPaths> GalleryImagesPaths { get; set; }
        public virtual ICollection<GalleryVideosPaths> GalleryVideosPaths { get; set; }
        public virtual ICollection<UsersReviews> UsersReviews { get; set; }
    }
}
