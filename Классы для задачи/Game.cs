using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_WORKS
{
    class Game
    {
        static public void Play(int daysTillDry, List<BaseAntColony> colonies, List<Heap> heaps)
        {
            bool rhinocerosBeetleExists = false;
            int currentDay = 1;
            Console.WriteLine("!!!НАЧАЛО ИГРЫ!!!");
            while (currentDay <= daysTillDry && HelpFunctions.HeapsAreEmpty(heaps))
            {
                Console.Write($"----------------------------------------------ДЕНЬ {currentDay} (до засухи {daysTillDry - currentDay} дней)-----------------------------------------------\n");
                Console.WriteLine("-----------------------------------------------Информация до стычки: -----------------------------------------------");
                HelpFunctions.GetBrieflyInfoAboutColonies(colonies, currentDay, heaps);
                if (daysTillDry - currentDay == 7)
                {
                    //появляется жук, который будет в конце дня уничтожать случайную кучу
                    rhinocerosBeetleExists = true;
                }
                Console.WriteLine("-----------------------------------------------Поход на кучи начинается!-----------------------------------------------");
                if (rhinocerosBeetleExists == true)
                {
                    int randomHeapToDeleteIndex = new Random().Next(0, heaps.Count);
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write($"!!!Жук-носорог уничтожил кучу {randomHeapToDeleteIndex + 1}!!!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    heaps.RemoveAt(randomHeapToDeleteIndex);
                }
                if(heaps.Count == 0)
                {
                    HelpFunctions.PickWinner(colonies);
                    return;
                }
                for (int i = 0; i < colonies.Count; i++)
                {
                    HelpFunctions.LarvaeAlgorithm(colonies[i], colonies);
                }
                HelpFunctions.KingOfTheMountain(colonies: colonies, heaps: heaps);
                HelpFunctions.GetBrieflyInfoAboutColonies(colonies, currentDay, heaps);
                Console.WriteLine($"\n-------------------------------------------------------КОНЕЦ ДНЯ--------------------------------------------------------\n");
                if (heaps.Count == 0)
                {
                    HelpFunctions.PickWinner(colonies);
                    return;
                }
                currentDay += 1;
               
                bool spaceBar = false;
                while(spaceBar == false)
                {
                    Console.WriteLine("Для продолжения нажмите одну из клавиш: Space - следующий день, 1 - информация о каждом муравье в колонии; 2 - выбрать муравья и вывести о нём информацию");
                    ConsoleKey consoleKey = Console.ReadKey().Key;
                    Console.Clear();
                    switch (consoleKey)
                    {
                        case ConsoleKey.Spacebar:
                            spaceBar = true;
                            break;
                        case ConsoleKey.D1:
                            Console.Clear();
                            HelpFunctions.GetAllInfoAboutColonies(colonies, currentDay, heaps);
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            Console.WriteLine("Выберите колонию:");
                            int colonyIndex = int.Parse(Console.ReadLine()) - 1;
                            Console.Clear();
                            colonies[colonyIndex].GetBrieflyInfo();
                            Console.WriteLine("Введите индекс муравья: ");
                            int insectIndex = int.Parse(Console.ReadLine()) - 1;
                            Console.Clear();
                            colonies[colonyIndex].Insects[insectIndex].GetInfo();
                            break;
                        default:
                            Console.WriteLine("Неверно нажата клавиша!");
                            throw new Exception();
                    }
                }
                
            }
            HelpFunctions.PickWinner(colonies);
            return;
        }
    }
}
