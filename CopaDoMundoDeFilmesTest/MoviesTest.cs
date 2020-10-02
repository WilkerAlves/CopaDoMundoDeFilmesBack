using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using CopaDoMundoDeFilmes.models;
using CopaDoMundoDeFilmes.services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CopaDoMundoDeFilmesTest
{
    public class MoviesTest
    {
        private readonly List<Movie> _movies;
        private readonly MoviesWorldCupService _service;

        public MoviesTest()
        {
            _service = new MoviesWorldCupService(new HttpClient());
            _movies = new List<Movie>
            {
                new Movie
                {
                    Id = "tt3606756",
                    Titulo = "Os Incríveis 2",
                    Ano = 2018,
                    Nota = 8.5
                },
                new Movie
                {
                    Id = "tt4881806",
                    Titulo = "Jurassic World: Reino Ameaçado",
                    Ano = 2018,
                    Nota = 6.7
                },
                new Movie
                {
                    Id = "tt5164214",
                    Titulo = "Oito Mulheres e um Segredo",
                    Ano = 2018,
                    Nota = 6.3
                },
                new Movie
                {
                    Id = "tt7784604",
                    Titulo = "Hereditário",
                    Ano = 2018,
                    Nota = 7.8
                },
                new Movie
                {
                    Id = "tt4154756",
                    Titulo = "Vingadores: Guerra Infinita",
                    Ano = 2018,
                    Nota = 8.8
                },
                new Movie
                {
                    Id = "tt5463162",
                    Titulo = "Deadpool 2",
                    Ano = 2018,
                    Nota = 8.1
                },
                new Movie
                {
                    Id = "tt3778644",
                    Titulo = "Han Solo: Uma História Star Wars",
                    Ano = 2018,
                    Nota = 7.2
                },
                new Movie
                {
                    Id = "tt3501632",
                    Titulo = "Thor: Ragnarok",
                    Ano = 2018,
                    Nota = 7.9
                }
            };
        }


        [Fact(DisplayName = "Ordenar filmes por ordem alfabetica")]
        public void OrderMovies()
        {
            // Arrange
            

            // Act
            var result = _service.OrderMovies(_movies);

            // Assert
            Assert.Equal("tt5463162", result[0].Id);
            Assert.Equal("tt3778644", result[1].Id);
            Assert.Equal("tt7784604", result[2].Id);
            Assert.Equal("tt4881806", result[3].Id);
            Assert.Equal("tt5164214", result[4].Id);
            Assert.Equal("tt3606756", result[5].Id);
            Assert.Equal("tt3501632", result[6].Id);
            Assert.Equal("tt4154756", result[7].Id);
        }

        [Fact(DisplayName = "retornar lista dos confrontos das quartas de finais")]
        public void GeneratedCup_QuarterFinals()
        {
            // Arrange
            var moviesOrder = _service.OrderMovies(_movies);

            // Act
            var result = _service.QuarterFinals(moviesOrder);

            // Assert
            var m1 = result.FirstOrDefault(m => m.Id == "tt4154756");
            var m2 = result.FirstOrDefault(m => m.Id == "tt3501632");
            var m3 = result.FirstOrDefault(m => m.Id == "tt3606756");
            var m4 = result.FirstOrDefault(m => m.Id == "tt4881806");

            Assert.NotNull(m1);
            Assert.NotNull(m2);
            Assert.NotNull(m3);
            Assert.NotNull(m4);
            
        }

        [Fact(DisplayName = "retornar lista dos confrontos da semifinal")]
        public void GeneratedCup_SemiFinal()
        {
            // Arrange
            var moviesOrder = _service.OrderMovies(_movies);
            var resultQuarterFinals = _service.QuarterFinals(moviesOrder);

            // Act
            var result = _service.SemiFinal(resultQuarterFinals);

            // Assert
            var m1 = result.FirstOrDefault(m => m.Id == "tt4154756");
            Assert.NotNull(m1);
            var m2 = result.FirstOrDefault(m => m.Id == "tt3606756");
            Assert.NotNull(m2);
        }

        [Fact(DisplayName = "retornar lista dos confrontos da semifinal")]
        public void GeneratedCup_Final()
        {
            // Arrange
            var moviesOrder = _service.OrderMovies(_movies);
            var resultQuarterFinals = _service.QuarterFinals(moviesOrder);
            var resultSemiFinal = _service.SemiFinal(resultQuarterFinals);

            // Act
            var result = _service.Final(resultSemiFinal);

            // Assert
            Assert.Equal("tt4154756", result[0].Id);
        }

        [Fact(DisplayName = "retornar lista dos confrontos da semifinal")]
        public void GeneratedCup_Champion()
        {
            // Arrange
            var movie1 = new Movie
            {
                Id = "tt3606756",
                Titulo = "Os Incríveis 2",
                Ano = 2018,
                Nota = 8.5
            };
            var movie2 = new Movie
            {
                Id = "tt4881806",
                Titulo = "Jurassic World: Reino Ameaçado",
                Ano = 2018,
                Nota = 8.5
            };

            // Act
            var result = _service.Champion(movie1, movie2);

            // Assert
            Assert.Equal("tt4881806", result.Id);
        }
    }
}
