using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StadiumAPI.DTOs;

namespace StadiumAPI.Services
{
    public class FirebaseService : IFirebaseService
    {
        private readonly HttpClient _httpClient;
        private readonly string _firebaseUrl = "https://chatbox-993b2-default-rtdb.firebaseio.com";

        public FirebaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddStadiumAsync(ReadStadiumDTO stadium)
        {
            var data = new
            {
                id = stadium.Id,
                lat = stadium.Latitude,
                lng = stadium.Longitude,
                name = stadium.Name
            };

            var json = JsonSerializer.Serialize(data);

            var url = $"{_firebaseUrl}/customPlaces/{stadium.Id}.json";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteStadiumAsync(int stadiumId)
        {
            var url = $"{_firebaseUrl}/customPlaces/{stadiumId}.json";
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
