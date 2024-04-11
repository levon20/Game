using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Game
{
    internal class player
    {
        private string name; //имя игрока
        
        private int lvl = 1;
        private int knifeLvl = 1;
        private int armourLvl = 0;
        private int maxArmourLvl = 9; 
        private int coins = 0;
        private double HP = 100;
        private double maxHP = 100;// максимальное кол-во хп

        private double armour = 0;
        private double maxArmour = 0.9; // максимальное поглащение урона броней

        private int damage = 24; //урон

        public int KnifeLvl
        {
            get { return knifeLvl; }
        }
        public int ArmourLvl
        {
            get { return armourLvl; }
        }
        public void UpgradeKnifeLvl()
        {
            coins -= KnifeLvl * 2 + 4;
            knifeLvl++;
            damage *= knifeLvl;
        }
        public void UpgradeArmourLvl()
        {
            coins -= ArmourLvl * 2 + 3;
            armourLvl++;
            armour += 0.1;
        }
        public void profit(int playerLvl)
        {
            coins += playerLvl*2;
        }
        public int Coins
        {
            get { return coins; }
        }
        public void levelUp()
        {
            lvl++;
        }
        public void TakeDamage(int enemyDamage)
        {
                HP = HP - enemyDamage* (1 - armour);

        }
        public void Heal()
        {
            HP = maxHP;
        }
        public bool IsDead(double health)
        {
            if (health <= 0)
            {
                Console.WriteLine("поздравляю, ты проиграл! Ты ничего не получишь!");
                HP = maxHP;
                return true;
            }    
            else
                return false;
        }

        public string Name
        {
            get { return name; } //возвращаем имя
            set { name = name ?? value; } //если имени нет, то присваиваем пришедшее значение
        }
        public int Damage
        {
            get { return damage; }
            
        }
        public double Hp
        {
            get { return HP; } //возвращаем hp
        }
        public double Armour
        {
            get { return armour; }

        }
        public int Lvl
        {
            get { return lvl; }
        }
        
        public void Show(string paragraph)
        {
            switch (paragraph)
            {
                case "fight":
                {
                    Console.WriteLine("---Игрок---\nИмя: {0}\nЗдоровье: {1}\nУрон: {2}\nБроня: {3}", name, HP, damage, armour);
                    break;
                }
                default:
                {
                    Console.WriteLine("---Игрок---\nИмя: {0}\nУровень: {4}\nДенежка: {5}\nЗдоровье: {1}", name, HP, armour, damage, lvl, coins);
                    Console.WriteLine("---Снаряжение---\nНож: {0} уровня \nУрон: {1}\nБроня: {2}/{3} уровня\nБроня поглащает {4} нанесенного урона", knifeLvl, damage, armourLvl, maxArmourLvl, armour);
                    break;
                }
            }
            
        }
    }
}
