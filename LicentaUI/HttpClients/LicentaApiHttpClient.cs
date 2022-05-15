using LicentaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LicentaUI.HttpClients
{
    public class LicentaApiHttpClient
    {
        private JsonSerializerOptions jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private HttpClient _client;
        private Uri _baseAddress;

        public LicentaApiHttpClient()
        {
            _client = new HttpClient();
            _baseAddress = new Uri("https://localhost:5001/");

            jsonOptions.Converters.Add(new JsonStringEnumConverter());
        }

        public async Task<IEnumerable<string>> LoginUserAsync(LoginUserModel loginUserModel)
        {
            var url = new Uri(_baseAddress, "licenta/auth/login");
            var body = JsonSerializer.Serialize(loginUserModel);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, requestContent);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return response.Headers.GetValues("Set-Cookie");
            }

            return Enumerable.Empty<string>();
        }

        public async Task<bool> RegisterUserAsync(RegisterUserModel registerUserModel)
        {
            var url = new Uri(_baseAddress, "licenta/auth/register");
            var body = JsonSerializer.Serialize(registerUserModel);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, requestContent);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BookModel>> GetAllBooksAsync()
        {
            var url = new Uri(_baseAddress, "licenta/book/get-all");
            var response = await _client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<BookModel>>(content, jsonOptions);
            }
            throw new Exception(response.StatusCode.ToString());
        }

        public async Task<IEnumerable<FilmModel>> GetAllFilmsAsync()
        {
            var url = new Uri(_baseAddress, "licenta/film/get-all");
            var response = await _client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<FilmModel>>(content, jsonOptions);
            }
            throw new Exception(response.StatusCode.ToString());
        }

        public async Task<IEnumerable<SeriesModel>> GetAllSeriesAsync()
        {
            var url = new Uri(_baseAddress, "licenta/series/get-all");
            var response = await _client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<SeriesModel>>(content, jsonOptions);
            }
            throw new Exception(response.StatusCode.ToString());
        }

        public async Task<IEnumerable<AppointmentModel>> GetAllApointmentForUser()
        {
            var url = new Uri(_baseAddress, "licenta/appointment/get-appointment-for-user");
            var response = await _client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<AppointmentModel>>(content, jsonOptions);
            }
            throw new Exception(response.StatusCode.ToString());
        }

        public async Task<IEnumerable<ReviewBookModel>> GetReviewBookByStatus(Status status)
        {
            var url = new Uri(_baseAddress, "licenta/review-book/get-by-status/" + status);
            var response = await _client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<ReviewBookModel>>(content, jsonOptions);
            }
            throw new Exception(response.StatusCode.ToString());
        }

        public async Task<IEnumerable<ReviewFilmModel>> GetReviewFilmByStatus(Status status)
        {
            var url = new Uri(_baseAddress, "licenta/review-film/get-by-status/" + status);
            var response = await _client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<ReviewFilmModel>>(content, jsonOptions);
            }
            throw new Exception(response.StatusCode.ToString());
        }

        public async Task<IEnumerable<ReviewSeriesModel>> GetReviewSeriesByStatus(Status status)
        {
            var url = new Uri(_baseAddress, "licenta/review-series/get-by-status/" + status);
            var response = await _client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<ReviewSeriesModel>>(content, jsonOptions);
            }
            throw new Exception(response.StatusCode.ToString());
        }
    }
}