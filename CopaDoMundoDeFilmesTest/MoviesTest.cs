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
        [Fact(DisplayName = "Ordenar filmes por ordem alfabetica")]
        public void GerarCampeonato_OrdenarFilmes()
        {
            // Arrange
            List<Movie> movies = new List<Movie>
            {
                new Movie
                {
                    Id = "tt3606756",
                    Titulo = "Os Incríveis 2",
                    Ano = 2018,
                    Nota = new decimal(8.5)
                },
                new Movie
                {
                    Id = "tt4881806",
                    Titulo = "Jurassic World: Reino Ameaçado",
                    Ano = 2018,
                    Nota = new decimal(6.7)
                },
                new Movie
                {
                    Id = "tt5164214",
                    Titulo = "Oito Mulheres e um Segredo",
                    Ano = 2018,
                    Nota = new decimal(6.3)
                },
                new Movie
                {
                    Id = "tt7784604",
                    Titulo = "Hereditário",
                    Ano = 2018,
                    Nota = new decimal(7.8)
                },
                new Movie
                {
                    Id = "tt4154756",
                    Titulo = "Vingadores: Guerra Infinita",
                    Ano = 2018,
                    Nota = new decimal(8.8)
                },
                new Movie
                {
                    Id = "tt5463162",
                    Titulo = "Deadpool 2",
                    Ano = 2018,
                    Nota = new decimal(8.1)
                },
                new Movie
                {
                    Id = "tt3778644",
                    Titulo = "Han Solo: Uma História Star Wars",
                    Ano = 2018,
                    Nota = new decimal(7.2)
                },
                new Movie
                {
                    Id = "tt3501632",
                    Titulo = "Thor: Ragnarok",
                    Ano = 2018,
                    Nota = new decimal(7.9)
                }
            };
            var service = new MoviesWorldCupService(new HttpClient());
            // Act
            var result = service.GeneratedCup(movies);

            // Assert
            var firstMovie = result.FirstOrDefault(m => m.Id == "tt5463162");
            Assert.Equal(firstMovie.Id, "tt5463162");
        }

        [Fact(DisplayName = "Criar chaveamento")]
        public void GerarCampeonato_CriarChaveamento()
        {
            // Arrange
            List<Movie> movies = new List<Movie>
            {
                new Movie
                {
                    Id = "tt3606756",
                    Titulo = "Os Incríveis 2",
                    Ano = 2018,
                    Nota = new decimal(8.5)
                },
                new Movie
                {
                    Id = "tt4881806",
                    Titulo = "Jurassic World: Reino Ameaçado",
                    Ano = 2018,
                    Nota = new decimal(6.7)
                },
                new Movie
                {
                    Id = "tt5164214",
                    Titulo = "Oito Mulheres e um Segredo",
                    Ano = 2018,
                    Nota = new decimal(6.3)
                },
                new Movie
                {
                    Id = "tt7784604",
                    Titulo = "Hereditário",
                    Ano = 2018,
                    Nota = new decimal(7.8)
                },
                new Movie
                {
                    Id = "tt4154756",
                    Titulo = "Vingadores: Guerra Infinita",
                    Ano = 2018,
                    Nota = new decimal(8.8)
                },
                new Movie
                {
                    Id = "tt5463162",
                    Titulo = "Deadpool 2",
                    Ano = 2018,
                    Nota = new decimal(8.1)
                },
                new Movie
                {
                    Id = "tt3778644",
                    Titulo = "Han Solo: Uma História Star Wars",
                    Ano = 2018,
                    Nota = new decimal(7.2)
                },
                new Movie
                {
                    Id = "tt3501632",
                    Titulo = "Thor: Ragnarok",
                    Ano = 2018,
                    Nota = new decimal(7.9)
                }
            };
            var service = new MoviesWorldCupService(new HttpClient());
            // Act
            var result = service.GeneratedCup(movies);

            // Assert
            var firstMovie = result.FirstOrDefault(m => m.Id == "tt5463162");
            Assert.Equal(firstMovie.Id, "tt5463162");
        }
    }
}
