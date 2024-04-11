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
        Random rand = new Random();
        private string name = null; //имя игрока
        //дефолтные параметры
        private int lvl = 1; // Уровень игрока 0
        private int knifeLvl = 1; // Уровень орудия для убийств 1
        private int armourLvl = 0; // Уровень брони 2
        private int coins = 0; // Деняк 3
        private float HP = 100;
        private float armour = 0; //4
        private int damage = 24; //урон 5
        //Лимиты
        private byte maxArmourLvl = 9; // Максимальный уровень брони
        private float maxHP = 100;// максимальное кол-во хп                     
        //Сохранение

        public string uploadProgress()
        {
            return ($"{name} {lvl} {knifeLvl} {armourLvl} {coins} {armour} {damage}");
        }
        public void downloadProgress(string save) //загружаем данные из сохранения.
        {
            int j = 0;
            string boofer = "";
            string[] a = save.Split('/');//пилим строку по пробелам, символы после и до след пробела идут в ячейку массива.
            a = a[0].Split(' ');
            name = a[0];
            lvl = int.Parse(a[1]);
            knifeLvl = int.Parse(a[2]);
            armourLvl = int.Parse(a[3]);
            coins = int.Parse(a[4]);
            float.TryParse(a[5], out armour);
            damage = int.Parse(a[6]);
            
        }

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
            damage += knifeLvl * rand.Next(3);
        }
        public void UpgradeArmourLvl()
        {
            coins -= ArmourLvl * 2 + 3;
            armourLvl++;
            armour += 0.1f;
        }
        public void profit(int playerLvl)
        {
            coins += playerLvl * 2;
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
            HP -= enemyDamage * (1 - armour);
        }
        public void Heal()
        {
            HP = maxHP;
        }
        public bool IsDead(double health)
        {
            if (health <= 0)
            {
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
        public float Hp
        {
            get { return HP; } //возвращаем hp
        }
        public float Armour
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
                        Console.Clear();
                        Console.WriteLine("---Игрок---\nИмя: {0}\nУровень: {4}\nДенежка: {5}\nЗдоровье: {1}", name, HP, armour, damage, lvl, coins);
                        Console.WriteLine("---Снаряжение---\nНож: {0} уровня \nУрон: {1}\nБроня: {2}/{3} уровня\nБроня поглащает {4} нанесенного урона", knifeLvl, damage, armourLvl, maxArmourLvl, armour);
                        break;
                    }
            }

        }
    }
}
