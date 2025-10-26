using AgricultureView.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AgricultureView.Utility
{
    public class GlobalVeriable : IGlobalVeriable
    {
        private readonly string baseURL;
        private HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GlobalVeriable(IOptions<MySettingModel> app, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            baseURL = app.Value.WebApiBaseUrl;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(baseURL);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<ApiResponse> GetMethod(string url)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ApiResponse>(response);
            return data;
        }

        public async Task<ApiResponse> PostMethod(string url, object model)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _httpClient.PostAsJsonAsync(url, model).Result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ApiResponse>(response);
            return data;
        }
        public async Task<ApiResponse> PostFileMethod(string url, object model)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _httpClient.PostAsync(url, (HttpContent)model).Result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ApiResponse>(response);
            return data;
        }
        public async Task<ApiResponse> PostFileMethodWithPartial(string url, HttpContent content)
        {
            // Set headers for JSON
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Attach the authorization token if available
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Send the POST request
            var responseMessage = await _httpClient.PostAsync(url, content);

            // Ensure the response is successful, throw an exception otherwise
            responseMessage.EnsureSuccessStatusCode();

            // Read and deserialize the response content
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ApiResponse>(responseString);

            return data;
        }
        public void SetToken(string Token)
        {
            if (!string.IsNullOrWhiteSpace(Token))
            {
                _httpContextAccessor.HttpContext.Session.SetString("token", Token);
            }
        }
        public string BaseUrl()
        {
            var Url = baseURL;
            return baseURL.Replace("/api/", "");
        }
    }
}
