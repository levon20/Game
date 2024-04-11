using System.Data;
using System.Runtime;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            enemy kraken = new enemy();
            string action = "";
            player player1 = new player();
            Console.Write("Введите ваше имя: ");
            player1.Name = Console.ReadLine();
            do
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
                action = Console.ReadLine();
                switch (action)
                {
                    case "profile":
                        {
                            Console.Clear();
                            player1.Show("");
                            break;
                        }

                    case "fight":
                    {
                        bool fightFinished = false;
                        Console.Clear();
                        while (true) 
                        {
                            player1.Show("fight");
                            Console.WriteLine("");
                            kraken.Show();
                            Console.WriteLine("Чтобы ударить нажми на любую кнопку..");
                            Console.ReadKey();
                            Console.Clear();
                            kraken.TakeDamage(player1.Damage);
                            Console.WriteLine("Вы нанесли: {0} урона.", player1.Damage * (1 - kraken.Armour));
                            if (kraken.IsDead(kraken.Hp))
                            {
                                Console.Clear();
                                player1.levelUp();
                                Console.WriteLine("Поздравляю, ты выйграл и повысил свой уровень до {0}, а это значит, что враг стал сильнее.", player1.Lvl);
                                player1.profit(player1.Lvl);
                                Console.WriteLine("Ты заработал {0} монет", player1.Lvl * 2);
                                kraken.enemyUp(player1.Lvl);
                                player1.Heal();
                                break;
                            }
                            player1.TakeDamage(kraken.Damage);
                            Console.WriteLine("Вам нанесли: {0} урона.", kraken.Damage * (1 - player1.Armour));
                            Console.WriteLine("");
                            Console.Write("Нажмите любую кнопку для продолжения битвы..");
                            Console.ReadKey();
                            Console.Clear();
                            if (player1.IsDead(player1.Hp))
                            {
                                Console.Clear();
                                Console.WriteLine("Поздравляю, ты проиграл! Но не расстраивайся, вот тебе 2 монеты");
                                player1.profit(1);
                                kraken.Heal();
                                break;
                            }        
                        }
                            break;
                    }

                    case "workshop":
                    {
                            Console.Clear();
                            string command = "";
                            int priceToKnife = player1.KnifeLvl * 2 + 4;
                            int priceToArmour = player1.ArmourLvl * 2 + 3;
                            Console.WriteLine("- Добро пожаловать в мастерскую!\n- Ваш баланс: {0}", player1.Coins);
                            Console.WriteLine("- Вы можете выйти в любой момент, написав exit и вернуться к сражениям.");
                            Console.Write("- Что вы хотите улучшить: броню за {0} или нож за {1} ? ", priceToArmour, priceToKnife );
                            command = Console.ReadLine();
                            Console.Clear();
                            if (command == "нож" && player1.Coins >= priceToKnife)
                            {
                                player1.UpgradeKnifeLvl();
                                Console.WriteLine("- Уровень ножа увеличен до {0}", player1.KnifeLvl);
                                Console.WriteLine("- Урон увеличен до {0}", player1.Damage);

                            }
                            else if (command == "нож")
                                Console.WriteLine("- Недостаточно монет!");
                            else if (command == "броню" && player1.Coins >= priceToArmour)
                            {
                                player1.UpgradeArmourLvl();
                                Console.WriteLine("- Уровень брони увеличен до {0}", player1.ArmourLvl);
                                Console.WriteLine("- Поглащаемый броней урон увеличен до {0}", player1.Armour);
                            }
                            else if (command == "броню")
                                Console.WriteLine("- Недостаточно монет или достигнут максимальный уровень брони !");
                            break;
                    }
                }
                if (action != "exit")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Нажми любую клавишу, чтобы вернуться в меню)");
                    Console.ReadKey();
                }
            } while (action != "exit");


        }
    }
}