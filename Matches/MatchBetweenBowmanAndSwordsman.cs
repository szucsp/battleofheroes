using Heroes;

namespace Matches
{
    [Match("Bowman", "Swordsman")]
    public class MatchBetweenBowmanAndSwordsmanStrategy : MatchStrategy
    {
        public override HeroBase DoMatch(HeroBase assailant, HeroBase defender)
        {
            if (assailant.GetType() == typeof(Bowman))
            {
                return assailant;
            }

            if (assailant.GetType() == typeof(Swordsman))
            {
                return assailant;
            }

            return null;
        }
    }
}
