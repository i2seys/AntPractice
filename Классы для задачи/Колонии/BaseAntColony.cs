using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_WORKS
{
    abstract class BaseAntColony
    {
        protected string color;//цвет колонии
        public int AntWorkerCount { get; set; }//количество муравьёв-рабочих
        public int AntWarriorCount { get; set; }//количество муравьёв-воинов
        public AntQueenBase Queen { get; set; }//королева колонии
        public List<BaseInsect> Insects { get; protected set; }
        /// <summary>
        /// Ресурсы колонии
        /// </summary>
        public Dictionary<string, int> ResourcesDictionary { get; protected set; } = new Dictionary<string, int>()
        {
            { "веточка", 0},
            { "листик", 0},
            { "камушек", 0},
            { "росинка", 0},
        };

        public BaseAntColony(string color, int antWorkerCount, int antWarriorCount, List<BaseInsect> insects, AntQueenBase queen)
        {
            this.color = color;
            AntWorkerCount = antWorkerCount;
            AntWarriorCount = antWarriorCount;
            Insects = insects;
            Queen = queen;
        }
        public virtual void GetInfo()
        {
            Queen.GetInfo();
            foreach (BaseInsect insect in Insects)
            {
                insect.GetInfo();
            }
            foreach (KeyValuePair<string, int> resource in ResourcesDictionary)
            {
                Console.Write($"{resource.Key}: ");
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write($"{resource.Value}");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("; ");
            }
            Console.WriteLine();
        }
        public virtual void GetBrieflyInfo()
        {
            Console.Write("Ресурсы:");
            foreach (KeyValuePair<string, int> resource in ResourcesDictionary)
            {
                Console.Write($"{resource.Key}: ");
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write($"{resource.Value}");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("; ");
            }
            Console.WriteLine();
            Queen.GetInfo();
        }
    }
}
