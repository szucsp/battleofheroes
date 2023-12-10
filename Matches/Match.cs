using Heroes;

namespace Matches
{
    /// <summary>
    /// This class makes the heroes battle, based on the set strategy. Strategy pattern applied.
    /// </summary>
    public class Match
    {
        private MatchStrategy strategy;

        public void Setstrategy(MatchStrategy strategy)
        {
            this.strategy = strategy;
        }

        public HeroBase Domatch(HeroBase assailant, HeroBase defender)
        {
            return strategy.DoMatch(assailant, defender);
        }
    }
}
