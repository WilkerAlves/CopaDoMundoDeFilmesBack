using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CopaDoMundoDeFilmes.models;
using Microsoft.AspNetCore.Mvc;

namespace CopaDoMundoDeFilmes.services
{
    public interface ICopaDoMundoFilmeServiceService
    {
        Task<IEnumerable<Movie>> OberTodos();
    }

    public class CopaDoMundoFilmeService : ICopaDoMundoFilmeServiceService
    {
        private readonly HttpClient _httpClient;

        public CopaDoMundoFilmeService(HttpClient httpClient)
        {
            //httpClient.BaseAddress = new Uri("http://copafilmes.azurewebsites.net/api");
            _httpClient = httpClient;
        }
        
        public async Task<IEnumerable<Movie>> OberTodos()
        {
            var response = await _httpClient.GetAsync("http://copafilmes.azurewebsites.net/api/filmes");
            return await DeserializarObjetoResponse<IEnumerable<Movie>>(response);
        }

        private async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };


            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }
    }
}