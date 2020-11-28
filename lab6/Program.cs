using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Store[] store1 = new Store[10];
            Game[] game1 = new Game[10];
            Platform[] platform1 = new Platform[10];
            int amountDifference, numberOfItems, i, max, n, numberOfGames, numberOfPlatforms, itemAmount, d;
            int[] release = new int[3];
            double price;
            double itemPrice;
            string f, s, code, name, adress, itemCode, itemName, publisher;
            string[] s1 = new string[10], platforms = new string[10], components = new string[10];
            Console.WriteLine("Использовать или read чтобы ввести данные(1 - read, все остальные символы - init)");
            f = Console.ReadLine();
            if (f == "1")
            {
                store1[0] = new Store();
                store1[0].read();
            }
            else
            {
                Console.WriteLine("Ввести все параметры (1), только название (2), не вводить параметры(3)");
                f = Console.ReadLine();
                if (f == "1")
                {
                    Console.WriteLine("Введите название магазина");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите адрес магазина");
                    adress = Console.ReadLine();
                    numberOfGames = 0;
                    Console.WriteLine("Добавить игру?(1-да,0-нет)");
                    f = Console.ReadLine();
                    while (f == "1")
                    {
                        Console.WriteLine("Введите название игры");
                        itemName = Console.ReadLine();
                        Console.WriteLine("Введите код игры");
                        itemCode = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Введите цену");
                            try
                            {
                                itemPrice = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                itemPrice = -1;
                            }
                        } while (itemPrice < 0);
                        do
                        {
                            Console.WriteLine("Введите колличество товара");
                            try
                            {
                                itemAmount = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                itemAmount = -1;
                            }
                        } while (itemAmount < 0);
                        Console.WriteLine("Введите дату выхода(день, месяц(число), затем год(4 цифры), разделяя их нажатием Enter)");
                        release[0] = Convert.ToInt32(Console.ReadLine());
                        release[1] = Convert.ToInt32(Console.ReadLine());
                        release[2] = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите платформы на которых доступна игра( чтобы закончить вводить платформы введите пустую строку)");
                        d = -1;
                        do
                        {
                            d++;
                            platforms[d] = Console.ReadLine();
                        } while (platforms[d] != "");
                        Console.WriteLine("Введите издателя");
                        publisher = Console.ReadLine();
                        game1[numberOfGames] = new Game(itemName, itemCode, itemPrice, itemAmount, release, platforms, publisher);
                        numberOfGames++;
                        Console.WriteLine("Добавить еще одну игру?(1 - да, все остальные символы - нет)");
                        f = Console.ReadLine();
                    }
                    numberOfPlatforms = 0;
                    Console.WriteLine("Добавить консоль?(1-да,0-нет)");
                    f = Console.ReadLine();
                    while (f == "1")
                    {
                        Console.WriteLine("Введите название консоли");
                        itemName = Console.ReadLine();
                        Console.WriteLine("Введите код консоли");
                        itemCode = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Введите цену");
                            try
                            {
                                itemPrice = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                itemPrice = -1;
                            }
                        } while (itemPrice < 0);
                        do
                        {
                            Console.WriteLine("Введите колличество товара");
                            try
                            {
                                itemAmount = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                itemAmount = -1;
                            }
                        } while (itemAmount < 0);
                        Console.WriteLine("Введите комплектацию( чтобы закончить вводить комплектацию введите пустую строку)");
                        d = -1;
                        do
                        {
                            d++;
                            components[d] = Console.ReadLine();
                        } while (components[d] != "");
                        Console.WriteLine("Введите платформы доступные по обратной совместимости( чтобы закончить вводить платформы введите пустую строку)");
                        d = -1;
                        do
                        {
                            d++;
                            platforms[d] = Console.ReadLine();
                        } while (platforms[d] != "");
                        Console.WriteLine("Введите издателя");
                        publisher = Console.ReadLine();
                        platform1[numberOfPlatforms] = new Platform(itemName, itemCode, itemPrice, itemAmount, components, platforms, publisher);
                        numberOfPlatforms++;
                        Console.WriteLine("Добавить еще одну консоль?(1 - да, все остальные символы - нет)");
                        f = Console.ReadLine();
                    }
                    store1[0] = new Store(name, adress, numberOfGames, game1, numberOfPlatforms, platform1);
                }
                else if (f == "2")
                {
                    Console.WriteLine("Введите название магазина");
                    name = Console.ReadLine();
                    store1[0] = new Store(name);
                }
                else
                {
                    store1[0] = new Store();
                }
            }
            i = 0;
            max = 1;
            f = "1";
            while (f != "11")
            {
                Console.WriteLine("Введите номер следующего действия:");
                Console.WriteLine("1 - показать информацию о магазине");
                Console.WriteLine("2 - добавить новый вид товара");
                Console.WriteLine("3 - изменить цену товара");
                Console.WriteLine("4 - изменить колличество товара");
                Console.WriteLine("5 - Добавить магазин");
                Console.WriteLine("6 - показать все магазины");
                Console.WriteLine("7 - сменить магазин");
                Console.WriteLine("8 - сложить магазины");
                Console.WriteLine("9 - добавить комплектующие к консоли или платформы на которых доступна игра");
                Console.WriteLine("10 - копирование");
                Console.WriteLine("11 - выйти");
                f = Console.ReadLine();
                if (f == "1")
                {
                    store1[i].display();
                }
                else if (f == "2")
                {
                    store1[i] = ++store1[i];
                }
                else if (f == "3")
                {
                    Console.WriteLine("Введите код товара");
                    code = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Введите новую цену");
                        try
                        {
                            price = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            price = -1;
                        }
                    } while (price < 0);
                    store1[i].priceChange(code, price);
                }
                else if (f == "4")
                {
                    Console.WriteLine("Введите код товара");
                    code = Console.ReadLine();
                    Console.WriteLine("Введите на сколько изменилось колличество товара(если увеличилость - положительное число, если уменьшилось - отрицательное)");
                    try
                    {
                        amountDifference = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        amountDifference = 0;
                    }
                    store1[i].amountChange(code, amountDifference);
                }
                else if (f == "5")
                {
                    store1[max] = new Store();
                    store1[max].read();
                    i = max;
                    max++;

                }
                else if (f == "6")
                {
                    for (n = 0; n < max; n++)
                    {
                        Console.WriteLine("Магазин:" + store1[n].Name);
                    }
                }
                else if (f == "7")
                {
                    Console.WriteLine("Введите название магазина");
                    name = Console.ReadLine();
                    for (n = 0; n < max; n++)
                    {
                        if (store1[n].Name == name)
                        {
                            i = n;
                            n = max;
                        }
                    }
                }
                else if (f == "8")
                {
                    Console.WriteLine("Введите название магазина");
                    name = Console.ReadLine();
                    for (n = 0; n < max; n++)
                    {
                        if (store1[n].Name == name)
                        {
                            store1[i] = store1[i] + store1[n];
                            n = max;
                        }
                    }
                }
                else if (f == "9")
                {
                    Console.WriteLine("Введите код товара");
                    code = Console.ReadLine();
                    store1[i].add(code);
                }
                else if (f == "10")
                {
                    release[0] = release[1] = release[2] = 1;
                    platforms[0] = "aaa";
                    game1[0] = new Game("game", "game", 1, 1, release, platforms, "game");
                    components[0] = "bbb";
                    platforms[0] = "zzz";
                    platform1[0] = new Platform("platform", "platform", 2, 2, components, platforms, "platform");
                    game1[1] = (Game)game1[0].Clone();
                    game1[1].Amount = 2;
                    game1[0].display();
                    platform1[1] = platform1[0];
                    platform1[1].Amount = 3;
                    platform1[0].display();
                }
            }
        }
    }
}
