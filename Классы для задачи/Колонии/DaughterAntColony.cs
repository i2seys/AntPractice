using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_WORKS
{
    class DaughterAntColony : BaseAntColony
    {
        public DaughterAntColony(string color, int antWorkerCount, int antWarriorCount, List<BaseInsect> antsOfColony, AntQueenDaughter queen) : base(color, antWorkerCount, antWarriorCount, antsOfColony, queen)
        {
        }

        public override void GetInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------ОБЩИЙ ВЫВОД КОЛОНИИ ДОЧЕРИ------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Колония (дочь-королева) {color}. Популяция: воины({AntWarriorCount}), рабочие({AntWorkerCount}).");
            base.GetInfo();
        }
        public override void GetBrieflyInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------ОБЩИЙ КРАТКИЙ ВЫВОД КОЛОНИИ ДОЧЕРИ------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Колония (дочь-королева) {color}. Популяция: воины({AntWarriorCount}), рабочие({AntWorkerCount}).");           
            base.GetBrieflyInfo();
        }
    }
}
