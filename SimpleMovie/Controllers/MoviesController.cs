using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleMovie.Data;
using SimpleMovie.Models;
using SimpleMovie.Repository;
using SimpleMovie.Service;

namespace SimpleMovie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        
        // Since all these classes were made for Razor. methods are probably returning wong values.

        private MovieAppService service = new MovieAppService();

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            var movies = service.MovieRepository.Get();
            return movies.ToList();
            
        }

        // GET: Movies
        public IActionResult Index(string searchString)
        {
            var movies = from m in service.MovieRepository.Get(includeProperties: "Category")
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.title.Contains(searchString));
            }

            return View(movies.ToList());
        }
        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = service.MovieRepository.GetByID(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("id,title,year,description,rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                service.MovieRepository.Insert(movie);
                service.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = service.MovieRepository.GetByID(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("id,title,year,description,rating")] Movie movie)
        {
            if (id != movie.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    service.MovieRepository.Update(movie);
                    service.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = service.MovieRepository.GetByID(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = service.MovieRepository.GetByID(id);
            service.MovieRepository.Delete(id);
            service.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {

            var movie = service.MovieRepository.GetByID(id);

            return movie.id == id;
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

    }
}
