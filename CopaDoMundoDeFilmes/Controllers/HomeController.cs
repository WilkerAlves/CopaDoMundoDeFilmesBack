using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CopaDoMundoDeFilmes.models;
using CopaDoMundoDeFilmes.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CopaDoMundoDeFilmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICopaDoMundoFilmeServiceService _copaDoMundoFilmeService;

        public HomeController(ICopaDoMundoFilmeServiceService copaDoMundoFilmeService)
        {
            _copaDoMundoFilmeService = copaDoMundoFilmeService;
        }

        [HttpGet]
        [Route("/filmes")]
        public async Task<IEnumerable<Movie>> Index()
        {
            return await _copaDoMundoFilmeService.OberTodos();
        }

        [HttpPost]
        [Route("/filmes")]
        public async Task<IActionResult> Post(List<Movie> movies)
        {
            if (movies.Count != 8)
            {
                return BadRequest("quantidade invalida");
            }

            return Ok(ModelState);
        }
    }
}
