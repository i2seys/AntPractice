using System;
using System.Collections.Generic;

namespace IT_WORKS
{
    //Особенное насекомое <трудолюбивый обычный агрессивный рассеянный коренастый - Пчела>
    //(здоровье=26, защита=8, урон=7): может брать ресурсы (3 ресурса: листик);
    //может быть атакован войнами; атакует врагов(2 цели за раз и наносит 2 укуса);
    //урон от укуса уменьшен в двое; может пережить 1 любой укус.

    //Особенное насекомое<трудолюбивый неуязвимый мирный коренастый - Шмель>
    //(здоровье= 21, защита= 8): может брать ресурсы(3 ресурса: любой);
    //не может быть атакован войнами; может пережить 1 любой укус.
    class SpecialInsect : BaseInsect
    {
        public string KindOfInsect { get; private set; }//Вид насекомого (пчела, шмель)
        public int NumberOfPaws { get; private set; }//сколько ресурсов может брать за раз
        public string[] NameOfResources { get; private set; }//название ресурсов, которые может брать муравей
        public bool CanBeAttacked { get; private set; }//True - его могут бить, False - не могут
        public bool CanAttack { get; private set; }//True - может атаковать, False - не может
        public int Multishot { get; private set; }// Сколько целей атакует муравей за 1 укус
        public int NumberOfBites { get; private set; }// Сколько укусов делает за 1 день

        /// <summary>
        /// Выводит информацию об особом насекомом
        /// </summary>
        public override void GetInfo()
        {
            Console.Write(GetHashCode() + ":");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write("Особое насекомое.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"Редкость {rarity}: {KindOfInsect}. " +
                $"Здоровье: {Health}; Защита: {Defence};");
            if(CanAttack == true)
            {
                Console.Write($" Урон: {Damage}; ");
            }
            Console.Write($"Может брать ресурсы: ({NumberOfPaws} ресурса: ");
            for (int i = 0; i < NameOfResources.Length; i++)
            {
                Console.Write(NameOfResources[i] + "; ");
            }
            Console.Write($"). ");
            if(CanBeAttacked == true)
            {
                Console.Write("Может быть атакован воинами. ");
            }
            else
            {
                Console.Write("Не может быть атакован воинами. ");
            }
            if(CanAttack == true)
            {
                Console.Write($"Атакует врагов: ({Multishot} цели за раз и наносит {NumberOfBites} укусов.) ");
            }
            Console.WriteLine();
            base.GetInfo();
        }
        public SpecialInsect(string rarity, string kindOfInsect, int numberOfPaws, string[] nameOfResources, bool canBeAttacked, bool canAttack,  int health, int defence, List<string> modificators, string nameOfQueen) : base(rarity: rarity, health: health, defence: defence, modificators: modificators, nameOfQueen: nameOfQueen)
        {
            KindOfInsect = kindOfInsect;
            NumberOfPaws = numberOfPaws;
            NameOfResources = nameOfResources;
            CanBeAttacked = canBeAttacked;
            CanAttack = canAttack;
        }

        public SpecialInsect(string rarity, string kindOfInsect, int numberOfPaws, string[] nameOfResources, bool canBeAttacked, bool canAttack, int multishot, int numberOfBites,  int health, int defence, int damage, List<string> modificators, string nameOfQueen) : base(rarity, health, defence, damage, modificators, nameOfQueen)
        {
            KindOfInsect = kindOfInsect;
            NumberOfPaws = numberOfPaws;
            NameOfResources = nameOfResources;
            CanBeAttacked = canBeAttacked;
            CanAttack = canAttack;
            Multishot = multishot;
            NumberOfBites = numberOfBites;
        }


    }
}
