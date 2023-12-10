using Heroes;

namespace Matches
{
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
