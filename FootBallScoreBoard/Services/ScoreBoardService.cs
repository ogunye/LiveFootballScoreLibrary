using FootBallScoreBoard.Contracts;
using FootBallScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootBallScoreBoard.Services
{
    public class ScoreBoardService : IScoreBoard
    {
        public List<FootBallMatch> matches = new List<FootBallMatch>();

        public void FinishMatch(string homeTeam, string awayTeam)
        {
            var match = GetMatch(homeTeam, awayTeam);
            if (match != null)
            {
                matches.Remove(match);
            }
        }

        public List<FootBallMatch> GetMatchesSummary()
        {
            var summary = matches
                .OrderByDescending(m => m.HomeTeamScore + m.AwayTeamScore)
                .ThenByDescending(m => m.StartTime);
            return summary.ToList();
        }

        public void StartNewMatch(string homeTeam, string awayTeam)
        {
            if(!string.IsNullOrEmpty(homeTeam) && !string.IsNullOrEmpty(awayTeam))
            {
                var match = new FootBallMatch
                {

                    HomeTeam = homeTeam,
                    AwayTeam = awayTeam,
                    HomeTeamScore = 0,
                    AwayTeamScore = 0,
                    StartTime = DateTime.Now
                };

                matches.Add(match);
            }            
        }

        public void UpdateScore(string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore)
        {
            var match = GetMatch(homeTeam, awayTeam);

            if (match != null)
            {
                if(homeTeamScore >= 0 && awayTeamScore >= 0)
                {
                    match.HomeTeamScore = homeTeamScore;
                    match.AwayTeamScore = awayTeamScore;
                }
            }
        }

       

       

        private FootBallMatch? GetMatch(string homeTeam, string awayTeam)
        {
            return matches.FirstOrDefault(m=> m.HomeTeam == homeTeam && m.AwayTeam == awayTeam);
        }
    }
}
