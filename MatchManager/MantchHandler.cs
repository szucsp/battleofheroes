using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Heroes;
using Matches;

namespace MatchManager
{
    public enum MatchSteps
    {
        Lottery = 0,
        SetStrategy,
        Match,
        SetVitality,
        WinnerAnnouncement
    }

    public class MatchHandler
    {
        List<HeroBase> participiants;
        public event PropertyChangedEventHandler NewMessage;

        Dictionary<string, MatchStrategy> strategies = new Dictionary<string, MatchStrategy>()
        {
            { "MatchBetweenBowmanAndRiderStrategy", new MatchBetweenBowmanAndRiderStrategy() },
            { "MatchBetweenSwordsManAndRiderStrategy", new MatchBetweenSwordsManAndRiderStrategy() },
            { "MatchBetweenBowmanAndSwordsmanStrategy", new MatchBetweenBowmanAndSwordsmanStrategy() },
            { "MatchBetweenSameHeroesStrategy", new MatchBetweenSameHeroesStrategy() }
        };

        public MatchHandler(List<HeroBase> participiants)
        {
            this.participiants = participiants;
        }

        public void StartMatch()
        {
            Match match = new Match();

            int circle = 0;

            while (participiants.Where(p => p.State == HeroState.Live).Count() > 1)
            {
                circle++;

                var fighters = Lottery();

                match.Setstrategy(GetStrategy(fighters.assaliant, fighters.defender));

                var winner = match.Domatch(fighters.assaliant, fighters.defender);

                SetVitality(fighters.assaliant, fighters.defender);

                SetState(winner, fighters.assaliant, fighters.defender);
                OnMessage("--- Circle: " + circle + " ---");
                OnMessage("Assaliant: " + fighters.assaliant.Id + " " + fighters.assaliant.GetType().Name);
                OnMessage("Defender: " + fighters.defender.Id + " " + fighters.defender.GetType().Name);

                if (winner != null)
                    OnMessage("After the battle the winner: " + winner.Id + " " + winner.GetType().Name);
                else
                    OnMessage("the match is a draw");

                OnMessage("Assaliant vitality: " + fighters.assaliant.Vitality + " " +  fighters.assaliant.State);
                OnMessage("Defender vitality: " + fighters.defender.Vitality + " " + fighters.defender.State);
            }
        }

        private void SetState(HeroBase winner, HeroBase assaliant, HeroBase defender)
        {
            if (winner != null)
            {
                if (winner == assaliant)
                    defender.SetState(HeroState.Died);
                else
                    assaliant.SetState(HeroState.Died);
            }
        }

        private void SetVitality(HeroBase assaliant, HeroBase defender)
        {
            assaliant.SetVitality(HeroVitalityChange.Down);
            defender.SetVitality(HeroVitalityChange.Down);

            var livingParticipiants = participiants.Where(x => x != assaliant && x != defender && x.State == HeroState.Live);

            foreach (HeroBase participiant in livingParticipiants)
            {
                participiant.SetVitality(HeroVitalityChange.Up);
            }
        }

        private (HeroBase assaliant, HeroBase defender) Lottery()
        {
            var random = new Random();
            var liveheroes = participiants.Where(p => p.State == HeroState.Live).ToList();

            HeroBase assaliant = liveheroes[random.Next(liveheroes.Count)];
            HeroBase defender = liveheroes.Except(new List<HeroBase>() { assaliant }).ToList()[random.Next(liveheroes.Count - 1)];

            return (assaliant, defender);
        }

        private MatchStrategy GetStrategy(HeroBase assaliant, HeroBase defender)
        {
            if (assaliant.GetType().Name == defender.GetType().Name)
                return strategies["MatchBetweenSameHeroesStrategy"];

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var type in from assembly in assemblies
                                 from Type type in assembly.GetTypes()
                                 where type.IsSubclassOf(typeof(MatchStrategy))
                                 let args = type.CustomAttributes.First().ConstructorArguments
                                 where args.Any(x => x.Value.ToString() == assaliant.GetType().Name) && args.Any(x => x.Value.ToString() == defender.GetType().Name)
                                 select type)
            {
                return strategies[type.Name];
            }

            return null;
        }

        protected void OnMessage(String message)
        {
            if (NewMessage != null) NewMessage(this, new PropertyChangedEventArgs(message));
        }
    }
}
