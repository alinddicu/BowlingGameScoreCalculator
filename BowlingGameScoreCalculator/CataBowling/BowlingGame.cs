using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CataBowling
{
    public class BowlingGame
    {
        public const int StrikeValue = 10;

        public const int SpareValue = 10;

        private const int MaxGameLaunches = 21;

        private const int FrameNumber = 10;
        private const int LaunchesInLastFrame = 3;

        public BowlingGame()
        {
            AllLaunches = new List<Launch>(MaxGameLaunches);
            AllFrames = new List<Frame>(FrameNumber);

            InitGame();
        }

        public int Score { get; private set; }

        private List<Launch> AllLaunches { get; set; }

        private List<Frame> AllFrames { get; set; }

        private int CurrentLauchIndex { get; set; }

        public void ShowScore()
        {
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "Score : {0}", Score));

            Console.ReadLine();
        }

        public BowlingGame ComputeScore()
        {
            foreach (var currentThrow in AllLaunches)
            {
                if (currentThrow.IsStrike())
                {
                    Score += ComputeStrike(currentThrow);
                }
                else if (currentThrow.IsSpare(AllFrames))
                {
                    Score += ComputeSpare(currentThrow);
                }
                else
                {
                    Score += currentThrow.KeelCount;
                }
            }

            return this;
        }

        public BowlingGame Lancer(int keelCount)
        {
            if (CurrentLauchIndex <= MaxGameLaunches)
            {
                AllLaunches[CurrentLauchIndex++].KeelCount = keelCount;
            }
            return this;
        }

        private int ComputeStrike(Launch launch)
        {
            var launchNpLus1Value = AllLaunches.First(o => o.Order == launch.Order + 1);
            var launchNpLus2Value = AllLaunches.First(o => o.Order == launch.Order + 2);

            return 10 + (launchNpLus1Value != null ? launchNpLus1Value.KeelCount : 0) + (launchNpLus2Value != null ? launchNpLus2Value.KeelCount : 0);
        }

        private int ComputeSpare(Launch launch)
        {
            var throwNpLus1Value = AllLaunches.First(l => l.Order == launch.Order + 1);

            return launch.KeelCount + (throwNpLus1Value != null ? throwNpLus1Value.KeelCount : 0);
        }

        private void InitGame()
        {
            for (var i = 0; i < MaxGameLaunches; i++)
            {
                AllLaunches.Add(new Launch(i));
            }

            AllFrames.Add(new Frame(AllLaunches[0], AllLaunches[1]));
            for (var i = 3; i < MaxGameLaunches - LaunchesInLastFrame; i += 2)
            {
                AllFrames.Add(new Frame(AllLaunches[i - 1], AllLaunches[i]));
            }
            AllFrames.Add(new LastFrame(AllLaunches[MaxGameLaunches - 3], AllLaunches[MaxGameLaunches - 2], AllLaunches[MaxGameLaunches - 1]));
        }
    }
}
