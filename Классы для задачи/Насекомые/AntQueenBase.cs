using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_WORKS
{
    class AntQueenBase
    {
        //Королеве не нужно здоровье, урон и защита, так как она не сражается и на неё не нападают, она только рождает новых муравьев
        public string Name { get; protected set; }
        public int DaysTillBirthOfLarvae { get; set; }        //сколько дней осталось до рождения личинок
        public int StartingDayOfGrowth { get; protected set; }//минимальное кол-во дней, нужное для роста личинок
        public int EndDayOfGrowth { get; protected set; }
        public int ActualDayOfGrowth { get; set; }//сколько действительно дней уходит на личинки

        public AntQueenBase(string name, int startingDayOfGrowth, int endDayOfGrowth)
        {
            Name = name;
            StartingDayOfGrowth = startingDayOfGrowth;
            EndDayOfGrowth = endDayOfGrowth;
            DaysTillBirthOfLarvae = -1;
        }

        public virtual void GetInfo()
        {
            //Console.Write("Дочь королевы муравьёв ");
            Console.ForegroundColor = HelpFunctions.QueenNamesDict[Name];
            Console.Write(Name);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
