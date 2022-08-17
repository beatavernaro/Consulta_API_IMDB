using System.Text.Json.Serialization;


namespace Consulta_API_IMDB
{
    public class MoviesDetail
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("year")]
        public int? Year { get; set; }

    }
}
