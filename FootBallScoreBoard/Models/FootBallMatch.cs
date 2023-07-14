using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallScoreBoard.Models
{
    public class FootBallMatch
    {
        public string? HomeTeam { get; set; }
        public string? AwayTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public DateTime StartTime {  get; set; }
    }
}
