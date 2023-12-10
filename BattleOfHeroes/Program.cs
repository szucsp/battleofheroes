using System;
using System.Collections.Generic;
using GeneratorForHeroes;
using Heroes;
using MatchManager;

namespace BattleOfHeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of participants: ");
            string input = Console.ReadLine();

            int number;
            
            if (Int32.TryParse(input, out number))
            {
                var heroGenerator = new HeroGenerator();
                List<HeroBase> hb = heroGenerator.GetHeros(number);

                MatchHandler matchHandler = new MatchHandler(hb);
                matchHandler.NewMessage += Mm_NewMessage;

                matchHandler.StartMatch();
            }
            else
            {
                Console.WriteLine("The number of participants can only consist of numbers");
            }
            
            Console.ReadLine();
        }

        private static void Mm_NewMessage(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine(e.PropertyName);
        }
    }
}
