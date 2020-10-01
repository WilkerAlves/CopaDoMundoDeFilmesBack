using System.Collections.Generic;
using System.Threading.Tasks;
using CopaDoMundoDeFilmes.models;
using CopaDoMundoDeFilmes.services;
using Microsoft.AspNetCore.Mvc;

namespace CopaDoMundoDeFilmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesWorldCup _moviesWorldCupService;
        public int QtyMaximum { get; private set; }

        public MovieController(IMoviesWorldCup moviesWorldCupService)
        {
            _moviesWorldCupService = moviesWorldCupService;
            QtyMaximum = 8;
        }

        [HttpGet]
        [Route("/movies")]
        public async Task<IEnumerable<Movie>> Index()
        {
            return await _moviesWorldCupService.GetAll();
        }

        [HttpPost]
        [Route("/movies")]
        public async Task<IActionResult> Post(List<Movie> movies)
        {
            if (movies.Count != 8) return BadRequest("invalid quantity");
            var result = _moviesWorldCupService.GeneratedCup(movies);
            return Ok(result);
        }
    }
}
