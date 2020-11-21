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
        private int numberOfGames;
        private int numberOfPlatforms;
        private Item[] item = new Item[5];
        private Game[] game = new Game[5];
        private Platform[] platform = new Platform[5];
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
            numberOfGames = 0;
            Console.WriteLine("Добавить игру?(1 - да, все остальные символы - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                game[numberOfGames] = new Game();
                game[numberOfGames].read();
                numberOfGames++;
                Console.WriteLine("Добавить еще одну игру?(1 - да, все остальные символы -нет)");
                f = Console.ReadLine();
            }
            numberOfPlatforms = 0;
            Console.WriteLine("Добавить консоль?(1 - да, все остальные символы - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                platform[numberOfPlatforms] = new Platform();
                platform[numberOfPlatforms].read();
                numberOfPlatforms++;
                Console.WriteLine("Добавить еще одну консоль?(1 - да, все остальные символы -нет)");
                f = Console.ReadLine();
            }
        }
        public Store(string name, string adress, int numberOfItems, Item[] item, int numberOfGames, Game[] game, int numberOfPlatforms, Platform[] platform)
        {
            int i;
            if (numberOfItems < Store.maxNumberOfItems)
            {
                this.name = name;
                this.adress = adress;
                this.numberOfItems = numberOfItems;
                for (i = 0; i < this.numberOfItems; i++)
                {
                    this.item[i] = item[i];
                }
                this.numberOfGames = numberOfGames;
                for (i = 0; i < this.numberOfGames; i++)
                {
                    this.game[i] = game[i];
                }
                this.numberOfPlatforms = numberOfPlatforms;
                for (i = 0; i < this.numberOfPlatforms; i++)
                {
                    this.platform[i] = platform[i];
                }
            }
        }
        public Store(string name)
        {
            this.name = name;
            this.adress = "-";
            this.numberOfItems = 0;
            this.numberOfGames = 0;
            this.numberOfPlatforms = 0;
        }
        public Store()
        {
            this.name = "-";
            this.adress = "-";
            this.numberOfItems = 0;
            this.numberOfGames = 0;
            this.numberOfPlatforms = 0;
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
            for (i = 0; i < numberOfGames; i++)
            {
                Console.WriteLine("Игра " + (i + 1));
                game[i].display();
            }
            for (i = 0; i < numberOfPlatforms; i++)
            {
                Console.WriteLine("Консоль " + (i + 1));
                platform[i].display();
            }
        }
        public static Store operator ++ (Store store)
        {
            Store newStore = new Store();
            Exception a;
            string f;
            int n;
            try
            {
                if (store.numberOfItems >= Store.maxNumberOfItems)
                {
                    throw a = new Exception("0");
                }
                newStore.name = store.name;
                newStore.adress = store.adress;
                for (n = 0; n < store.numberOfItems; n++)
                {
                    newStore.item[n] = new Item();
                    newStore.item[n] = store.item[n];
                }
                for (n = 0; n < store.numberOfGames; n++)
                {
                    newStore.game[n] = new Game();
                    newStore.game[n] = store.game[n];
                }
                for (n = 0; n < store.numberOfPlatforms; n++)
                {
                    newStore.platform[n] = new Platform();
                    newStore.platform[n] = store.platform[n];
                }
                Console.WriteLine("Добавить товар (1), игру (2) или консоль (3)");
                f = Console.ReadLine();
                if (f == "1")
                {
                    newStore.item[store.numberOfItems] = new Item();
                    newStore.item[store.numberOfItems].read();
                    newStore.numberOfItems = ++store.numberOfItems;
                }
                else if (f == "2")
                {
                    newStore.game[store.numberOfGames] = new Game();
                    newStore.game[store.numberOfGames].read();
                    newStore.numberOfGames = ++store.numberOfGames;
                }
                else
                {
                    newStore.platform[store.numberOfPlatforms] = new Platform();
                    newStore.platform[store.numberOfPlatforms].read();
                    newStore.numberOfPlatforms = ++store.numberOfPlatforms;
                }
                return newStore;
            }
            catch(Exception)
            {
                return store;
            }
        }
        public void priceChange(string code, double price)
        {
            int i = 0, f = 0;
            while (i < numberOfItems)
            {
                if (item[i].Code == code)
                {
                    item[i].Price = price;
                    i = numberOfItems;
                    f = 1;
                }
                i++;
            }
            if (f == 0)
            {
                i = 0;
                while (i < numberOfGames)
                {
                    if (game[i].Code == code)
                    {
                        game[i].Price = price;
                        i = numberOfGames;
                        f = 1;
                    }
                    i++;
                }
            }
            if (f == 0)
            {
                i = 0;
                while (i < numberOfPlatforms)
                {
                    if (platform[i].Code == code)
                    {
                        platform[i].Price = price;
                        i = numberOfPlatforms;
                        f = 1;
                    }
                    i++;
                }
            }
        }
        public void amountChange(string code, int amountDifference)
        {
            int i = 0, f = 0;
            while (i < numberOfItems)
            {
                if (item[i].Code == code)
                {
                    item[i].Amount = item[i].Amount + amountDifference;
                    i = numberOfItems;
                    f = 1;
                }
                i++;
            }
            if (f == 0)
            {
                i = 0;
                while (i < numberOfGames)
                {
                    if (game[i].Code == code)
                    {
                        game[i].Amount = game[i].Amount + amountDifference;
                        i = numberOfGames;
                        f = 1;
                    }
                    i++;
                }
            }
            if (f == 0)
            {
                i = 0;
                while (i < numberOfPlatforms)
                {
                    if (platform[i].Code == code)
                    {
                        platform[i].Amount = platform[i].Amount + amountDifference;
                        i = numberOfPlatforms;
                        f = 1;
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
            Exception a;
            try
            {
                if (store1.numberOfItems + store2.numberOfItems > Store.maxNumberOfItems)
                {
                    throw a = new Exception("0");
                }
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
                newStore.numberOfGames = store1.numberOfGames + store2.numberOfGames;
                for (n = 0; n < store1.numberOfGames; n++)
                {
                    newStore.game[n] = store1.game[n];
                }
                i = store1.numberOfGames;
                for (n = 0; n < store2.numberOfGames; n++)
                {
                    newStore.game[i] = store2.game[n];
                    i++;
                }
                newStore.numberOfPlatforms = store1.numberOfPlatforms + store2.numberOfPlatforms;
                for (n = 0; n < store1.numberOfPlatforms; n++)
                {
                    newStore.platform[n] = store1.platform[n];
                }
                i = store1.numberOfPlatforms;
                for (n = 0; n < store2.numberOfPlatforms; n++)
                {
                    newStore.platform[i] = store2.platform[n];
                    i++;
                }
                return newStore;
            }
            catch (Exception)
            {
                return store1;
            }
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
