namespace CataBowling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var partieBowling = new BowlingGame();

            partieBowling
                 .Lancer(10)
                 .Lancer(10)
                 .Lancer(10)
                 .ComputeScore()
                .ShowScore();
        }
    }
}
