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
        private static int maxNumberOfItems = 10;
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
            while (f == "1" && numberOfItems < maxNumberOfItems)
            {
                item[numberOfItems] = new Item();
                item[numberOfItems].read();
                numberOfItems++;
                Console.WriteLine("Добавить еще один товар?(1 - да, все остальные символы -нет)");
                f = Console.ReadLine();
            }
        }
        public void init(string name, string adress, int numberOfItems, string[] itemName1, string[] itemCode1, double[] itemPrice1, int[] itemAmount1)
        {
            int i;
            if (numberOfItems < Store.maxNumberOfItems)
            {
                this.name = name;
                this.adress = adress;
                this.numberOfItems = numberOfItems;
                for (i = 0; i < this.numberOfItems; i++)
                {
                    item[i] = new Item();
                    item[i].init(itemCode1[i], itemName1[i], itemPrice1[i], itemAmount1[i]);
                }
            }
        }
        public void display()
        {
            int i;
            Console.WriteLine("Название магазина:" + name);
            Console.WriteLine("Адрес:" + adress);
            Console.WriteLine("Колличество уникальных товаров:" + numberOfItems);
            Console.WriteLine("Колличество мест для товаров:" + maxNumberOfItems);
            for (i = 0; i < numberOfItems; i++)
            {
                Console.WriteLine("Товар " + (i + 1));
                item[i].display();
            }
        }
        public static Store operator ++ (Store store)
        {
            Store newStore = new Store();
            int n;
            if (store.numberOfItems < Store.maxNumberOfItems)
            {
                newStore.name = store.name;
                newStore.adress = store.adress;
                for (n = 0; n < store.numberOfItems; n++)
                {
                    newStore.item[n] = new Item();
                    newStore.item[n] = store.item[n];
                }
                newStore.item[store.numberOfItems] = new Item();
                newStore.item[store.numberOfItems].read();
                newStore.numberOfItems = ++store.numberOfItems;
                return newStore;
            }
            else return store;
        }
        public void priceChange(string code, double price)
        {
            int i = 0;
            while (i < numberOfItems)
            {
                if (item[i].Code == code)
                {
                    item[i].Price = price;
                    i = numberOfItems;
                }
                i++;
            }
        }
        public void amountChange(string code, int amountDifference)
        {
            int i = 0;
            while (i < numberOfItems)
            {
                if (item[i].Code == code)
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
        public static Store operator + (Store store1, Store store2) {
            int n, i;
            Store newStore = new Store();
            if (store1.numberOfItems + store2.numberOfItems <= Store.maxNumberOfItems)
            {
                newStore.name = store1.name;
                newStore.adress = store1.adress;
                newStore.numberOfItems = store1.numberOfItems + store2.numberOfItems;
                for (n = 0; n < store1.numberOfItems; n++)
                {
                    newStore.item[n] = store1.item[n];
                }
                i = store1.numberOfItems;
                for (n = 0; n < store2.numberOfItems; n++)
                {
                    newStore.item[i] = store2.item[n];
                    i++;
                }
                return newStore;
            }
            else return store1;
        }
        public void getNumber(out int number)
        {
            number = numberOfItems;
        }
        public void getNumber1(ref int number)
        {
            number = numberOfItems;
        }
        public static void maxNumberOfItemsChange(int newMax)
        {
            Store.maxNumberOfItems = newMax;
        }
    }
}
