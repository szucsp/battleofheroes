using Heroes;

namespace Matches
{
    public class MatchBetweenSameHeroesStrategy : MatchStrategy
    {
        public override HeroBase DoMatch(HeroBase assailant, HeroBase defender)
        {
            return assailant;
        }
    }
}
