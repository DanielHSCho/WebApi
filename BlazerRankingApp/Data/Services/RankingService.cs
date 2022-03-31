using Newtonsoft.Json;
using SharedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazerRankingApp.Data.Services
{
    public class RankingService
    {
        HttpClient _httpClient;

        public RankingService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<GameResult> AddGameResult(GameResult gameResult)
        {
            string jsonStr = JsonConvert.SerializeObject(gameResult);
            var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("api/ranking", content);

            if(result.IsSuccessStatusCode == false) {
                throw new Exception("Add GameResult Failed");
            }

            var resultContent = await result.Content.ReadAsStringAsync();
            GameResult resultGameResult = JsonConvert.DeserializeObject<GameResult>(resultContent);
            return resultGameResult;
        }

        public async Task<List<GameResult>> GetGameResultsAsync()
        {
            var result = await _httpClient.GetAsync("api/ranking");

            var resultContent = await result.Content.ReadAsStringAsync();
            List<GameResult> resGameResults = JsonConvert.DeserializeObject<List<GameResult>>(resultContent);
            return resGameResults;
        }

        public async Task<bool> UpdateGameResult(GameResult gameResult)
        {
            string jsonStr = JsonConvert.SerializeObject(gameResult);
            var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync("api/ranking", content);

            if (result.IsSuccessStatusCode == false) {
                throw new Exception("Update GameResult Failed");
            }

            return true;
        }

        public async Task<bool> DeleteGameResult(GameResult gameResult)
        {
            var result = await _httpClient.DeleteAsync($"api/ranking/{gameResult.Id}");

            if(result.IsSuccessStatusCode == false) {
                throw new Exception("DeleteGameResult Failed");
            }

            return true;
        }
    }
}
