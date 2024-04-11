using System.Data;
using System.Runtime;
using System.Threading;
using System.IO;
using System.Text;

namespace Game
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Vew ui = new Vew();
            enemy kraken = new enemy();
            player player1 = new player();
            string action = "";
            //загрузка сохранения
            if (File.Exists("Save.txt"))
            {
                DownloadSave(player1, kraken);
            }
            //регистрация пользователя
            if (player1.Name == null)
            {
                registration(player1);
            }
            //запуск процесса игры
            do
            {
                ui.MainMenu();
                action = Console.ReadLine();
                switch (action)
                {
                    case "profile":
                        {
                            player1.Show("");
                            ui.Wait();
                            break;
                        }

                    case "fight":
                        {
                            StartFight(player1, kraken, ui);
                            break;
                        }

                    case "workshop":
                        {
                            GoToWorkshop(player1, kraken, ui);
                            break;
                        }
                    default :
                        {
                            if (action != "exit")
                            {
                                ui.Error(01);
                                ui.Wait();
                            }
                            break;
                        }
                }
            } while (action != "exit");
            UploadSave(player1, kraken); //сохраняемся
        }
        static void StartFight(player player, enemy kraken, Vew ui)
        {
            Console.Clear();
            while (true)
            {
                //прилюдия
                player.Show("fight");
                Console.WriteLine("");
                kraken.Show();
                ui.WaitFight();
                //сам бой
                kraken.TakeDamage(player.Damage);
                ui.Damage("player", player.Damage * (1 - kraken.Armour));
                if (kraken.IsDead(kraken.Hp))
                {
                    player.levelUp();
                    ui.Win(player.Lvl);
                    player.profit(player.Lvl);
                    ui.Profit(player.Lvl * 2);
                    kraken.enemyUp(player.Lvl);
                    player.Heal();
                    ui.Wait();
                    break;
                }

                player.TakeDamage(kraken.Damage);
                ui.Damage("enemy", kraken.Damage * (1 - player.Armour));
                if (player.IsDead(player.Hp))
                {
                    ui.Death();
                    player.profit(1);
                    kraken.Heal();
                    ui.Wait();
                    break;
                }
            }
        }
        static void registration(player player)
        {
            Console.Write("Введите ваше имя: ");
            player.Name = Console.ReadLine();
        }
        static void GoToWorkshop(player player, enemy kraken, Vew ui)
        {
            string command = "";
            int priceToKnife;
            int priceToArmour;
            while (command != "exit")
            {
                Console.Clear();
                priceToKnife = player.KnifeLvl * 3 + 4;
                priceToArmour = player.ArmourLvl * 2 + 3;
                ui.WorkShop(player.Coins, priceToArmour, priceToKnife);
                command = Console.ReadLine();
                Console.Clear();
                if (command == "нож" && player.Coins >= priceToKnife)
                {
                    player.UpgradeKnifeLvl();
                    ui.updgradeKnife(player.KnifeLvl, player.Damage);
                }
                else if (command == "нож")
                    ui.Error(02);
                else if (command == "броню" && player.Coins >= priceToArmour)
                {
                    player.UpgradeArmourLvl();
                    ui.updgradeArmour(player.ArmourLvl, player.Armour);
                }
                else if (command == "броню")
                    ui.Error(02);
                else if (command != "exit")
                {
                    ui.Error(01);
                }
                ui.Wait();
            }
        }
        static void UploadSave(player player, enemy kraken)//сохранение
        {
            using (FileStream stream = new FileStream("Save.txt", FileMode.OpenOrCreate))
            {
                string save = $"{player.uploadProgress()}/{kraken.uploadProgress()}";
                byte[] boofer = Encoding.UTF8.GetBytes(save);
                stream.Write(boofer, 0, boofer.Length);
            }
        }

        static void DownloadSave(player player, enemy kraken)//Загрузка сохранения
        {
            using (FileStream stream1 = File.OpenRead("Save.txt"))
            {
                byte[] boofer = new byte[stream1.Length];
                stream1.Read(boofer, 0, boofer.Length);
                string save = Encoding.UTF8.GetString(boofer);
                if (save != string.Empty)
                {
                    kraken.downloadProgress(save);
                    player.downloadProgress(save);
                }
            }
        }
    }
}