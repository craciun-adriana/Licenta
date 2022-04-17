using LicentaUI.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LicentaUI.HttpClients
{
    public class LicentaApiHttpClient
    {
        private HttpClient _client;
        private Uri _baseAddress;

        public LicentaApiHttpClient()
        {
            _client = new HttpClient();
            _baseAddress = new Uri("https://localhost:5001/");
        }

        public async Task<bool> LoginUserAsync(LoginUserModel loginUserModel)
        {
            var url = new Uri(_baseAddress, "licenta/auth/login");
            var body = JsonSerializer.Serialize(loginUserModel);
            var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, requestContent);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }

            return false;
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
    }
}