using SharedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public Task<GameResult> AddGameResult(GameResult gameResult)
        {
            return Task.FromResult(gameResult);
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
