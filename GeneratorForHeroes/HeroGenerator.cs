using System;
using System.Collections.Generic;
using Heroes;

namespace GeneratorForHeroes
{
    public class HeroGenerator
    {
        public List<HeroBase> GetHeros(int n)
        {
            List<Type> heroTypes = GetHeroTypes();
            List<HeroBase> heros = new List<HeroBase>();
            var random = new Random();

            for (int i = 1; i <= n; i++)
            {
                var heroType = heroTypes[random.Next(heroTypes.Count)];

                var newInstance = (HeroBase)Activator.CreateInstance(heroType);

                newInstance.Id = i;

                heros.Add(newInstance);
            }
            return heros;
        }

        private List<Type> GetHeroTypes()
        {
            List<Type> heroTypes = new List<Type>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsSubclassOf(typeof(HeroBase)))
                        heroTypes.Add(type);
                }
            }
            return heroTypes;
        }
    }
}
