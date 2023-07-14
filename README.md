# LiveFootballScore
This project implements a Football Scoreboard Class Library that allows users to manage and track football matches, update scores, and retrieve match summaries. It provides a ScoreBoardService class that encapsulates the core functionalities of the system. 
## Features
*	Start a new football match with home and away team names. 
*	Update the score of an ongoing match. 
*	Finish a match and remove it from the scoreboard. 
*	Retrieve a summary of all matches, sorted by total score and start time. 

## Assumptions and Notes 
*	The code assumes that the FootBallMatch model class is properly implemented in the FootBallScoreBoard.Models namespace. 
*	The code assumes that the IScoreBoard interface is defined in the FootBallScoreBoard.Contracts namespace.
*	The code relies on the System.Linq namespace for LINQ operations such as sorting and filtering the match list. 
*	The code assumes that the ScoreBoardService class will be used in a multi-threaded or concurrent environment, and proper synchronization or thread-safety measures should be implemented if required. 
*	The provided unit test class MatchScoreTest demonstrates the usage and testing of the ScoreBoardService class. It uses the xUnit testing framework, and additional test cases can be added to cover different scenarios and edge cases. 
*	The code uses the DateTime.Now property to set the start time of a new match. Depending on the requirements, a more accurate time source or timezone considerations may need to be implemented.
