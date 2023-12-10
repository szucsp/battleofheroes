using Heroes;

namespace Matches
{
    [Match("Bowman", "Rider")]
    public class MatchBetweenBowmanAndRiderStrategy : MatchStrategy
    {
        public override HeroBase DoMatch(HeroBase assailant, HeroBase defender)
        {
            if (assailant.GetType() == typeof(Bowman))
            {
                return assailant;
            }

            if (assailant.GetType() == typeof(Rider))
            {
                return defender;
            }

            return null;
        }
    }
}
