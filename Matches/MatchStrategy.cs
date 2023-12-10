using Heroes;

namespace Matches
{
    /// <summary>
    /// This is an abstract class for strategies
    /// </summary>
    public abstract class MatchStrategy
    {
        public abstract HeroBase DoMatch(HeroBase assailant, HeroBase defender);
    }
}
