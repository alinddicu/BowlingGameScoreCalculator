namespace CataBowling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bowlingGame = new BowlingGame();

            bowlingGame
                 .Lancer(10)
                 .Lancer(10)
                 .Lancer(10)
                 .ComputeScore()
                .ShowScore();
        }
    }
}
