using Heroes;

namespace Matches
{
    public abstract class MatchStrategy
    {
        public abstract HeroBase DoMatch(HeroBase assailant, HeroBase defender);
    }
}
