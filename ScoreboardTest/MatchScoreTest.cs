using FootBallScoreBoard.Models;
using FootBallScoreBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardTest
{
    public class MatchScoreTest
    {
        private ScoreBoardService scoreboard;

        public MatchScoreTest()
        {
            scoreboard = new ScoreBoardService();
        }


        [Fact]
        public void StartNewMatch_AddMatchToScoreBoard()
        {            
            //Act
            scoreboard.StartNewMatch("Home Team", "Away Team");

            //Assert
            Assert.Single(scoreboard.GetMatchesSummary());
            var match = scoreboard.GetMatchesSummary()[0];
            Assert.Equal("Home Team", match.HomeTeam);
            Assert.Equal("Away Team", match.AwayTeam);
            Assert.Equal(0, match.HomeTeamScore);
            Assert.Equal(0, match.AwayTeamScore);
        }

        [Fact]
        public void StartNewMatch_WithInvalidTeamNames_DoesNotAddMatchToScoreBoard()
        {
            // Act
            scoreboard.StartNewMatch("", "Away Team");

            // Assert
            Assert.Empty(scoreboard.GetMatchesSummary());
        }

        [Fact]
        public void UpdateScore_ModifiedScoreBoard()
        {
            //Arrange
            scoreboard.StartNewMatch("Home Team", "Away Team");

            //Act
            scoreboard.UpdateScore("Home Team", "Away Team", 2, 1);

            //Assert
            var match = scoreboard.GetMatchesSummary()[0];
            Assert.Equal(2, match.HomeTeamScore);
            Assert.Equal(1, match.AwayTeamScore);
        }

        [Fact]
        public void UpdateScore_WithNegativeValues_DoesNotModifyScoreBoard()
        {
            // Arrange
            scoreboard.StartNewMatch("Home Team", "Away Team");

            // Act
            scoreboard.UpdateScore("Home Team", "Away Team", -1, 3);

            // Assert
            var match = scoreboard.GetMatchesSummary()[0];
            Assert.Equal(0, match.HomeTeamScore);
            Assert.Equal(0, match.AwayTeamScore);
        }

        [Fact]
        public void FinishMatch_RemovesMatchFromScoreboard()
        {
            // Arrange           
            scoreboard.StartNewMatch("Home Team", "Away Team");

            // Act
            scoreboard.FinishMatch("Home Team", "Away Team");

            // Assert
            Assert.Empty(scoreboard.GetMatchesSummary());
        }

        [Fact]
        public void FinishMatch_ForNonexistentMatch_DoesNotModifyScoreboard()
        {
            // Arrange
            scoreboard.StartNewMatch("Home Team", "Away Team");

            // Act
            scoreboard.FinishMatch("Nonexistent Team", "Away Team");

            // Assert
            Assert.Single(scoreboard.GetMatchesSummary());
        }

        [Fact]
        public void GetMatchesSummary_ReturnsMatchesOrderedByTotalScoreAndStartTime()
        {
            //Arranage
            var matches = new List<FootBallMatch>
            {
                new FootBallMatch{ HomeTeam = "Team A", AwayTeam = "Team B", HomeTeamScore = 2, AwayTeamScore = 1, StartTime = DateTime.UtcNow},
                new FootBallMatch { HomeTeam = "Team C", AwayTeam = "Team D", HomeTeamScore = 3, AwayTeamScore = 2, StartTime = DateTime.Now.AddHours(-1) },
                new FootBallMatch { HomeTeam = "Team E", AwayTeam = "Team F", HomeTeamScore = 0, AwayTeamScore = 0, StartTime = DateTime.Now.AddHours(1) }
            };

            var expectedSummary = new List<FootBallMatch>
            {
                matches[1], // Sorted by score: Team C vs. Team D
                matches[0], // Then sorted by score: Team A vs. Team B
                matches[2] // Then sorted by start time: Team E vs. Team F
            };

            var footballMatch = new ScoreBoardService
            {
               matches = matches // Set the matches directly to the property
            }; ;  
            
            // Act
            var actualSummary = footballMatch.GetMatchesSummary();

            //Assert
            Assert.Equal(expectedSummary, actualSummary);
           
        }
    }
}
