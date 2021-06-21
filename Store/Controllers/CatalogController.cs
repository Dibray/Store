using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace Store.Controllers
{
    public class CatalogController : Controller
    {
        [HttpGet]
        public IActionResult Game(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            GameViewModel model = new GameViewModel();

            Games game = context.Games.Find(id);
            model.FaviconPath = game.FaviconPath;
            model.Title = game.Title;
            model.CoverPath = game.CoverPath;
            model.ReleaseDate = game.ReleaseDate.Date;
            model.Description = game.Description;
            model.BasePrice = game.BasePrice;

            model.Genres =
                (from g in context.GameGenre
                 where g.GameId == id
                 select g.Genre.Name).ToList();

            model.Platforms =
                (from p in context.SysReqPlatform
                 where p.GameId == id
                 select p.Platform.Name).ToList();

            model.Reception = GetReception(context, id);

            model.GalleryVideosPaths =
                (from p in context.GalleryVideosPaths
                 where p.GameId == id
                 select p.Path).ToList();

            model.GalleryImagesPaths =
                (from p in context.GalleryImagesPaths
                 where p.GameId == id
                 select p.Path).ToList();

            model.Cpus = GetCpus(context, id);

            model.RamSizes =
                (from r in context.MinSysReqRamsize
                 where r.GameId == id
                 select r.Ramsize.SizeMb).ToList();

            model.Gpus = GetGpus(context, id);

            model.DirectXVersions =
                (from d in context.MinSysReqDirectXversion
                 where d.GameId == id
                 select d.Version.Version).ToList();

            model.FreeSpaceMb = 
                (from s in context.MinSysReqFreeSpace
                 where s.GameId == id
                 select s.FreeSpaceMb.FreeSpaceMb).ToList();

            model.UserReviewsContents =
                (from r in context.UsersReviews
                 where r.GameId == id
                 select r.Content).ToList();

            return View(model);
        }

        private ICollection<ReceptionViewModel> GetReception(ApplicationDbContext context, int id)
        {
            ICollection<ReceptionViewModel> receptions;

            receptions =
                (from m in context.MagazineNote
                 where m.GameId == id
                 select new ReceptionViewModel { Name = m.Magazine.Name, Note = m.Note }).ToList();

            return receptions;
        }

        private ICollection<CpuViewModel> GetCpus(ApplicationDbContext context, int id)
        {
            ICollection<CpuViewModel> cpus;

            cpus =
                (from c in context.MinSysReqCpu
                 where c.GameId == id
                 select new CpuViewModel
                 {
                     Manufacturer = c.Cpu.Manufacturer.Name,
                     Model = c.Cpu.Model.Name,
                     Series = c.Cpu.Series.Name,
                     FrequencyMgh = c.Cpu.FrequencyMgh.FrequencyMgh
                 }
                ).ToList();

            return cpus;
        }

        private ICollection<GpuViewModel> GetGpus(ApplicationDbContext context, int id)
        {
            ICollection<GpuViewModel> gpus;

            gpus =
                (from g in context.MinSysReqGpu
                 where g.GameId == id
                 select new GpuViewModel
                 {
                     Manufacturer = g.Gpu.Manufacturer.Name,
                     Model = g.Gpu.Model.Name,
                     Series = g.Gpu.Series.Name,
                     VramMb = g.Gpu.VramMb.SizeMb,
                     FrequencyMgh = g.Gpu.FrequencyMgh.FrequencyMgh
                 }
                ).ToList();

            return gpus;
        }
    }
}
