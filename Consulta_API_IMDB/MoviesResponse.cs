using System.Text.Json.Serialization;


namespace Consulta_API_IMDB
{
    public class MoviesResponse
    {
        [JsonPropertyName("id")]
        public string? id { get; set; }

        [JsonPropertyName("chartRating")]
        public float? chartRating { get; set; }
        
    }
}
