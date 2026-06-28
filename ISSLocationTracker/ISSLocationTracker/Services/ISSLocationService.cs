using System.Text.Json;
using ISSLocationTracker.Models;

namespace ISSLocationTracker.Services {
    public class ISSLocationService {
        private HttpClient _httpClient;
        
        private const string Url = "https://api.wheretheiss.at/v1/satellites/25544";

        public ISSLocationService() {
            _httpClient = new HttpClient();
        }

        public async Task<ISSLocation?> GetLocationAsync() {
            try {
                var response = await _httpClient.GetAsync(Url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ISSLocation>(json);

            } catch {
                return null;
            }
        }
    }
}
