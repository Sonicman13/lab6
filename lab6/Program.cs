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
            Store[,] store1 = new Store[5, 10];
            Item[] item1 = new Item[10];
            int amountDifference, numberOfItems, i, max, n, i1;
            int[] itemAmount = new int[10], max1 = new int[10];
            double price;
            double[] itemPrice = new double[10];
            string f, s, code, name, adress;
            string[] s1 = new string[10], itemCode = new string[10], itemName = new string[10];
            Console.WriteLine("Использовать или read чтобы ввести данные(1 - read, все остальные символы - init)");
            f = Console.ReadLine();
            if (f == "1")
            {
                store1[0, 0] = new Store();
                store1[0, 0].read();
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
                    numberOfItems = 0; ;
                    Console.WriteLine("Добавить товар?(1-да,0-нет)");
                    f = Console.ReadLine();
                    while (f == "1")
                    {
                        Console.WriteLine("Введите название товара");
                        itemName[numberOfItems] = Console.ReadLine();
                        Console.WriteLine("Введите код товара");
                        itemCode[numberOfItems] = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Введите цену");
                            try
                            {
                                itemPrice[numberOfItems] = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (FormatException){
                                itemPrice[numberOfItems] = -1;
                            }
                        } while (itemPrice[numberOfItems] < 0);
                        do
                        {
                            Console.WriteLine("Введите колличество товара");
                            try
                            {
                                itemAmount[numberOfItems] = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                itemAmount[numberOfItems] = -1;
                            }
                        } while (itemAmount[numberOfItems] < 0);
                        numberOfItems++;
                        Console.WriteLine("Добавить еще один товар?(1 - да, все остальные символы - нет)");
                        f = Console.ReadLine();
                    }
                    store1[0, 0] = new Store(name, adress, numberOfItems, itemName, itemCode, itemPrice, itemAmount);
                }
                else if (f == "2")
                {
                    Console.WriteLine("Введите название магазина");
                    name = Console.ReadLine();
                    store1[0, 0] = new Store(name);
                }
                else
                {
                    store1[0, 0] = new Store();
                }
            }
            i = 0;
            max = 1;
            max1[0] = 1;
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
                Console.WriteLine("9 - показать колличество товаров");
                Console.WriteLine("10 - изменить колличество мест для товаров в магазине");
                Console.WriteLine("11 - выйти");
                f = Console.ReadLine();
                if (f == "1")
                {
                    Console.WriteLine("Сеть магазинов " + (i + 1));
                    for (n = 0; n < max1[i]; n++)
                    {
                        Console.WriteLine("Магазин " + (n + 1));
                        store1[i, n].display();
                    }
                }
                else if (f == "2")
                {
                    Console.WriteLine("Введите номер магазина");
                    n = Convert.ToInt32(Console.ReadLine());
                    store1[i, n-1] = ++store1[i, n-1];
                }
                else if (f == "3")
                {
                    Console.WriteLine("Введите номер магазина");
                    n = Convert.ToInt32(Console.ReadLine());
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
                    store1[i, n-1].priceChange(code, price);
                }
                else if (f == "4")
                {
                    Console.WriteLine("Введите номер магазина");
                    n = Convert.ToInt32(Console.ReadLine());
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
                    store1[i, n-1].amountChange(code, amountDifference);
                }
                else if (f == "5")
                {
                    Console.WriteLine("Новая сеть магазинов (1), новый магазин в данной сети магазинов (2)");
                    n = Convert.ToInt32(Console.ReadLine());
                    if(n == 1)
                    {
                        store1[max, 0] = new Store();
                        store1[max, 0].read();
                        i = max;
                        max++;
                        max1[i] = 1;
                    }
                    else
                    {
                        store1[i, max1[i]] = new Store();
                        store1[i, max1[i]].read();
                        max1[i]++;
                    }

                }
                else if (f == "6")
                {
                    for (n = 0; n < max; n++)
                    {
                        Console.WriteLine("Сеть магазинов " + (n + 1));
                        for (i1 = 0; i1 < max1[n]; i1++)
                        {
                            Console.WriteLine("Магазин " + (i1 + 1));
                            store1[n, i1].display();
                        }
                    }
                }
                else if (f == "7")
                {
                    Console.WriteLine("Введите сеть магазинов");
                    n = Convert.ToInt32(Console.ReadLine());
                    i = n - 1;
                }
                else if (f == "8")
                {
                    Console.WriteLine("Введите название магазина который надо изменить");
                    name = Console.ReadLine();
                    for (n = 0; n < max1[i]; n++)
                    {
                        if (name == store1[i, n].Name)
                        {
                            Console.WriteLine("Введите название магазина который надо прибавить");
                            name = Console.ReadLine();
                            for (i1 = 0; i1 < max1[i]; i1++)
                            {
                                if (name == store1[i, i1].Name)
                                {
                                    store1[i, n] = store1[i, n] + store1[n, i1];
                                    i1 = max1[i];
                                }
                            }
                            n = max1[i];
                        }
                    }
                }
                else if (f == "9")
                {
                    Console.WriteLine("1 - out, 0 - ref");
                    s = Console.ReadLine();
                    if (s == "1")
                    {
                        store1[i, 0].getNumber(out n);
                        Console.WriteLine(n);
                    }
                    else
                    {
                        n = 1;
                        store1[i, 0].getNumber1(ref n);
                        Console.WriteLine(n);
                    }
                }
                else if (f == "10")
                {
                    Console.WriteLine("Введите колличество");
                    numberOfItems = Convert.ToInt32(Console.ReadLine());
                    Store.maxNumberOfItemsChange(numberOfItems);
                }
            }
        }
    }
}
