using System.Net.Http;
using System.Net.Http.Json;

namespace CharacterManager
{
    public class CharacterService
    {
        private readonly HttpClient _httpClient;
        private string BaseUrl = "http://localhost:5263/api/Characters";
        public CharacterService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Character>>(BaseUrl);
            return response ?? new List<Character>();
        }

        public async Task<Character> GetCharactersByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Character>($"{BaseUrl}/{id}");
        }

        public async Task<Character> AddCharacterAsync(Character character)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, character);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Character>();
        }

        public async Task<bool> UpdateCharacterAsync(Character character)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{character.Id}", character);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
