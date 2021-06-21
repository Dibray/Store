using System;
using System.Collections.Generic;

namespace Store.Models.ViewModels
{
    public struct GameViewModel
    {
        public string FaviconPath { get; set; }
        public string Title { get; set; }
        public string CoverPath { get; set; }
        public List<string> Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> Platforms { get; set; }
        public ICollection<ReceptionViewModel> Reception { get; set; }
        public string Description { get; set; }
        public ICollection<string> GalleryVideosPaths { get; set; }
        public ICollection<string> GalleryImagesPaths { get; set; }
        public ICollection<CpuViewModel> Cpus { get; set; }
        public ICollection<int> RamSizes { get; set; }
        public ICollection<GpuViewModel> Gpus { get; set; }
        public ICollection<string> DirectXVersions { get; set; }
        public ICollection<long>/*?*/ FreeSpaceMb { get; set; }
        public ICollection<string> UserReviewsContents { get; set; }
        public decimal BasePrice { get; set; }
    }
}
