using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore.ViewModels;
using MVCMusicStore.Models;

namespace MVCMusicStore.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
			var genres = new List<string> { "Rock", "Jazz", "Country", "Pop", "Disco" };

			var viewModel = new StoreIndexViewModel
			{
				NumberOfGenres = genres.Count(),
				Genres = genres
			};

			ViewBag.Starred = new List<string> { "Rock", "Jazz" };

            return View(viewModel);
        }

		public ActionResult Movie()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Movie(MovieViewModel movie)
		{
			if(movie != null)
			{
				movie.stars++;
			}

			ModelState.Clear(); //!!!oorspronkelijke waarden clearen en nieuwe er terug in zetten

			return View(movie);
		}

		public ActionResult Browse(string genre)
		{
			var genreModel = new Genre()
			{
				Name = genre
			};

			var albums = new List<Album>()
			{
				new Album() {Title = genre + " Album 1" },
				new Album() {Title = genre + " Album 2" }
			};

			var viewModel = new StoreBrowseViewModel()
			{
				Genre = genreModel,
				Albums = albums
			};

			return View(viewModel);
		}

		public ActionResult Details(int id)
		{
			var album = new Album { Title = "Sample Album" };

			return View(album);
		}
    }
}