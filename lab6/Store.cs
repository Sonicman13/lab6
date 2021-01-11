using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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
        private List<Item> item = new List<Item>();
        private List<Game> game = new List<Game>();
        private List<Platform> platform = new List<Platform>();
        public void read()
        {
            Item item1;
            Game game1;
            Platform platform1;
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
                item1 = new Item();
                item1.read();
                item.Add(item1);
                numberOfItems++;
                Console.WriteLine("Добавить еще один товар?(1 - да, все остальные символы -нет)");
                f = Console.ReadLine();
            }
            numberOfGames = 0;
            Console.WriteLine("Добавить игру?(1 - да, все остальные символы - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                game1 = new Game();
                game1.read(1);
                game.Add(game1);
                numberOfGames++;
                Console.WriteLine("Добавить еще одну игру?(1 - да, все остальные символы -нет)");
                f = Console.ReadLine();
            }
            numberOfPlatforms = 0;
            Console.WriteLine("Добавить консоль?(1 - да, все остальные символы - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                platform1 = new Platform();
                platform1.read(1);
                platform.Add(platform1);
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
                    this.item.Add(item[i]);
                }
                this.numberOfGames = numberOfGames;
                for (i = 0; i < this.numberOfGames; i++)
                {
                    this.game.Add(game[i]);
                }
                this.numberOfPlatforms = numberOfPlatforms;
                for (i = 0; i < this.numberOfPlatforms; i++)
                {
                    this.platform.Add(platform[i]);
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
                newStore.numberOfItems = store.numberOfItems;
                newStore.numberOfGames = store.numberOfGames;
                newStore.numberOfPlatforms = store.numberOfPlatforms;
                for (n = 0; n < store.numberOfItems; n++)
                {
                    newStore.item.Add(store.item[n]);
                }
                for (n = 0; n < store.numberOfGames; n++)
                {
                    newStore.game.Add(store.game[n]);
                }
                for (n = 0; n < store.numberOfPlatforms; n++)
                {
                    newStore.platform.Add(store.platform[n]);
                }
                Console.WriteLine("Добавить товар (1), игру (2) или консоль (3)");
                f = Console.ReadLine();
                if (f == "1")
                {
                    Item item1 = new Item();
                    item1.read();
                    newStore.item.Add(item1);
                    newStore.numberOfItems = ++store.numberOfItems;
                }
                else if (f == "2")
                {
                    Game game1 = new Game();
                    game1.read(1);
                    newStore.game.Add(game1);
                    newStore.numberOfGames = ++store.numberOfGames;
                }
                else
                {
                    Platform platform1 = new Platform();
                    platform1.read(1);
                    newStore.platform.Add(platform1);
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
            Item item1 = new Item();
            item1 = item.Find(x => x.Code == code);
            if(item1 != null)
            {
                item1.Price = price;
            }
            else
            {
                Game game1 = new Game(); ;
                game1 = game.Find(x => x.Code == code);
                if (game1 != null)
                {
                    game1.Price = price;
                }
                else
                {
                    Platform platform1 = new Platform();
                    platform1 = platform.Find(x => x.Code == code);
                    if(platform1 != null)
                    {
                        platform1.Price = price;
                    }
                }
            }
        }
        public void amountChange(string code, int amountDifference)
        {
            Item item1 = new Item();
            item1 = item.Find(x => x.Code == code);
            if (item1 != null)
            {
                item1.Amount = item1.Amount + amountDifference;
            }
            else
            {
                Game game1 = new Game(); ;
                game1 = game.Find(x => x.Code == code);
                if (game1 != null)
                {
                    game1.Amount = game1.Amount + amountDifference;
                }
                else
                {
                    Platform platform1 = new Platform();
                    platform1 = platform.Find(x => x.Code == code);
                    if (platform1 != null)
                    {
                        platform1.Amount = platform1.Amount + amountDifference;
                    }
                }
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
                    newStore.item.Add(store1.item[n]);
                }
                i = store1.numberOfItems;
                for (n = 0; n < store2.numberOfItems; n++)
                {
                    newStore.item.Add(store2.item[n]);
                    i++;
                }
                newStore.numberOfGames = store1.numberOfGames + store2.numberOfGames;
                for (n = 0; n < store1.numberOfGames; n++)
                {
                    newStore.game.Add(store1.game[n]);
                }
                i = store1.numberOfGames;
                for (n = 0; n < store2.numberOfGames; n++)
                {
                    newStore.game.Add(store2.game[n]);
                    i++;
                }
                newStore.numberOfPlatforms = store1.numberOfPlatforms + store2.numberOfPlatforms;
                for (n = 0; n < store1.numberOfPlatforms; n++)
                {
                    newStore.platform.Add(store1.platform[n]);
                }
                i = store1.numberOfPlatforms;
                for (n = 0; n < store2.numberOfPlatforms; n++)
                {
                    newStore.platform.Add(store2.platform[n]);
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
        public void add(string code)
        {
            Game game1 = new Game(); ;
            game1 = game.Find(x => x.Code == code);
            if (game1 != null)
            {
                game1.add();
            }
            else
            {
                Platform platform1 = new Platform();
                platform1 = platform.Find(x => x.Code == code);
                if (platform1 != null)
                {
                    platform1.add();
                }
            }
        }
        public void sortA()
        {
            string f;
            Console.WriteLine("Сортировать по возростанию(1) или по убыванию(2)");
            f = Console.ReadLine();
            if(f == "1")
            {
                ItemCompare1 nc = new ItemCompare1();
                item.Sort(nc);
                game.Sort(nc);
                platform.Sort(nc);
            }
            else
            {
                ItemCompare nc1 = new ItemCompare();
                item.Sort(nc1);
                game.Sort(nc1);
                platform.Sort(nc1);
            }
        }
    }
}
