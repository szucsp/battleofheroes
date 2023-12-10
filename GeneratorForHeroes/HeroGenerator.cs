using System;
using System.Collections.Generic;
using Heroes;

namespace GeneratorForHeroes
{
    /// <summary>
    /// This is an generator class for heroes.
    /// </summary>
    public class HeroGenerator
    {
        /// <summary>
        /// Generates the specified number of heroes and randomly selects their type
        /// </summary>
        /// <param name="numberOfHeroes"></param>
        /// <returns></returns>
        public List<HeroBase> GetHeros(int numberOfHeroes)
        {
            List<Type> heroTypes = GetHeroTypes();
            List<HeroBase> heros = new List<HeroBase>();
            var random = new Random();

            for (int i = 1; i <= numberOfHeroes; i++)
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
