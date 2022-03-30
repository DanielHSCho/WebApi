using BlazerRankingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazerRankingApp.Data.Services
{
    public class RankingService
    {
        ApplicationDbContext _context;

        public RankingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<GameResult> AddGameResult(GameResult gameResult)
        {
            _context.GameResults.Add(gameResult);
            _context.SaveChanges();

            return Task.FromResult(gameResult);
        }

        public Task<List<GameResult>> GetGameResultsAsync()
        {
            List<GameResult> results = _context.GameResults
                .OrderByDescending(item=>item.Score)
                .ToList();

            return Task.FromResult(results);
        }

        public Task<bool> UpdateGameResult(GameResult gameResult)
        {
            var findResult = _context.GameResults
                .Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if(findResult == null) {
                return Task.FromResult(false);
            }

            findResult.UserName = gameResult.UserName;
            findResult.Score = gameResult.Score;
            _context.SaveChanges();

            return Task.FromResult(true);
        }

        public Task<bool> DeleteGameResult(GameResult gameResult)
        {
            var findResult = _context.GameResults
                .Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if (findResult == null) {
                return Task.FromResult(false);
            }

            _context.GameResults.Remove(gameResult);
            _context.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
