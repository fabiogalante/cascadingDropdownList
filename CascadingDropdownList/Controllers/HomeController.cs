using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadingDropdownList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObterArtistas()
        {
            
           //Obtem todos os albuns utilizando entity e LINQ.
            MvcMusicStoreEntities db = new MvcMusicStoreEntities();

            var artistas = db.Artist
                .Select(a => new {a.ArtistId, a.Name})
                .OrderBy(a => a.Name);
            return Json(artistas, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObterAlbuns(int id)
        {
            // Obtem os albuns por artista, utlizando entity framework e LINQ.
            MvcMusicStoreEntities db = new MvcMusicStoreEntities();

            var albuns = db.Album
                .Where(a => a.ArtistId == id)
                .Select(a => new {a.AlbumId, a.Title})
                .OrderBy(a => a.Title);
            return Json(albuns, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}