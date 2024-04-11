using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Drawing;


namespace Game
{
    internal class enemy
    {
        Random rand = new Random();
        private float hp = 100;
        private float maxHp = 100;
        private float armour = 0.01f;
        private int damage = 22;
        public string uploadProgress()//выгружаем данные для сохранения
        {
            return ($"{armour} {damage}");
        }
        public void downloadProgress(string save) //загружаем данные из сохранения.
        {
            int j = 0;
            string boofer = "";
            string[] a = save.Split('/');
            a = a[1].Split(' ');
            float.TryParse(a[0], out armour);
            damage = int.Parse(a[1]);
        }
        public void TakeDamage(int playerDamage)
        {
            if (hp > 0)
                hp = hp - playerDamage * (1 - armour);

        }
        public void Heal()
        {
            hp = maxHp;
        }
        public bool IsDead(float health)
        {
            if (health <= 0)
            {
                hp = maxHp;
                return true;
            }
            else
                return false;
        }
        public void enemyUp(float playerLvl)
        {
            damage += 2 * rand.Next(3);
            armour += playerLvl / 100;
        }
        public float Armour
        {
            get { return armour; }
        }
        public int Damage
        {
            get { return damage; }
        }
        public float Hp
        {
            get { return hp; } //возвращаем hp
        }
        public void Show()
        {
            Console.WriteLine("---Враг---\nЗдоровье: {0}\nБроня: {1}\nУрон: {2}\n------", hp, armour, damage);
        }

    }
}
