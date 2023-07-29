using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_WORKS
{
    class QueenAntColony : BaseAntColony
    {
        private int specialInsectCount;//количество особых насекомых
        public QueenAntColony(string color, int antWorkerCount, int antWarriorCount, int specialInsectCount, List<BaseInsect> insects, AntQueen queen) : base(color, antWorkerCount, antWarriorCount, insects, queen)
        {
            this.specialInsectCount = specialInsectCount;
        }

        public override void GetInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------ОБЩИЙ ВЫВОД КОЛОНИИ МАТЕРИ------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Колония (мать-королева) {color}. Популяция: воины({AntWarriorCount}), рабочие({AntWorkerCount}), особые насекомые({Insects.Count - AntWarriorCount - AntWorkerCount}).");
            base.GetInfo();
        }
        public override void GetBrieflyInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------ОБЩИЙ КРАТКИЙ ВЫВОД КОЛОНИИ МАТЕРИ------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Колония (мать-королева) {color}. Популяция: воины({AntWarriorCount}), рабочие({AntWorkerCount}), особые насекомые({Insects.Count - AntWarriorCount - AntWorkerCount}).");
            base.GetBrieflyInfo();
        }
    }
}
