using FootBallScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallScoreBoard.Contracts
{
    public interface IScoreBoard
    {
        void StartNewMatch(string homeTeam, string awayTeam);
        void UpdateScore(string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore);
        void FinishMatch(string homeTeam, string awayTeam);
        List<FootBallMatch> GetMatchesSummary();
    }
}
