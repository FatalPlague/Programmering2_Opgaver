using Microsoft.AspNetCore.Mvc;
using Pr02_MovieMania01.Persistence;
using Pr02_MovieMania01.Models;
using Pr02_MovieMania01.ViewModels;

namespace Pr02_MovieMania01.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            List<Movie> movies = MovieRepository.GetAll();
            return View(movies);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            MovieViewModel movieVM = new MovieViewModel
            {
                Directors = DirectorRepository.GetAll()
            };

            return View(movieVM);
        }

        [HttpPost]
        public IActionResult Add(MovieViewModel movieVM)
        {
            ViewBag.Action = "add";
            if (ModelState.IsValid)
            {
                MovieRepository.Add(movieVM.Movie);
                movieVM.Movie.Director = DirectorRepository.GetById((int)movieVM.Movie.DirectorId);
                return RedirectToAction(nameof(Index));
            }
            movieVM.Directors = DirectorRepository.GetAll();

            return View(movieVM);  
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";
            MovieViewModel movieVM = new MovieViewModel
            {
                Directors = DirectorRepository.GetAll()
            };

            if (id.HasValue)
            {
                movieVM.Movie = MovieRepository.GetById((int)id);
                return View(movieVM);
            }
            return View(movieVM);   
        }

        [HttpPost]
        public IActionResult Edit(MovieViewModel movieVM)
        {
            ViewBag.Action = "edit";
            if (ModelState.IsValid)
            {
                movieVM.Movie.Director = DirectorRepository.GetById((int)movieVM.Movie.DirectorId);
                MovieRepository.Update(movieVM.Movie.MovieId, movieVM.Movie);
                return RedirectToAction(nameof(Index));
            }
            movieVM.Directors = DirectorRepository.GetAll();
            return View(movieVM);
        }

        public IActionResult Delete(int id)
        {
            MovieRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
