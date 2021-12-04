using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ScoreKeeper
{
    [TestClass]
    public class ScoreKeeperTests
    {
        [TestMethod]
        public void Score_Is000000_ByDefault()
        {
            var scoreKeeper = new ScoreKeeper();
            scoreKeeper.GetScore().Should().Be("000:000");
        }

        [TestMethod]
        public void Score_Is001000_AfterScoreTeamA1()
        {
            var scoreKeeper = new ScoreKeeper();
            scoreKeeper.ScoreTeamA1();
            scoreKeeper.GetScore().Should().Be("001:000");
        }

        [TestMethod]
        public void Score_Is002000_AfterScoreTeamA2()
        {
            var scoreKeeper = new ScoreKeeper();
            scoreKeeper.ScoreTeamA2();
            scoreKeeper.GetScore().Should().Be("002:000");
        }

        [TestMethod]
        public void Score_Is003000_AfterScoreTeamA3()
        {
            var scoreKeeper = new ScoreKeeper();
            scoreKeeper.ScoreTeamA3();
            scoreKeeper.GetScore().Should().Be("003:000");
        }

        [TestMethod]
        public void Score_Is000001_AfterScoreTeamB1()
        {
            var scoreKeeper = new ScoreKeeper();
            scoreKeeper.ScoreTeamB1();
            scoreKeeper.GetScore().Should().Be("000:001");
        }

        [TestMethod]
        public void Score_Is000002_AfterScoreTeamB2()
        {
            var scoreKeeper = new ScoreKeeper();
            scoreKeeper.ScoreTeamB2();
            scoreKeeper.GetScore().Should().Be("000:002");
        }

        [TestMethod]
        public void Score_Is000003_AfterScoreTeamB3()
        {
            var scoreKeeper = new ScoreKeeper();
            scoreKeeper.ScoreTeamB3();
            scoreKeeper.GetScore().Should().Be("000:003");
        }

        [TestMethod]
        public void Score_IsExpected_AfterEachAction()
        {
            var scoreKeeper = new ScoreKeeper();
            var actions = new[]
            {
                new ScoreAction(scoreKeeper.ScoreTeamA2, "002:000"),
                new ScoreAction(scoreKeeper.ScoreTeamB2, "002:002"),
                new ScoreAction(scoreKeeper.ScoreTeamA2, "004:002"),
                new ScoreAction(scoreKeeper.ScoreTeamA1, "005:002"),
                new ScoreAction(scoreKeeper.ScoreTeamB2, "005:004"),
                new ScoreAction(scoreKeeper.ScoreTeamA3, "008:004"),
                new ScoreAction(scoreKeeper.ScoreTeamB2, "008:006"),
                new ScoreAction(scoreKeeper.ScoreTeamA2, "010:006"),
                new ScoreAction(scoreKeeper.ScoreTeamB3, "010:009"),
                new ScoreAction(scoreKeeper.ScoreTeamB1, "010:010")
            };

            foreach (var action in actions)
            {
                action.Execute();
                scoreKeeper.GetScore().Should().Be(action.Result);
            }
        }

        private class ScoreAction
        {
            public Action Execute { get; }
            public string Result { get; }

            public ScoreAction(Action action, string score)
            {
                Execute = action;
                Result = score;
            }
        }
    }
}