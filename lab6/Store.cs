using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Store
    {
        private string name;
        private string adress;
        private int numberOfItems;
        private Item[] item = new Item[10];
        public void read()
        {
            string f;
            Console.WriteLine("Введите название магазина");
            name = Console.ReadLine();
            Console.WriteLine("Введите адрес магазина");
            adress = Console.ReadLine();
            numberOfItems = 0;
            Console.WriteLine("Добавить товар?(1 - да, все остальные символы - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                item[numberOfItems].read();
                numberOfItems++;
                Console.WriteLine("Добавить еще один товар?(1 - да, все остальные символы -нет)");
                f = Console.ReadLine();
            }
        }
        public void init(string name1, string adress1, int numberOfItems1, string[] itemName1, string[] itemCode1, double[] itemPrice1, int[] itemAmount1)
        {
            int i;
            name = name1;
            adress = adress1;
            numberOfItems = numberOfItems1;
            for (i = 0; i < numberOfItems; i++)
            {
                item[i].init(itemCode1[i], itemName1[i], itemPrice1[i], itemAmount1[i]);
            }
        }
        public void display()
        {
            int i;
            Console.WriteLine("Название магазина:" + name);
            Console.WriteLine("Адрес:" + adress);
            Console.WriteLine("Колличество уникальных товаров:" + numberOfItems);
            for (i = 0; i < numberOfItems; i++)
            {
                Console.WriteLine("Товар " + (i + 1));
                item[i].display();
            }
        }
        public void add()
        {
            item[numberOfItems].read();
            numberOfItems++;
        }
        public void priceChange(string code1, double price1)
        {
            int i = 0;
            while (i < numberOfItems)
            {
                if (item[i].Code == code1)
                {
                    item[i].Price = price1;
                    i = numberOfItems;
                }
                i++;
            }
        }
        public void amountChange(string code1, int amountDifference)
        {
            int i = 0;
            while (i < numberOfItems)
            {
                if (item[i].Code == code1)
                {
                    item[i].Amount = item[i].Amount + amountDifference;
                    i = numberOfItems;
                }
                i++;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}
