using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        ApplicationDbContext _context;

        public RankingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public GameResult AddGameResult([FromBody] GameResult gameResult)
        {
            _context.GameResults.Add(gameResult);
            _context.SaveChanges();

            return gameResult;
        }

        [HttpGet]
        public List<GameResult> GetGameResults()
        {
            List<GameResult> results = _context.GameResults
                .OrderByDescending(item => item.Score)
                .ToList();

            return results;
        }

        [HttpPut]
        public bool UpdateGameResult([FromBody] GameResult gameResult)
        {
            var findResult = _context.GameResults
                .Where(x => x.Id == gameResult.Id)
                .FirstOrDefault();

            if(findResult == null) {
                return false;
            }

            findResult.UserName = gameResult.UserName;
            findResult.Score = gameResult.Score;
            _context.SaveChanges();

            return true;
        }

        [HttpDelete("{id}")]
        public bool DeleteGameResult(int id)
        {
            var findResult = _context.GameResults
             .Where(x => x.Id == id)
             .FirstOrDefault();

            if (findResult == null) {
                return false;
            }

            _context.GameResults.Remove(findResult);
            _context.SaveChanges();

            return true;
        }

        [HttpGet("{id}")]
        public GameResult GetGameResult(int id)
        {
            GameResult result = _context.GameResults
                .Where(item => item.Id == id)
                .FirstOrDefault();

            return result;
        }
    }
}
