using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Vew
    {
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("___MENU___");
            Console.WriteLine("Профиль - profile ");
            Console.WriteLine("Бой - fight ");
            Console.WriteLine("Мастерская - workshop");
            Console.WriteLine("Выход - exit");
            Console.WriteLine("__________");
            Console.WriteLine("");
            Console.Write("Выбор за вами: ");
        }

        public void Error(byte error)
        {
            switch (error)
            {
                case 01:
                    {
                        Console.WriteLine($"error 01 - command not found!");
                        break;
                    }
                case 02:
                    {
                        Console.WriteLine("error 02 - not nough coins!");
                        break;
                    }

            }
        }
        public void Profit(int value)
        {
            Console.WriteLine("Ты заработал {0} монет", value);
        }
        public void Wait ()
        {
            Console.WriteLine("Для продолжения нажми на любую конку..");
            Console.ReadKey();
            Console.Clear();
        }

        // все связанное с боем
        public void Death()
        {
            Console.Clear();
            Console.WriteLine("Ты проиграл! Но не войну. Вот тебе 2 монеты, не расстривайся");
        }
        public void Win(int lvl)
        {
            Console.Clear();
            Console.WriteLine("Поздравляю, ты выйграл и повысил свой уровень до {0}, а это значит, что враг стал сильнее.", lvl);
        }
        public void WaitFight() 
        {

            Console.WriteLine("Чтобы ударить нажми на любую кнопку..");
            Console.ReadKey();
            Console.Clear();

        }
        public void Damage(string whose, float value)
        {
            if (whose == "player")
            {
                Console.WriteLine("Вы нанесли: {0} урона.", value);
            }
            else if (whose == "enemy")
            {
                Console.WriteLine("Вам нанесли: {0} урона.", value);
            }
            Console.Write("Нажмите любую кнопку для продолжения битвы..");
            Console.ReadKey();
            Console.Clear();

        }

        // все связанное с магазином
        public void WorkShop(int coins, int priceToArmour, int priceToKnife)
        {
            Console.WriteLine("- Добро пожаловать в мастерскую!\n- Ваш баланс: {0}", coins);
            Console.WriteLine("- Вы можете выйти в любой момент, написав exit и вернуться к сражениям.");
            Console.Write("- Что вы хотите улучшить: броню за {0} или нож за {1} ? ", priceToArmour, priceToKnife);
        }
        public void updgradeArmour(int armourLvl, float armour)
        {
            Console.WriteLine("- Уровень брони увеличен до {0}", armourLvl);
            Console.WriteLine("- Поглащаемый броней урон увеличен до {0}", armour);
        }
        public void updgradeKnife(int knifeLvl, int damage)
        {
            Console.WriteLine("- Уровень ножа увеличен до {0}", knifeLvl);
            Console.WriteLine("- Урон увеличен до {0}", damage);
        }
        
    }
}
