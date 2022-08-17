using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace Consulta_API_IMDB
{
    public static class APICall
    {
        public static async Task Teste()
        {

            // https://rapidapi.com/apidojo/api/online-movie-database/
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "31e1b79b2cmsh9432eca06e7d8f4p15ca8fjsn6108667f5de0");
            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "online-movie-database.p.rapidapi.com");

            try
            {
                var response = await httpClient.GetAsync($"https://online-movie-database.p.rapidapi.com/title/get-top-rated-movies");
                var code = response.StatusCode;
                var message = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<MoviesResponse>>(message).Take(2);

                foreach (var x in result)
                {
                    response = await httpClient.GetAsync($"https://online-movie-database.p.rapidapi.com{x.id.Insert(7, "get-details?tconst=")}");
                    code = response.StatusCode;
                    var newMessage = await response.Content.ReadAsStringAsync();
                    var fullResult = JsonSerializer.Deserialize<MoviesDetail>(newMessage);

                    Console.WriteLine($"Título: {fullResult.Title} | Ano de lançamento: {fullResult.Year} | Nota: {x.chartRating}"); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

    }
}
