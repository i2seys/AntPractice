using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_WORKS
{
    class AntQueenDaughter : AntQueenBase
    {
        public AntQueenDaughter(string name, int startingDayOfGrowth, int endDayOfGrowth) : base(name, startingDayOfGrowth, endDayOfGrowth)
        {
        }
        public override void GetInfo()
        {
            Console.Write("Дочь-королева ");
            base.GetInfo();
            Console.WriteLine($". Цикл роста личинок: {StartingDayOfGrowth} - {EndDayOfGrowth} дней. До рождения личинок осталось {DaysTillBirthOfLarvae} дней.");
            Console.WriteLine();
        }
    }
}
