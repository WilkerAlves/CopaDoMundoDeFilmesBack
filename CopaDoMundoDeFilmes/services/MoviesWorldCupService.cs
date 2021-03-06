﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CopaDoMundoDeFilmes.models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing.Template;

namespace CopaDoMundoDeFilmes.services
{
    public interface IMoviesWorldCup
    {
        Task<IEnumerable<Movie>> GetAll();
        List<Movie> GeneratedCup(List<Movie> movies);
    }

    public class MoviesWorldCupService : IMoviesWorldCup
    {
        private readonly HttpClient _httpClient;

        public MoviesWorldCupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<IEnumerable<Movie>> GetAll()
        {
            var response = await _httpClient.GetAsync("http://copafilmes.azurewebsites.net/api/filmes");
            return await DeserializeObjectResponse<IEnumerable<Movie>>(response);
        }

        public List<Movie> GeneratedCup(List<Movie> movies)
        {
            var moviesOrder = OrderMovies(movies);

            var resultQuarterFinals = QuarterFinals(moviesOrder);

            var resultSemiFinal = SemiFinal(resultQuarterFinals);

            return Final(resultSemiFinal);

        }

        public List<Movie> OrderMovies(List<Movie> movies)
        {
            return movies.OrderBy(m => m.Titulo).ToList();
        }

        public List<Movie> QuarterFinals(List<Movie> movies)
        {
            var indexFirst = 0;
            var indexLast = movies.Count -1;
            List<Movie> resultList = new List<Movie>();
            for (int i = 0; i < 4; i++)
            {
                var m1 = movies[indexFirst];
                var m2 = movies[indexLast];
                resultList.Add(Champion(m1, m2));
                indexLast--;
                indexFirst++;
            }
            return resultList;
        }

        public List<Movie> SemiFinal(List<Movie> movies)
        {
            var indexFirst = 0;
            List<Movie> resultList = new List<Movie>();
            for (int i = 0; i < 2; i++)
            {
                var adversario = indexFirst + 1;
                var m1 = movies[indexFirst];
                var m2 = movies[adversario];
                resultList.Add(Champion(m1, m2));
                indexFirst = adversario + 1;
            }
            return resultList;
        }

        public List<Movie> Final(List<Movie> movies)
        {
            if (movies[0].Nota > movies[1].Nota)
            {
                return new List<Movie> { movies[0], movies[1] };
            }
            else
            {
                return new List<Movie> { movies[1], movies[0] };
            }
        }

        public Movie Champion(Movie m1, Movie m2)
        {
            if (m1.Nota > m2.Nota)
            {
                return m1;
            }
            else if (m1.Nota < m2.Nota)
            {
                return m2;
            }
            else
            {
                if (String.CompareOrdinal(m1.Titulo.ToUpper(), m2.Titulo.ToUpper()) >= 1)
                {
                   return m2;
                }
                else
                {
                    return m1;
                }
            }

        }

        private async Task<T> DeserializeObjectResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }
    }
}