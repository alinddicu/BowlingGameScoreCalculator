namespace CataBowling
{
    public class LastFrame : Frame
    {
        public LastFrame(Launch launchNb1, Launch launchNb2, Launch lancer3)
            : base(launchNb1, launchNb2)
        {
            Lancer3 = lancer3;
        }

        public Launch Lancer3 { get; private set; }
    }
}
