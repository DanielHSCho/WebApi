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

        public Task<List<GameResult>> GetGameResultsAsync()
        {
            return Task.FromResult(results);
        }

        public Task<bool> UpdateGameResult(GameResult gameResult)
        {
            return Task.FromResult(true);
        }

        public Task<bool> DeleteGameResult(GameResult gameResult)
        {
            return Task.FromResult(true);
        }
    }
}
