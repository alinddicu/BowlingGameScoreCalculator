using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CataBowling
{
    public class Launch
    {
        public Launch(int order)
        {
            Order = order;
        }

        public int KeelCount { get; set; }

        public int Order { get; private set; }

        public bool IsStrike()
        {
            return KeelCount == BowlingGame.StrikeValue;
        }

        public bool IsSpare(IEnumerable<Frame> frames)
        {
            return frames.Any(f => f.LaunchNb2.Equals(this) && (f.LaunchNb1.KeelCount + f.LaunchNb2.KeelCount) == BowlingGame.SpareValue);
        }

        public override bool Equals(object obj)
        {
            return ((Launch)obj).Order == Order;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "KeelCount : {0} / Order : {1} ", KeelCount, Order);
        }
    }
}
