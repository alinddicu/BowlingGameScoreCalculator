namespace UnitTest
{
    using CataBowling;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class UnitTest
    {
        private BowlingGame _bowlingGame;

        private void Initialize()
        {
            _bowlingGame = new BowlingGame();
        }

        [TestMethod]
        public void GivenNoSpareAndNoStrikeWhenCalculateThenScoreIsCorrect()
        {
            Initialize();
            _bowlingGame.Lancer(0).ComputeScore();
            Check.That(_bowlingGame.Score).Equals(0);

            Initialize();
            _bowlingGame.Lancer(0).Lancer(1).Lancer(0).Lancer(2).Lancer(0).Lancer(3).ComputeScore();
            Check.That(_bowlingGame.Score).Equals(6);
        }

        [TestMethod]
        public void Given20ThrowsWithNoStrikeAndNoSpareWhenCalculateThenScoreIsCorrect()
        {
            Initialize();
            _bowlingGame
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .Lancer(1)
                .ComputeScore();
            Check.That(_bowlingGame.Score).Equals(20);
        }

        [TestMethod]
        public void GivenSpareWhenCalculateThenScoreIsCorrect()
        {
            Initialize();
            _bowlingGame
                 .Lancer(5)
                 .Lancer(5)
                 .Lancer(1)
                 .ComputeScore();
            Check.That(_bowlingGame.Score).Equals(12);
        }


        [TestMethod]
        public void GivenStrikeWhenCalculateThenScoreIsCorrect()
        {
            Initialize();
            _bowlingGame
                 .Lancer(10)
                 .Lancer(1)
                 .Lancer(1)
                 .Lancer(1)
                 .ComputeScore();
            Check.That(_bowlingGame.Score).Equals(15);
        }

        [TestMethod]
        public void Given2StrikesWhenCalculateThenScoreIsCorrect()
        {
            Initialize();
            _bowlingGame
                 .Lancer(10)
                 .Lancer(10)
                 .ComputeScore();
            Check.That(_bowlingGame.Score).Equals(30);
        }

        [TestMethod]
        public void GivenStrikeSpareStrikeWhenCalculateThenScoreIs40()
        {
            Initialize();
            _bowlingGame
                 .Lancer(10)
                 .Lancer(5)
                 .Lancer(5)
                 .Lancer(10)
                 .ComputeScore();
            Check.That(_bowlingGame.Score).Equals(40);
        }

        [TestMethod]
        public void GivenSpareStrikeStrikeWhenCalculateThenScoreIs40()
        {
            Initialize();
            _bowlingGame
                 .Lancer(5)
                 .Lancer(5)
                 .Lancer(10)
                 .Lancer(10)
                 .ComputeScore();
            Check.That(_bowlingGame.Score).Equals(50);
        }

        [TestMethod]
        public void Given3StrikesWhenCalculateThenScoreIs60()
        {
            Initialize();
            _bowlingGame
                 .Lancer(10)
                 .Lancer(10)
                 .Lancer(10)
                 .ComputeScore();
            Check.That(_bowlingGame.Score).Equals(60);
        }

        [TestMethod]
        public void Given11StrikesWhenCalculateThenScoreIs300()
        {
            Initialize();
            _bowlingGame
                .Lancer(10)
                .Lancer(10)
                .Lancer(10)
                .Lancer(10)
                .Lancer(10)
                .Lancer(10)
                .Lancer(10)
                .Lancer(10)
                .Lancer(10)
                .Lancer(10)
                .Lancer(10)
                .ComputeScore();
            Check.That(_bowlingGame.Score).Equals(300);
        }

        [TestMethod]
        public void GivenLast3StrikesWhenCalculateThenScoreIs60()
        {
            Initialize();
            _bowlingGame
                .Lancer(0)
                .Lancer(0)
                .Lancer(0)
                .Lancer(0)
                .Lancer(0)
                .Lancer(0)
                .Lancer(0)
                .Lancer(0)
                .Lancer(10)
                .Lancer(10)
                .Lancer(10)
                .ComputeScore();
            Check.That(_bowlingGame.Score).Equals(60);
        }
    }
}
