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
            Item[] item1 = new Item[10];
            int amountDifference, numberOfItems, i, max, n;
            int[] itemAmount = new int[10];
            double price;
            double[] itemPrice = new double[10];
            string f, s, code, name, adress;
            string[] s1 = new string[10], itemCode = new string[10], itemName = new string[10];
            Console.WriteLine("Использовать или read чтобы ввести данные(1 - read, все остальные символы - init)");
            f = Console.ReadLine();
            store1[0] = new Store();
            if (f == "1")
            {
                store1[0].read();
            }
            else
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
                        itemPrice[numberOfItems] = Convert.ToDouble(Console.ReadLine());
                    } while (itemPrice[numberOfItems] < 0);
                    do
                    {
                        Console.WriteLine("Введите колличество товара");
                        itemAmount[numberOfItems] = Convert.ToInt32(Console.ReadLine());
                    } while (itemAmount[numberOfItems] < 0);
                    numberOfItems++;
                    Console.WriteLine("Добавить еще один товар?(1 - да, все остальные символы - нет)");
                    f = Console.ReadLine();
                }
                store1[0].init(name, adress, numberOfItems, itemName, itemCode, itemPrice, itemAmount);
            }
            i = 0;
            max = 1;
            f = "1";
            while (f != "9")
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
                Console.WriteLine("9 - выйти");
                f = Console.ReadLine();
                if (f == "1")
                {
                    store1[i].display();
                }
                else if (f == "2")
                {
                    store1[i].add();
                }
                else if (f == "3")
                {
                    Console.WriteLine("Введите код товара");
                    code = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Введите новую цену");
                        price = Convert.ToDouble(Console.ReadLine());
                    } while (price < 0);
                    store1[i].priceChange(code, price);
                }
                else if (f == "4")
                {
                    Console.WriteLine("Введите код товара");
                    code = Console.ReadLine();
                    Console.WriteLine("Введите на сколько изменилось колличество товара(если увеличилость - положительное число, если уменьшилось - отрицательное)");
                    amountDifference = Convert.ToInt32(Console.ReadLine());
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
            }
        }
    }
}
