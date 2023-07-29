using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_WORKS
{
    class AntQueen : AntQueenBase
    {
        public List<string> DaughterNames{ get; private set; } = new List<string>();
        public void AddDaughterName(string name)
        {
            DaughterNames.Add(name);
            ActualQueenDaughterCount++;
        }

        public int MaxQueenDaughterCount{ get; private set; }//кол-во королев, которые может родить текущая королева. Рассчитывается во время инициализации экзампляра класса
        public int ActualQueenDaughterCount { get; private set; }//текущее кол-во королев - дочерей.

        public override void GetInfo()
        {
            Console.Write($"Королева муравьёв ");
            base.GetInfo();
            if (DaysTillBirthOfLarvae == -1)
            {
                Console.WriteLine($". Цикл роста личинок: {StartingDayOfGrowth} - {EndDayOfGrowth} дней. Может создать {MaxQueenDaughterCount} королев. \nУже создала {ActualQueenDaughterCount} королев.До рождения личинок осталось неопределённое количество дней.");
            }
            else
            {
                Console.WriteLine($". Цикл роста личинок: {StartingDayOfGrowth} - {EndDayOfGrowth} дней. Может создать {MaxQueenDaughterCount} королев. \nУже создала {ActualQueenDaughterCount} королев.До рождения личинок осталось {DaysTillBirthOfLarvae} дней.");
            }
            Console.WriteLine();
        }
        public AntQueen(string name, int startingDayOfGrowth, int endDayOfGrowth, int startingQueenDaughterCount, int endQueenDaughterCount) : base(name, startingDayOfGrowth, endDayOfGrowth)
        {
            Random rand = new Random();
            MaxQueenDaughterCount = rand.Next(startingQueenDaughterCount, endQueenDaughterCount + 1);
            ActualQueenDaughterCount = 0;
        }
    }
}
