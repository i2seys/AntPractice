using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_WORKS
{
    class AntWarrior : BaseInsect
    {
        public int Multishot { get; private set; }
        public int NumberOfBites { get; private set; }
        public override void GetInfo()
        {
            Console.Write(GetHashCode() + ":");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("Муравей - воин.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"Редкость {rarity}, Атакует {NumberOfBites} раз по {Multishot} целям. " +
                $"\nУрон: {Damage}, Здоровье: {Health}, Броня: {Defence}");
            base.GetInfo();
        }

        public AntWarrior(string rarity, int multishot, int numberOfBites, int health, int defence, int damage, List<string> modificators, string nameOfQueen) : base(rarity, health, defence, damage, modificators, nameOfQueen)
        {
            Multishot = multishot;
            NumberOfBites = numberOfBites;
        }
        public AntWarrior(string rarity, int multishot, int numberOfBites, int health, int defence, int damage, string nameOfQueen) : base(rarity, health, defence, damage, nameOfQueen)
        {
            Multishot = multishot;
            NumberOfBites = numberOfBites;
        }
    }
}
