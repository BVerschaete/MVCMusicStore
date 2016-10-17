using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore.ViewModels;

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
    }
}