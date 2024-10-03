using Newtonsoft.Json;

namespace RepoFinder.Api.DTOs
{
    public class ErrorResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
    }
}
