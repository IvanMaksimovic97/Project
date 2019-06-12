using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IGetMoviesCommand getMovies;
        private readonly IGetOneMovieCommand getOneMovie;
        private readonly IGetActorsCommand getActors;
        private readonly IGetGenresCommand getGenres;
        private readonly ICreateMovieCommand createMovie;
        private readonly IDeleteMovieCommand deleteMovie;
        private readonly IEditMovieCommand editMovie;

        public MoviesController(IGetMoviesCommand getMovies, IGetActorsCommand getActors, IGetGenresCommand getGenres, ICreateMovieCommand createMovie, IDeleteMovieCommand deleteMovie, IEditMovieCommand editMovie, IGetOneMovieCommand getOneMovie)
        {
            this.getMovies = getMovies;
            this.getActors = getActors;
            this.getGenres = getGenres;
            this.createMovie = createMovie;
            this.deleteMovie = deleteMovie;
            this.editMovie = editMovie;
            this.getOneMovie = getOneMovie;
        }

        // GET: Movies
        public ActionResult Index(MovieSearch search)
        {
            var filmovi = getMovies.Execute(search);
            return View(filmovi);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.Zanrovi = getGenres.Execute(null);
            ViewBag.Glumci = getActors.Execute(null);
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMovieDTO request)
        {
            if (!ModelState.IsValid)
            {
                TempData["greska"] = "Greska pri unosu";
                RedirectToAction("create");
            }

            try
            {
                createMovie.Execute(request);

                return RedirectToAction(nameof(Index));
            }
            catch(EntityAlreadyExist e)
            {
                TempData["error"] = e.Message;
            }
            catch(Exception e)
            {
                TempData["error"] = e.Message;
            }
            return View();
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            var film = getOneMovie.Execute(id);

            EditMovieDTO filmKonvertovan = new EditMovieDTO
            {
                MovieId = film.Id,
                Title = film.Title,
                StartShowingFrom = film.StartShowingFrom,
                DurationMins = film.DurationMins,
                Year = film.Year,
                PictureUrl = film.PictureUrl
            };
            return View(filmKonvertovan);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditMovieDTO request)
        {
            if (!ModelState.IsValid)
            {
                TempData["greska"] = "Greska pri unosu";
                RedirectToAction("create");
            }

            try
            {
                editMovie.Execute(request);

                return RedirectToAction(nameof(Index));
            }
            catch(EntityNotFoundException e)
            {
                TempData["greska"] = e.Message;
            }
            catch(Exception e)
            {
                TempData["greska"] = e.Message;
            }
            return View();
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            var film = getOneMovie.Execute(id);
            return View(film);
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MovieDTO collection)
        {
            try
            {
                deleteMovie.Execute(id);

                return RedirectToAction(nameof(Index));
            }
            catch(EntityNotFoundException e)
            {
                TempData["error"] = e.Message;
            }
            catch(Exception e)
            {
                TempData["error"] = e.Message;
            }
            return View();
        }
    }
}