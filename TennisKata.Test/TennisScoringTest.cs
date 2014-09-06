using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisKata.Test
{
    [TestClass]
    public class TennisScoringTest
    {
        private TennisGame game;
        private List<Player> players;
        private Player player1;
        private Player player2;
        private IGameRules gameRules;

        [TestInitialize]
        public void Setup()
        {
            players = new List<Player>();
            player1 = new Player { Name = "Player 1" };
            players.Add(player1);
            player2 = new Player { Name = "Player 2" };
            players.Add(player2);
            gameRules = new TennisGameRules(); 
            game = new TennisGame(players, gameRules);
            
        }

        [TestMethod]
        public void LoveLoveWhenGameStart()
        {
            Assert.AreEqual(game.GameScore, "love-love");
        }

        [TestMethod]
        public void FifteenLoveWhenTheServerScoresOnce()
        {
            game.RoundScore(player1);
            Assert.AreEqual(game.GameScore, "fifteen-love");
        }

        [TestMethod]
        public void ThirtyLoveWhenTheServerScoresTwice()
        {
            game.RoundScore(player1);
            game.RoundScore(player1);
            Assert.AreEqual(game.GameScore, "thirty-love");
        }

        [TestMethod]
        public void FortyLoveWhenTheServerScoresThreeTimes()
        {
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);
            Assert.AreEqual(game.GameScore, "forty-love");
        }

        [TestMethod]
        public void LoveFifteenWhenTheNonServerScoresOnce()
        {
            game.RoundScore(player2);
            Assert.AreEqual(game.GameScore, "love-fifteen");
        }

        [TestMethod]
        public void LoveThirtyWhenTheNonServerScoresTwice()
        {
            game.RoundScore(player2);
            game.RoundScore(player2);
            Assert.AreEqual(game.GameScore, "love-thirty");
        }

        [TestMethod]
        public void LoveFortyWhenTheNonServerScoresThreeTimes()
        {
            game.RoundScore(player2);
            game.RoundScore(player2);
            game.RoundScore(player2);
            Assert.AreEqual(game.GameScore, "love-forty");
        }

        [TestMethod]
        public void GameWinWhenTheServerScoreFourTimesAndTwoMoreOpponent()
        {
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);

            game.RoundScore(player2);
            game.RoundScore(player2);

            Assert.AreEqual(game.GameScore, players[0].Name + " win");
        }

        [TestMethod]
        public void DeuceWhenBothPlayersScoreThreeTimes()
        {
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);

            game.RoundScore(player2);
            game.RoundScore(player2);
            game.RoundScore(player2);

            Assert.AreEqual(game.GameScore, "deuce");
        }

        [TestMethod]
        public void DeuceWhenBothPlayersScoreMoreThanThreeTimes()
        {
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);

            game.RoundScore(player2);
            game.RoundScore(player2);
            game.RoundScore(player2);
            game.RoundScore(player2);

            Assert.AreEqual(game.GameScore, "deuce");
        }

        [TestMethod]
        public void AdvantageWhenBothPlayersScoreMoreThanThreeTimesAndTheServerHaveMoreOne()
        {
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);

            game.RoundScore(player2);
            game.RoundScore(player2);
            game.RoundScore(player2);

            Assert.AreEqual(game.GameScore, "advantage " + players[0].Name);
        }

        [TestMethod]
        public void AdvantageWhenBothScoreMoreThanThreeTimesAndTheNonServerHaveMoreOne()
        {
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);

            game.RoundScore(player2);
            game.RoundScore(player2);
            game.RoundScore(player2);
            game.RoundScore(player2);

            Assert.AreEqual(game.GameScore, "advantage " + players[1].Name);
        }

        [TestMethod]
        public void WinWhenTheServerWithAdvantageWinOneMoreTime()
        {
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);

            game.RoundScore(player2);
            game.RoundScore(player2);
            game.RoundScore(player2);

            Assert.AreEqual(game.GameScore, players[0].Name + " win");
        }

        [TestMethod]
        public void DeduceWhenTheNonServerWithoutAdvantageWinOneMoreTime()
        {
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);
            game.RoundScore(player1);
            
            game.RoundScore(player2);
            game.RoundScore(player2);
            game.RoundScore(player2);
            game.RoundScore(player2);

            Assert.AreEqual(game.GameScore, "deuce");
        }
    }
}
