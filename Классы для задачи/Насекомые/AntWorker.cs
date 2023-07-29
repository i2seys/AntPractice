using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_WORKS
{
    class AntWorker : BaseInsect
    {
        public int NumberOfPaws { get; private set; }
        public string[] NameOfResources { get; private set; }
        public string AndOrOr { get; private set; } = "или";

        /// <summary>
        /// Выводит информацию о муравье.
        /// </summary>
        public override void GetInfo()
        {
            Console.Write(GetHashCode() + ":");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("Муравей - рабочий.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($" Редкость {rarity}, ХП: {Health}, за раз " +
                $"может взять {NumberOfPaws} ресурсов: (");
            if (NameOfResources.Length == 1)
            {
                Console.Write($"{NameOfResources[0]});");
            }
            else
            {
                for (int i = 0; i < NameOfResources.Length; i++)
                {
                    if(i + 1 == NameOfResources.Length)
                    {
                        Console.Write($"{NameOfResources[i]});");
                    }
                    else
                    {
                        Console.Write($"{NameOfResources[i]} {AndOrOr} ");
                    }
                }
            }
            Console.WriteLine();
            base.GetInfo();
        }
        public AntWorker(string rarity, int numberOfPaws, string[] nameOfResources, string andOrOr, List<string> modificators, string nameOfQueen) : base(rarity:rarity, modificators: modificators, nameOfQueen: nameOfQueen)
        {
            NumberOfPaws = numberOfPaws;
            NameOfResources = nameOfResources;
            AndOrOr = andOrOr;
            Health = 1;
        }
        public AntWorker(string rarity, int numberOfPaws, string[] nameOfResources, string andOrOr, string nameOfQueen) : base(rarity:rarity, nameOfQueen: nameOfQueen)
        {
            NumberOfPaws = numberOfPaws;
            NameOfResources = nameOfResources;
            AndOrOr = andOrOr;
            Health = 1;
        }

        public AntWorker(string rarity, int numberOfPaws, string[] nameOfResources, List<string> modificators, string nameOfQueen) : base(rarity: rarity, modificators: modificators, nameOfQueen: nameOfQueen)
        {
            NumberOfPaws = numberOfPaws;
            NameOfResources = nameOfResources;
            Health = 1;
        }
        public AntWorker(string rarity, int numberOfPaws, string[] nameOfResources, string nameOfQueen) : base(rarity: rarity, nameOfQueen: nameOfQueen)
        {
            NumberOfPaws = numberOfPaws;
            NameOfResources = nameOfResources;
            Health = 1;
        }
    }
}
