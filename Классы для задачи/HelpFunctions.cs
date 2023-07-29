using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_WORKS
{
    class HelpFunctions
    {
        static private Dictionary<string, ConsoleColor> queenNamesDict = new Dictionary<string, ConsoleColor>
        {
            { "Матильда", (ConsoleColor)5 },
            { "Агнес", (ConsoleColor)1 },
            { "Аделаида",  (ConsoleColor)2},
            { "Айрис",  (ConsoleColor)3},
            { "Беатрикс", (ConsoleColor)4 },
            { "Глория", (ConsoleColor)6 },
            { "Джулия",  (ConsoleColor)7},
            { "Камила", (ConsoleColor)8 },
            { "Кассандра",(ConsoleColor)9  },
            { "Лейла", (ConsoleColor)10 },
            { "Мия", (ConsoleColor)11 },
            { "Рейчел",(ConsoleColor)12  },
            { "Саманта", (ConsoleColor)13 },
            { "Эбигейл", (ConsoleColor)14 }
        };
        static public Dictionary<string, ConsoleColor> QueenNamesDict
        {
            get { return queenNamesDict; }
        }
        static private List<string> queenNamesList = new List<string>
        {
            "Агнес",
            "Аделаида",
            "Айрис",
            "Глория",
            "Джулия" ,
            "Камила",
            "Кассандра",
            "Лейла",
            "Мия",
            "Рейчел",
            "Саманта",
            "Эбигейл"
        };
        static private List<string> QueenNamesList{get { return queenNamesList; }}
        static private List<string> colorList = new List<string> 
        {"альмандиновые","багоровые","виардовые","гиацинтовые","кошенилевые","нефритовые","пунцовые","силковые","терракотовые","фисташковые","цианитовые","цинковые"};
        static private List<string> ColorList{get { return colorList; }}
        public enum ColonyNumber
        {
            FirstQueen,
            SecondQueen,
            DaughterQueen
        }
        static public List<Heap> HeapsInit()
        {
            Dictionary<string, int> heap1 = new Dictionary<string, int>()
            {{"веточка",38 },{"листик", 48 }};
            Dictionary<string, int> heap2 = new Dictionary<string, int>()
            {{"веточка",23 }};
            Dictionary<string, int> heap3 = new Dictionary<string, int>()
            {{"веточка", 27 },{"камушек", 35 },{"росинка", 15 }};
            Dictionary<string, int> heap4 = new Dictionary<string, int>()
            {{"веточка",21 }};
            Dictionary<string, int> heap5 = new Dictionary<string, int>()
            {{"веточка",29 }};
            return new List<Heap> { new Heap(heap1), new Heap(heap2), new Heap(heap3), new Heap(heap4), new Heap(heap5) };
        }
        static public void PrintAllHeapsInfo(List<Heap> heaps)
        {
            for (int i = 0; i < heaps.Count; i++)
            {                
                Console.Write($"Куча {i+1}: ");
                foreach (var key in heaps[i].Resources.Keys)
                {
                    Console.Write($"{key}:");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"{heaps[i].Resources[key]}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("; ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();     
        }
        static public List<BaseAntColony> GetListOfQueenAntColonies()
        {
            AntQueen antQueen1 = new AntQueen(name: "Матильда", startingDayOfGrowth: 3, endDayOfGrowth: 3, startingQueenDaughterCount: 2, endQueenDaughterCount: 3);
            AntQueen antQueen2 = new AntQueen(name: "Беатрикс", startingDayOfGrowth: 2, endDayOfGrowth: 4, startingQueenDaughterCount: 2, endQueenDaughterCount: 3);
            QueenAntColony queenAntColony1 = new QueenAntColony(color: "черные", antWorkerCount: 16, antWarriorCount: 9, specialInsectCount: 1,insects: GetAllInsects(countOfWarriors:9, countOfWorkers:16, colonyNumber:ColonyNumber.FirstQueen, queenName: antQueen1.Name, specialInsectInclude:true),queen:antQueen1);
            QueenAntColony queenAntColony2 = new QueenAntColony(color: "рыжие", antWorkerCount: 18, antWarriorCount: 7, specialInsectCount: 1,insects: GetAllInsects(countOfWarriors: 7, countOfWorkers: 18, colonyNumber: ColonyNumber.SecondQueen, queenName: antQueen2.Name, specialInsectInclude: true),queen:antQueen2);
            return new List<BaseAntColony> {queenAntColony1, queenAntColony2 };
        }
        static public void InsectTalkingAboutQueen(BaseInsect insect, List<BaseAntColony> colonies)
        {
            foreach (BaseAntColony colony in colonies)
            {
                if(colony.Queen.Name == insect.NameOfQueen)
                {
                    colony.Queen.GetInfo();
                    return;
                }
            }            
        }
        static public List<BaseInsect> GetAllInsects(int countOfWarriors, int countOfWorkers, ColonyNumber colonyNumber, string queenName, bool specialInsectInclude = false)
        {
            List<BaseInsect> insects = new List<BaseInsect>();
            Random rand = new Random();
            int currentChoice;
            switch (colonyNumber)
            {
                case ColonyNumber.FirstQueen:
                    {
                        for (int i = 0; i < countOfWarriors; i++)
                        {
                            currentChoice = rand.Next(0, 3);
                            switch (currentChoice)
                            {
                                case 0:
                                    insects.Add(new AntWarrior(
                                        rarity: "легендарный",
                                        multishot: 3,
                                        numberOfBites: 1,
                                        health: 10,
                                        defence: 6,
                                        damage: 6,
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 1:
                                    insects.Add(new AntWarrior(
                                        rarity: "обычный",
                                        multishot: 1,
                                        numberOfBites: 1,
                                        health: 1,
                                        defence: 0,
                                        damage: 1,
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 2:
                                    insects.Add(new AntWarrior(
                                        rarity: "легендарный рассеянный",
                                        multishot: 3,
                                        numberOfBites: 1,
                                        health: 10,
                                        defence: 6,
                                        damage: 6,
                                        modificators: new List<string> { "утомление" },
                                        nameOfQueen: queenName
                                        ));
                                    break;
                            }
                        }
                        for (int i = 0; i < countOfWorkers; i++)
                        {
                            currentChoice = rand.Next(0, 3);
                            switch (currentChoice)
                            {
                                case 0:
                                    insects.Add(new AntWorker(
                                        rarity: "продвинутый",
                                        numberOfPaws: 2,
                                        nameOfResources: new string[] { "камушек", "росинка" },
                                        andOrOr: "или",
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 1:
                                    insects.Add(new AntWorker(
                                        rarity: "обычный",
                                        numberOfPaws: 1,
                                        nameOfResources: new string[] { "росинка" },
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 2:
                                    insects.Add(new AntWorker(rarity: "обычный любимчик королевы",
                                        numberOfPaws: 1,
                                        nameOfResources: new string[] { "веточка" },
                                        modificators: new List<string> { "хитрость" },
                                        nameOfQueen: queenName
                                        ));
                                    break;
                            }
                        }
                        if (specialInsectInclude == true)
                        {
                            insects.Add(new SpecialInsect(
                          rarity: "трудолюбивый обычный агрессивный рассеянный коренастый",
                          kindOfInsect: "Пчела",
                          numberOfPaws: 3,
                          nameOfResources: new string[] { "листик" },
                          canBeAttacked: true,
                          canAttack: true,
                          multishot: 2,
                          numberOfBites: 2,
                          health: 26,
                          defence: 8,
                          damage: 7,
                          modificators: new List<string> { "утомление", "поглощение" },
                          nameOfQueen: queenName
                          ));
                        }
                        return insects;
                    }
                case ColonyNumber.SecondQueen:
                    {
                        for (int i = 0; i < countOfWarriors; i++)
                        {
                            currentChoice = rand.Next(0, 3);
                            switch (currentChoice)
                            {
                                case 0:
                                    insects.Add(new AntWarrior(
                                        rarity: "продвинутый",
                                        multishot: 2,
                                        numberOfBites: 1,
                                        health: 6,
                                        defence: 2,
                                        damage: 3,
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 1:
                                    insects.Add(new AntWarrior(
                                        rarity: "старший",
                                        multishot: 1,
                                        numberOfBites: 1,
                                        health: 2,
                                        defence: 1,
                                        damage: 2,
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 2:
                                    insects.Add(new AntWarrior(
                                        rarity: "обычный невезучий",
                                        multishot: 1,
                                        numberOfBites: 1,
                                        health: 1,
                                        defence: 0,
                                        damage: 1,
                                        modificators: new List<string> { "сломанная броня" },
                                        nameOfQueen: queenName
                                        ));
                                    break;
                            }
                        }
                        for (int i = 0; i < countOfWorkers; i++)
                        {
                            currentChoice = rand.Next(0, 3);
                            switch (currentChoice)
                            {
                                case 0:
                                    insects.Add(new AntWorker(
                                        rarity: "старший",
                                        numberOfPaws: 1,
                                        nameOfResources: new string[] { "веточка", "камушек" },
                                        andOrOr: "или",
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 1:
                                    insects.Add(new AntWorker(
                                        rarity: "легендарный",
                                        numberOfPaws: 3,
                                        nameOfResources: new string[] { "камушек", "веточка", "камушек" },
                                        andOrOr:"и",
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 2:
                                    insects.Add(new AntWorker(rarity: "обычный ветеран",
                                        numberOfPaws: 1,
                                        nameOfResources: new string[] { "росинка" },
                                        modificators: new List<string> { "выключение" },
                                        nameOfQueen: queenName
                                        ));
                                    break;
                            }
                        }
                        if (specialInsectInclude == true)
                        {
                            insects.Add(new SpecialInsect(
                          rarity: "трудолюбивый неуязвимый мирный коренастый",
                          kindOfInsect: "Шмель",
                          numberOfPaws: 3,
                          nameOfResources: new string[] { "любой" },
                          canBeAttacked: false,
                          canAttack: false,
                          health: 21,
                          defence: 8,
                          modificators: new List<string> { "поглощение" },
                          nameOfQueen: queenName
                          ));
                        }
                        return insects;
                    }
                case ColonyNumber.DaughterQueen:
                    {
                        for (int i = 0; i < countOfWarriors; i++)
                        {
                            currentChoice = rand.Next(0, 7);
                            switch (currentChoice)
                            {
                                case 0:
                                    insects.Add(new AntWarrior(
                                        rarity: "продвинутый",
                                        multishot: 2,
                                        numberOfBites: 1,
                                        health: 6,
                                        defence: 2,
                                        damage: 3,
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 1:
                                    insects.Add(new AntWarrior(
                                        rarity: "старший",
                                        multishot: 1,
                                        numberOfBites: 1,
                                        health: 2,
                                        defence: 1,
                                        damage: 2,
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 2:
                                    insects.Add(new AntWarrior(
                                        rarity: "обычный невезучий",
                                        multishot: 1,
                                        numberOfBites: 1,
                                        health: 1,
                                        defence: 0,
                                        damage: 1,
                                        modificators: new List<string> { "сломанная броня" },
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 3:
                                    insects.Add(new AntWarrior(
                                        rarity: "легендарный",
                                        multishot: 3,
                                        numberOfBites: 1,
                                        health: 10,
                                        defence: 6,
                                        damage: 6,
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 4:
                                    insects.Add(new AntWarrior(
                                        rarity: "обычный",
                                        multishot: 1,
                                        numberOfBites: 1,
                                        health: 1,
                                        defence: 0,
                                        damage: 1,
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 5:
                                    insects.Add(new AntWarrior(
                                        rarity: "легендарный рассеянный",
                                        multishot: 3,
                                        numberOfBites: 1,
                                        health: 10,
                                        defence: 6,
                                        damage: 6,
                                        modificators: new List<string> { "утомление" },
                                        nameOfQueen: queenName
                                        ));
                                    break;
                            }
                        }
                        for (int i = 0; i < countOfWorkers; i++)
                        {
                            currentChoice = rand.Next(0, 5);
                            switch (currentChoice)
                            {
                                case 0:
                                    insects.Add(new AntWorker(
                                        rarity: "старший",
                                        numberOfPaws: 1,
                                        nameOfResources: new string[] { "веточка", "камушек" },
                                        andOrOr: "или",
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 1:
                                    insects.Add(new AntWorker(
                                        rarity: "легендарный",
                                        numberOfPaws: 3,
                                        nameOfResources: new string[] { "камушек", "веточка", "камушек" },
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 2:
                                    insects.Add(new AntWorker(
                                        rarity: "обычный ветеран",
                                        numberOfPaws: 1,
                                        nameOfResources: new string[] { "росинка" },
                                        modificators: new List<string> { "выключение" },
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 3:
                                    insects.Add(new AntWorker(
                                        rarity: "продвинутый",
                                        numberOfPaws: 2,
                                        nameOfResources: new string[] { "камушек", "росинка" },
                                        andOrOr: "или",
                                        nameOfQueen: queenName
                                        ));
                                    break;
                                case 4:
                                    insects.Add(new AntWorker(
                                        rarity: "обычный",
                                        numberOfPaws: 1,
                                        nameOfResources: new string[] { "росинка" },
                                        nameOfQueen: queenName
                                        ));
                                    break;
                            }
                        }
                        return insects;
                    }
            }
            throw new Exception();
        }               
        //королева: личинки вылупляются -> добавляются новые муравьи, новая дочь, личинки обновляются, количество королев увеличивается
        //дочь: личинки вылупляются -> добавляются новые муравьи, личинки обновляются
        static public void LarvaeAlgorithm(BaseAntColony colony, List<BaseAntColony> colonies)
        {
            Random rand = new Random();
            if (colony.Queen.DaysTillBirthOfLarvae == -1)//-1 = первый день игры
            {
                colony.Queen.ActualDayOfGrowth = rand.Next(colony.Queen.StartingDayOfGrowth, colony.Queen.EndDayOfGrowth + 1);
                //решаем, сколько дней будут расти личинки этого цикла
                colony.Queen.DaysTillBirthOfLarvae = colony.Queen.ActualDayOfGrowth;
                //переменная, показывающая, сколько дней до выроста личинок
                return;
            }
            if (colony.Queen.DaysTillBirthOfLarvae == 0)//цикл закончился, личинки выросли
            {
                ColonyNumber colonyNumber;
                int countOfWorkers = rand.Next(4, 7), countOfWarriors = rand.Next(2, 5);
                colony.AntWorkerCount += countOfWorkers;
                colony.AntWarriorCount += countOfWarriors;
                switch (colony.Queen.Name)
                {
                    case "Матильда":
                        colonyNumber = ColonyNumber.FirstQueen;
                        break;
                    case "Беатрикс":
                        colonyNumber = ColonyNumber.SecondQueen;
                        break;
                    default:
                        colonyNumber = ColonyNumber.DaughterQueen;
                        break;
                }
                colony.Insects.AddRange(GetAllInsects(countOfWarriors: countOfWarriors, countOfWorkers: countOfWorkers, colonyNumber: colonyNumber, queenName: colony.Queen.Name));
                switch (colonyNumber)   
                {
                    case ColonyNumber.FirstQueen:
                    case ColonyNumber.SecondQueen:
                        AntQueen currentQueen = (AntQueen)colony.Queen;
                        if (currentQueen.ActualQueenDaughterCount == currentQueen.MaxQueenDaughterCount)//если кол-во дочерей уже достигнуто, то не создаём
                        {
                            return;
                        }
                        string color = colorList[rand.Next(0, colorList.Count)];
                        colorList.Remove(color);
                        string queenName = queenNamesList[rand.Next(0, queenNamesList.Count)];
                        queenNamesList.Remove(queenName);
                        colonies.Add(new DaughterAntColony(color: color,antWorkerCount: 0,antWarriorCount: 0,antsOfColony: new List<BaseInsect>(),queen: new AntQueenDaughter(name: queenName,startingDayOfGrowth: rand.Next(1, 2),endDayOfGrowth: rand.Next(1, 3))));
                        currentQueen.DaysTillBirthOfLarvae = currentQueen.ActualDayOfGrowth;
                        currentQueen.AddDaughterName(queenName);
                        return;
                    case ColonyNumber.DaughterQueen:
                        AntQueenDaughter antQueenDaughter = (AntQueenDaughter)colony.Queen;
                        countOfWarriors *= 5;
                        countOfWorkers *= 5;
                        colony.Insects.AddRange(GetAllInsects(countOfWarriors: countOfWarriors, countOfWorkers: countOfWorkers, colonyNumber: ColonyNumber.DaughterQueen, queenName: colony.Queen.Name));
                        antQueenDaughter.DaysTillBirthOfLarvae = antQueenDaughter.ActualDayOfGrowth;
                        return;
                }
            }
            //если цикл роста ещё длится, то ничего не делаем.
            colony.Queen.DaysTillBirthOfLarvae -= 1;          
        }
        static public bool HeapsAreEmpty(List<Heap> heaps)
        {
            foreach (Heap heap in heaps)
            {
                foreach (int value in heap.Resources.Values)
                {
                    if (value != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static public void GetBrieflyInfoAboutColonies(List<BaseAntColony> colonies, int currentDay, List<Heap> heaps)
        {
            foreach (BaseAntColony colony in colonies)
            {
                colony.GetBrieflyInfo();
                Console.WriteLine();
                
            }
            Console.WriteLine("!!!ИНФОРМАЦИЯ О КУЧАХ!!!");
            PrintAllHeapsInfo(heaps);
            if(heaps.Count == 0)
            {
                Console.WriteLine("Все кучи пусты.");
                PickWinner(colonies);
                return;
            }
        }

        static public void GetAllInfoAboutColonies(List<BaseAntColony> colonies, int currentDay, List<Heap> heaps)
        {
            foreach (BaseAntColony colony in colonies)
            {
                colony.GetInfo();
                Console.WriteLine();
            }
            Console.WriteLine("!!!ИНФОРМАЦИЯ О КУЧАХ!!!");
            PrintAllHeapsInfo(heaps);
            if (heaps.Count == 0)
            {
                Console.WriteLine("Все кучи пусты.");
                PickWinner(colonies);
                return;
            }
        }
        static private bool TrickyAntExist(List<BaseAntColony> colonies)
        {
            foreach (BaseAntColony colony in colonies)
            {
                if(colony is QueenAntColony)
                {
                    QueenAntColony queenAntColony = (QueenAntColony)colony;
                    foreach (BaseInsect insect in queenAntColony.Insects)
                    {
                        if (insect.Modificators == null)
                        {
                            continue;
                        }
                        foreach (string modificator in insect.Modificators)
                        {
                            if (modificator == "хитрость")
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        static private List<List<List<BaseInsect>>> GetEmptyInsectsListOnHeaps(int heapsCount, int coloniesCount)
        {
            List<List<List<BaseInsect>>> result = new List<List<List<BaseInsect>>>();
            for (int i = 0; i < coloniesCount; i++)
            {
                result.Add(new List<List<BaseInsect>>());
                for (int j = 0; j < heapsCount; j++)
                {
                    result[i].Add(new List<BaseInsect>());
                }
            }
            return result;
        }
        static private List<BaseInsect> GetListOfTrickyWorkers(BaseAntColony colony)
        {
            QueenAntColony queenAntColony = (QueenAntColony)colony;
            List<BaseInsect> result = new List<BaseInsect>();
            foreach (BaseInsect insect in queenAntColony.Insects)
            {
                if(insect.Modificators != null)
                {
                    foreach (string modificator in insect.Modificators)
                    {
                        if (modificator == "хитрость")
                        {
                            result.Add(insect);
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < result.Count; i++)
            {
                colony.Insects.Remove(result[i]);
            }
            return result;
        }
        static private int GetIndexOfTrickyColony(List<BaseAntColony> colonies)
        {
            foreach (BaseAntColony colony in colonies)
            {
                QueenAntColony queenAntColony = (QueenAntColony)colony;
                foreach (BaseInsect insect in queenAntColony.Insects)
                {
                    if (insect.Modificators == null)
                    {
                        continue;
                    }
                    foreach (string modificator in insect.Modificators)
                    {
                        if (modificator == "хитрость")
                        {
                            return colonies.IndexOf(colony);
                        }
                    }
                }
            }
            throw new Exception();
        }
        static private List<BaseInsect> GetListOfWorkersAndSpecialInsectsForFight(BaseAntColony colony)
        {
            List<BaseInsect> result = new List<BaseInsect>();
            foreach (BaseInsect insect in colony.Insects)
            {
                if(insect is AntWorker || insect is SpecialInsect)
                {
                    result.Add(insect);
                }
            }
            foreach (BaseInsect insect in result)
            {
                colony.Insects.Remove(insect);
            }
            return result;
        }
        static private List<BaseInsect> GetListOfWarriorsForFight(BaseAntColony colony)
        {
            List<BaseInsect> result = new List<BaseInsect>();
            foreach (BaseInsect insect in colony.Insects)
            {
                if (insect is AntWarrior)
                {
                    result.Add(insect);
                }
            }
            foreach (BaseInsect insect in result)
            {
                colony.Insects.Remove(insect);
            }
            return result;
        }
        static private bool IsOtherTeamsAreEmpty(List<List<List<BaseInsect>>> insectsOnHeaps, int colonyToAttackIndex, int heapIndex, int colonyAmount)
        {
            for (int i = 0; i < colonyAmount; i++)
            {
                if(i == colonyToAttackIndex)
                {
                    continue;
                }
                if(insectsOnHeaps[i][heapIndex].Count != 0)
                {
                    return false;
                }
            }
            return true;
        }
        static private void GetModificatorsFatigueAndBrokenArmor(BaseInsect insect, ref int modifierFatigue, ref int modifierBrokenArmor)
        {
            if(insect.Modificators.Count == 0)
            {
                return;
            }
            foreach (string modificator in insect.Modificators)
            {
                if (modificator == "утомление")
                {
                    modifierFatigue = 2;
                    continue;
                }
                if (modificator == "сломанная броня")
                {
                    modifierBrokenArmor = 2;
                    continue;
                }
            }
        }
        static private bool IsHaveModifierAbsorption(BaseInsect insect)
        {
            if (insect.Modificators.Count  == 0)
            {
                return false;
            }
            foreach (string modificator in insect.Modificators)
            {
                if (modificator == "поглощение")
                {
                    return true;
                }
            }
            return false;
        }
        static private bool AreInsectsNative(List<BaseAntColony> colonies, int indexOfColony1, int indexOfColony2)
        {
            if(colonies[indexOfColony1].Queen is AntQueen && colonies[indexOfColony2].Queen is AntQueenDaughter)
            {
                AntQueen antQueen = (AntQueen)colonies[indexOfColony1].Queen;
                AntQueenDaughter antQueenDaughter = (AntQueenDaughter)colonies[indexOfColony2].Queen;
                foreach (string nameOfDaughter in antQueen.DaughterNames)
                {
                    if (nameOfDaughter == antQueenDaughter.Name)
                    {
                        return true;
                    }
                }
                return false;

            }
            else if (colonies[indexOfColony2].Queen is AntQueen && colonies[indexOfColony1].Queen is AntQueenDaughter)
            {
                AntQueen antQueen = (AntQueen)colonies[indexOfColony2].Queen;
                AntQueenDaughter antQueenDaughter = (AntQueenDaughter)colonies[indexOfColony1].Queen;
                foreach (string nameOfDaughter in antQueen.DaughterNames)
                {
                    if (nameOfDaughter == antQueenDaughter.Name)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        static private void FightAlgorithm(int heapsCount, List<BaseAntColony> colonies, List<List<List<BaseInsect>>> insectsOnHeaps)
        {
            int modifierFatigue = 1;//коэффициент, отвечающий за утомление(Урон от укуса воина уменьшен вдвое)
            int modifierBrokenArmor = 1;//коэффициент, отвечающий за сломанную броню(Урон вражеского укуса увеличен вдвое)
            for (int i = 0; i < heapsCount; i++)
            {
                for (int j = 0; j < colonies.Count; j++)
                {
                    foreach (BaseInsect insect in insectsOnHeaps[j][i])
                    {
                        if (!(insect is AntWarrior || (insect is SpecialInsect && insect.NameOfQueen == "Матильда")))
                        {
                            continue;
                        }
                        if (IsOtherTeamsAreEmpty(insectsOnHeaps, j, i, colonies.Count))
                        {
                            break;
                        }
                        GetModificatorsFatigueAndBrokenArmor(insect, ref modifierFatigue, ref modifierBrokenArmor);
                        if (insect is AntWarrior)
                        {
                            AntWarrior currentInsect = (AntWarrior)insect;
                            for (int k = 0; k < currentInsect.Multishot; k++)
                            {
                                int randomColony = new Random().Next(0, colonies.Count);
                                while (randomColony == j || insectsOnHeaps[randomColony][i].Count == 0)
                                {
                                    randomColony = new Random().Next(0, colonies.Count);
                                }
                                int indexOfRandomInsect = new Random().Next(0, insectsOnHeaps[randomColony][i].Count);
                                if(insectsOnHeaps[randomColony][i][indexOfRandomInsect] is SpecialInsect)
                                {
                                    SpecialInsect specialInsect = (SpecialInsect)insectsOnHeaps[randomColony][i][indexOfRandomInsect];
                                    if(specialInsect.CanBeAttacked == false)
                                    {
                                        continue;
                                    }
                                }
                                if (AreInsectsNative(colonies, j, randomColony))
                                {
                                    continue;
                                }
                                if (insectsOnHeaps[randomColony][i][indexOfRandomInsect].Defence < currentInsect.Damage * currentInsect.NumberOfBites * modifierBrokenArmor / modifierFatigue)
                                {
                                    insectsOnHeaps[randomColony][i][indexOfRandomInsect].Health -= currentInsect.Damage * currentInsect.NumberOfBites * modifierBrokenArmor / modifierFatigue - insectsOnHeaps[randomColony][i][indexOfRandomInsect].Defence;
                                }
                            }
                        }
                        else
                        {
                            SpecialInsect currentInsect = (SpecialInsect)insect;
                            if(currentInsect.CanAttack == false)
                            {
                                continue;
                            }
                            for (int k = 0; k < currentInsect.Multishot; k++)
                            {
                                int randomColony = new Random().Next(0, colonies.Count);
                                while (randomColony == j || insectsOnHeaps[randomColony][i].Count == 0)
                                {
                                    randomColony = new Random().Next(0, colonies.Count);
                                }
                                int indexOfRandomInsect = new Random().Next(0, insectsOnHeaps[randomColony][i].Count);
                                if (insectsOnHeaps[randomColony][i][indexOfRandomInsect] is SpecialInsect)
                                {
                                    SpecialInsect specialInsect = (SpecialInsect)insectsOnHeaps[randomColony][i][indexOfRandomInsect];
                                    if (specialInsect.CanBeAttacked == false)
                                    {
                                        continue;
                                    }
                                }
                                if (AreInsectsNative(colonies, j, randomColony))
                                {
                                    continue;
                                }
                                if (insectsOnHeaps[randomColony][i][indexOfRandomInsect].Defence < currentInsect.Damage * currentInsect.NumberOfBites * modifierBrokenArmor / modifierFatigue)
                                {
                                    insectsOnHeaps[randomColony][i][indexOfRandomInsect].Health -= currentInsect.Damage * currentInsect.NumberOfBites * modifierBrokenArmor / modifierFatigue - insectsOnHeaps[randomColony][i][indexOfRandomInsect].Defence;
                                }
                            }
                        }

                    }
                }
            }
        }
        static private void DistributionOfInsectsIntoHeaps(int heapsCount, List<BaseAntColony> colonies, List<List<List<BaseInsect>>> insectsOnHeaps, int heapLockedForWarriorsIndex)
        {
            for (int i = 0; i < colonies.Count; i++)
            {
                List<BaseInsect> currentWorkersAndSpecialInsectsOnHeaps = GetListOfWorkersAndSpecialInsectsForFight(colonies[i]);
                int amountOfWorkersAndSpecialInsects = currentWorkersAndSpecialInsectsOnHeaps.Count;
                for (int j = 0; j < amountOfWorkersAndSpecialInsects; j++)
                {
                    Random rand = new Random();
                    int randomHeapIndex = rand.Next(0, heapsCount);
                    int randomWorkerOrSpecialInsectIndex = rand.Next(0, currentWorkersAndSpecialInsectsOnHeaps.Count);
                    insectsOnHeaps[i][randomHeapIndex].Add(currentWorkersAndSpecialInsectsOnHeaps[randomWorkerOrSpecialInsectIndex]);
                    currentWorkersAndSpecialInsectsOnHeaps.RemoveAt(randomWorkerOrSpecialInsectIndex);
                }
                List<BaseInsect> currentWarriorsOnHeaps = GetListOfWarriorsForFight(colonies[i]);
                int amountOfWarriors = currentWarriorsOnHeaps.Count;
                if (heapsCount == 1 && heapLockedForWarriorsIndex == 0)
                {
                    heapLockedForWarriorsIndex = -1;
                }
                for (int j = 0; j < amountOfWarriors; j++)
                {
                    Random rand = new Random();
                    int randomHeapIndex = rand.Next(0, heapsCount);
                    while (randomHeapIndex == heapLockedForWarriorsIndex)
                    {
                        randomHeapIndex = rand.Next(0, heapsCount);
                    }
                    int randomWarriorIndex = rand.Next(0, currentWarriorsOnHeaps.Count);
                    insectsOnHeaps[i][randomHeapIndex].Add(currentWarriorsOnHeaps[randomWarriorIndex]);
                    currentWarriorsOnHeaps.RemoveAt(randomWarriorIndex);
                }

            }
        }
        static private void RemoveDeadInsects(int heapsCount, List<BaseAntColony> colonies, List<List<List<BaseInsect>>> insectsOnHeaps)
        {
            for (int i = 0; i < colonies.Count; i++)
            {
                for (int j = 0; j < heapsCount; j++)
                {
                    for (int k = 0; k < insectsOnHeaps[i][j].Count; k++)
                    {
                        if (insectsOnHeaps[i][j][k].Health <= 0)
                        {
                            if (IsHaveModifierAbsorption(insectsOnHeaps[i][j][k]))
                            {
                                insectsOnHeaps[i][j][k].Modificators.Remove("поглощение");
                                insectsOnHeaps[i][j][k].Health = 1;
                                continue;
                            }
                            insectsOnHeaps[i][j].RemoveAt(k);
                            k--;
                            continue;
                        }
                        
                    }
                }
            }
        }
        static private bool ResourcesMoreThanPotentialLoot(List<BaseAntColony> colonies, List<List<List<BaseInsect>>> insectsOnHeaps, List<Heap> heaps, int indexOfHeap)
        {
            Dictionary<string,int> resourcesInHeaps = heaps[indexOfHeap].Resources;//все ресурсы этой кучи

            Dictionary<string, int> resourcesFromInsects = new Dictionary<string, int>();
            foreach (KeyValuePair<string,int> pair in resourcesInHeaps)
            {
                resourcesFromInsects.Add(pair.Key, 0);
            }
            for (int i = 0; i < colonies.Count; i++)
            {
                foreach (BaseInsect insect in insectsOnHeaps[i][indexOfHeap])
                {
                    if (insect is SpecialInsect)
                    {
                        SpecialInsect specialInsect = (SpecialInsect)insect;
                        if(specialInsect.NameOfResources.Length == 1 && specialInsect.NameOfResources[0] == "любой")
                        {
                            for (int j = 0; j < heaps[indexOfHeap].Resources.Count; j++)
                            {
                                resourcesFromInsects[heaps[indexOfHeap].Resources.Keys.ElementAt(j)] += specialInsect.NumberOfPaws;
                            }
                        }
                        foreach (string resource in specialInsect.NameOfResources)
                        {
                            if(!(resourcesFromInsects.ContainsKey(resource)))
                            {
                                continue;
                            }
                            resourcesFromInsects[resource] += specialInsect.NumberOfPaws;
                        }
                    }
                    if (insect is AntWorker)
                    {
                        AntWorker antWorker = (AntWorker)insect;
                        foreach (string resource in antWorker.NameOfResources)
                        {
                            if (!(resourcesFromInsects.ContainsKey(resource)))
                            {
                                continue;
                            }
                            resourcesFromInsects[resource] += antWorker.NumberOfPaws;
                        }
                    }
                }
            }
            foreach (KeyValuePair<string, int> pairInsect in resourcesFromInsects)
            {
                if (resourcesInHeaps[pairInsect.Key] < resourcesFromInsects[pairInsect.Key])
                {
                    return false;
                }
            }
            return true;
        }
        static private List<string> GetPossibleResources(BaseInsect insect, Heap heap)
        {
            List<string> result = new List<string>();
            if(insect is AntWorker)
            {
                AntWorker antWorker = (AntWorker)insect;
                for (int i = 0; i < antWorker.NameOfResources.Length; i++)
                {
                    if(heap.Resources.ContainsKey(antWorker.NameOfResources[i]) && heap.Resources[antWorker.NameOfResources[i]] > 0)
                    {
                        result.Add(antWorker.NameOfResources[i]);
                    }
                }
            }
            else if(insect is SpecialInsect)
            {
                SpecialInsect specialInsect = (SpecialInsect)insect;
                if(specialInsect.NameOfResources.Length == 1 && specialInsect.NameOfResources[0] == "любой")
                {
                    List<string> currentResourcesOfSpecialInsect = heap.Resources.Keys.ToList();
                    for (int i = 0; i < currentResourcesOfSpecialInsect.Count; i++)
                    {
                        if (heap.Resources.ContainsKey(currentResourcesOfSpecialInsect[i]) && heap.Resources[currentResourcesOfSpecialInsect[i]] > 0)
                        {
                            result.Add(currentResourcesOfSpecialInsect[i]);
                        }
                    }
                    return result;
                }
                for (int i = 0; i < specialInsect.NameOfResources.Length; i++)
                {
                    if (heap.Resources.ContainsKey(specialInsect.NameOfResources[i]) && heap.Resources[specialInsect.NameOfResources[i]] > 0)
                    {
                        result.Add(specialInsect.NameOfResources[i]);
                    }
                }
            }
            else
            {
                throw new Exception();
            }
            return result;
        }
        static private void FromInsectsOnHeapsToColonies(List<BaseAntColony> colonies, List<List<List<BaseInsect>>> insectsOnHeaps, int heapsCount)
        {
            foreach (BaseAntColony colony in colonies)
            {
                colony.AntWarriorCount = colony.Insects.Count;
                colony.AntWorkerCount = 0;
            }
            for (int i = 0; i < colonies.Count; i++)
            {
                for (int j = 0; j < heapsCount; j++)
                {
                    for (int k = 0; k < insectsOnHeaps[i][j].Count; k++)
                    {
                        if (insectsOnHeaps[i][j][k] is AntWorker)
                        {
                            colonies[i].AntWorkerCount++;
                        }
                        if (insectsOnHeaps[i][j][k] is AntWarrior)
                        {
                            colonies[i].AntWarriorCount++;
                        }
                        colonies[i].Insects.Add(insectsOnHeaps[i][j][k]);
                    }
                }
            }
            
        }
        static private List<int> GetListWithCountOfInsectsInTeamFromColonies(List<List<List<BaseInsect>>> insectsOnHeaps, int indexOfHeap)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < insectsOnHeaps.Count; i++)
            {
                for (int j = 0; j < insectsOnHeaps[i][indexOfHeap].Count; j++)
                {
                    result.Add(i);
                }
            }
            return result;
        }
        static private void GetResorucesFromHeaps(List<BaseAntColony> colonies, List<List<List<BaseInsect>>> insectsOnHeaps, List<Heap> heaps)
        {
            for (int i = 0; i < colonies.Count; i++)
            {
                for (int j = 0; j < heaps.Count; j++)
                {
                    for (int k = 0; k < insectsOnHeaps[i][j].Count; k++)
                    {
                        if(insectsOnHeaps[i][j][k] is AntWarrior)
                        {
                            colonies[i].Insects.Add(insectsOnHeaps[i][j][k]);
                            insectsOnHeaps[i][j].RemoveAt(k);                       
                            k--;
                        }
                    }
                }
            }

            for (int j = 0; j < heaps.Count; j++)
            {
                if (ResourcesMoreThanPotentialLoot(colonies, insectsOnHeaps, heaps, j))
                {
                    for (int i = 0; i < colonies.Count; i++)
                    {
                        foreach (BaseInsect insect in insectsOnHeaps[i][j])
                        {
                            if (insect is AntWorker)
                            {
                                AntWorker antWorker = (AntWorker)insect;
                                List<string> possibleResources = GetPossibleResources(antWorker, heaps[j]);
                                if(possibleResources.Count == 0)
                                {
                                    continue;
                                }
                                if (antWorker.AndOrOr == "и")
                                {
                                    foreach (string resourceName in possibleResources)
                                    {
                                        if (heaps[j].Resources[resourceName] <= antWorker.NumberOfPaws)
                                        {
                                            colonies[i].ResourcesDictionary[resourceName] += heaps[j].Resources[resourceName];
                                            heaps[j].Resources.Remove(resourceName);
                                        }
                                        else
                                        {
                                            colonies[i].ResourcesDictionary[resourceName] += antWorker.NumberOfPaws;
                                            heaps[j].Resources[resourceName] -= antWorker.NumberOfPaws;
                                        }
                                    }
                                }
                                else
                                {
                                    string resourceName = possibleResources.ElementAt(new Random().Next(0, possibleResources.Count));
                                    if (heaps[j].Resources[resourceName] <= antWorker.NumberOfPaws)
                                    {
                                        colonies[i].ResourcesDictionary[resourceName] += heaps[j].Resources[resourceName];
                                        heaps[j].Resources.Remove(resourceName);
                                    }
                                    else
                                    {
                                        colonies[i].ResourcesDictionary[resourceName] += antWorker.NumberOfPaws;
                                        heaps[j].Resources[resourceName] -= antWorker.NumberOfPaws;
                                    }
                                }
                            }
                            else if (insect is SpecialInsect)
                            {
                                SpecialInsect specialInsect = (SpecialInsect)insect;
                                List<string> possibleResources = GetPossibleResources(specialInsect, heaps[j]);
                                if (possibleResources.Count == 0)
                                {
                                    continue;
                                }
                                string randomResourceName = possibleResources[new Random().Next(0, possibleResources.Count)];
                                if(heaps[j].Resources[randomResourceName] <= specialInsect.NumberOfPaws)
                                {
                                    colonies[i].ResourcesDictionary[randomResourceName] += heaps[j].Resources[randomResourceName];
                                    heaps[j].Resources.Remove(randomResourceName);
                                }
                                else
                                {
                                    colonies[i].ResourcesDictionary[randomResourceName] += specialInsect.NumberOfPaws;
                                    heaps[j].Resources[randomResourceName] -= specialInsect.NumberOfPaws;
                                }
                                
                            }
                        }
                    }
                }
                else
                {
                    List<int> countOfInsectsInTeamFromColonies = GetListWithCountOfInsectsInTeamFromColonies(insectsOnHeaps, j);
                    while(heaps[j].Resources.Count > 0)
                    {
                        int indexOfRandomColony = countOfInsectsInTeamFromColonies[new Random().Next(0, countOfInsectsInTeamFromColonies.Count)];
                        string nameOfRandomResource = heaps[j].Resources.Keys.ElementAt(new Random().Next(0, heaps[j].Resources.Count));
                        colonies[indexOfRandomColony].ResourcesDictionary[nameOfRandomResource]++;
                        heaps[j].Resources[nameOfRandomResource]--;
                        if(heaps[j].Resources[nameOfRandomResource] == 0)
                        {
                            heaps[j].Resources.Remove(nameOfRandomResource);
                        }
                        return;
                    }
                    if (heaps.Count == 0)
                    {
                        PickWinner(colonies);
                        return;
                    }
                }
            }
            for (int i = 0; i < heaps.Count; i++)
            {
                if(heaps[i].Resources.Count == 0)
                {
                    heaps.RemoveAt(i);
                    i--;
                }
            }
        }
        static public void KingOfTheMountain(List<BaseAntColony> colonies, List<Heap> heaps)
        {
            List<List<List<BaseInsect>>> insectsOnHeaps = GetEmptyInsectsListOnHeaps(heaps.Count, colonies.Count);

            int heapLockedForWarriorsIndex = -1;
            if(TrickyAntExist(colonies)) 
            {
                int indexOfTrickyColony = GetIndexOfTrickyColony(colonies);
                heapLockedForWarriorsIndex = new Random().Next(0, heaps.Count());
                List<BaseInsect> trickyWorkers = GetListOfTrickyWorkers(colonies[indexOfTrickyColony]);
                insectsOnHeaps[indexOfTrickyColony][heapLockedForWarriorsIndex] = trickyWorkers;
            }
            DistributionOfInsectsIntoHeaps(heaps.Count, colonies, insectsOnHeaps, heapLockedForWarriorsIndex);
            FightAlgorithm(heaps.Count, colonies, insectsOnHeaps);
            RemoveDeadInsects(heaps.Count, colonies, insectsOnHeaps);
            GetResorucesFromHeaps(colonies, insectsOnHeaps, heaps);
            FromInsectsOnHeapsToColonies(colonies, insectsOnHeaps, heaps.Count);
        }
        static public void PickWinner(List<BaseAntColony> colonies)
        {
            Console.WriteLine("Кучи пусты. Выбираем выжившую колонию.");
            List<int> sumOfResources = new List<int>();
            Console.WriteLine("РЕСУРСЫ КОЛОНИЙ: ");
            for (int i = 0; i < colonies.Count; i++)
            {
                sumOfResources.Add(colonies[i].ResourcesDictionary.Values.Sum());
                Console.Write($"Ресурсы колонии {i+1}: ");
                foreach (KeyValuePair<string,int> resource in colonies[i].ResourcesDictionary)
                {
                    Console.Write($"{resource.Key}: ");
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write($"{resource.Value}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ;");
                }
                Console.Write($"; Общие ресурсы этой колонии: ");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(sumOfResources[i]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
            Console.WriteLine($"Выжила колония {sumOfResources.IndexOf(sumOfResources.Max()) + 1}!");
        }
        
        public static void CheckEndOfGame(List<BaseAntColony> colonies, int heapsCount)
        {
            if (heapsCount == 0)
            {
                Console.WriteLine("Кучи пусты. Выбираем выжившую колонию.");
                List<int> sumOfResources = new List<int>();
                Console.WriteLine("РЕСУРСЫ КОЛОНИЙ: ");
                for (int i = 0; i < colonies.Count; i++)
                {
                    sumOfResources.Add(colonies[i].ResourcesDictionary.Values.Sum());
                    Console.Write($"Ресурсы колонии {i + 1}: ");
                    foreach (KeyValuePair<string, int> resource in colonies[i].ResourcesDictionary)
                    {
                        Console.Write($"{resource.Key}: ");
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write($"{resource.Value}");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ;");
                    }
                    Console.Write($"; Общие ресурсы этой колонии: ");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write(sumOfResources[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                }
                Console.WriteLine($"Выжила колония {sumOfResources.IndexOf(sumOfResources.Max()) + 1}!");

                return;
            }
        }
    }
}

