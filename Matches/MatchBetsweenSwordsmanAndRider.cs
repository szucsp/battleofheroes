using Heroes;

namespace Matches
{
    [Match("Swordsman", "Rider")]
    public class MatchBetweenSwordsManAndRiderStrategy : MatchStrategy
    {
        public override HeroBase DoMatch(HeroBase assailant, HeroBase defender)
        {
            if (assailant.GetType() == typeof(Swordsman))
            {
                return null;
            }

            if (assailant.GetType() == typeof(Rider))
            {
                return assailant;
            }

            return null;
        }
    }
}
