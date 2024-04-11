using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Game
{
    internal class enemy
    {
        private double hp = 100;
        private double maxHp = 100;
        private double armour = 0.01;
        private int damage = 22;

        public void TakeDamage(int playerDamage)
        {
            if (hp > 0)
                hp = hp - playerDamage * (1 - armour);

        }
        public void Heal()
        {
            hp = maxHp;
        }
        public bool IsDead(double health)
        {
            if (health <= 0)
            {
                Console.WriteLine("Ты выйграл!");
                hp = maxHp;
                return true;
            }    
            else
                return false;
        }
        public void enemyUp(double playerLvl)
        {
            damage = Convert.ToInt32(damage + 2 * playerLvl);
            armour = armour + playerLvl / 100;
        }
        public double Armour
        {
            get { return armour; }
        }
        public int Damage
        {
            get { return damage; }
        }
        public double Hp
        {
            get { return hp; } //возвращаем hp
        }
        public void Show()
        {
            Console.WriteLine("---Враг---\nЗдоровье: {0}\nБроня: {1}\nУрон: {2}\n------", hp, armour, damage);
        }

    }
}
