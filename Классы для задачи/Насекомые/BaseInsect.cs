using System;
using System.Collections.Generic;

namespace IT_WORKS
{
    abstract class BaseInsect
    {
        public string NameOfQueen { get; protected set; }
        protected string rarity;
        public int Health { get; set; }
        public int Defence { get; set; }
        public int Damage { get; protected set; }
        public List<string> Modificators { get; protected set; } = new List<string>();

        protected static Dictionary<string, string> modificatorsDictionary = new Dictionary<string, string>()
        {
            { "утомление", "Урон от укуса воина уменьшен вдвое"},
            { "сломанная броня", "Урон вражеского укуса увеличен вдвое"},
            { "хитрость", "Всегда отправляется только на ту кучу, где нет вражеских воинов"},
            { "поглощение", "Может пережить 1 любой укус"},
            { "выключение","Отменяет все модификаторы своих и вражеских рабочих"},
        };
        public BaseInsect(string rarity, int health, int defence, int damage, List<string> modificators, string nameOfQueen)
        {
            NameOfQueen = nameOfQueen;
            this.rarity = rarity;
            Health = health;
            Defence = defence;
            Damage = damage;
            Modificators = modificators;
        }
        public BaseInsect(string rarity, int health, int defence, List<string> modificators, string nameOfQueen)
        {
            NameOfQueen = nameOfQueen;
            this.rarity = rarity;
            Health = health;
            Defence = defence;
            Modificators = modificators;
        }
        public BaseInsect(string rarity, List<string> modificators, string nameOfQueen)
        {
            NameOfQueen = nameOfQueen;
            this.rarity = rarity;
            Modificators = modificators;
        }
        public BaseInsect(string rarity, string nameOfQueen)
        {
            NameOfQueen = nameOfQueen;
            this.rarity = rarity;
        }
        public BaseInsect(string rarity, int health, int defence, int damage, string nameOfQueen)
        {
            NameOfQueen = nameOfQueen;
            this.rarity = rarity;
            Health = health;
            Defence = defence;
            Damage = damage;
        }
        public virtual void GetInfo()
        {
            if (Modificators == null)
            {
                Console.WriteLine("Модификаторов нет.");
            }
            else
            {
                foreach (string modificator in Modificators)
                {
                    Console.WriteLine($"Модификатор {modificator}: {modificatorsDictionary[modificator]}");
                }
            }
            Console.WriteLine();
        }
    }
}
