namespace CataBowling
{
    public class Frame
    {
        public Frame(Launch launchNb1, Launch launchNb2)
        {
            LaunchNb1 = launchNb1;
            LaunchNb2 = launchNb2;
        }

        public Launch LaunchNb1 { get; set; }

        public Launch LaunchNb2 { get; set; }
    }
}
