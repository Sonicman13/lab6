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
        private Array<Item> item = new Array<Item>();
        private Array<Game> game = new Array<Game>();
        private Array<Platform> platform = new Array<Platform>();
        public void read()
        {
            string f;
            Item[] item1 = new Item[10];
            Game[] game1 = new Game[10];
            Platform[] platform1 = new Platform[10];
            int number;
            Console.WriteLine("Введите название магазина");
            name = Console.ReadLine();
            Console.WriteLine("Введите адрес магазина");
            adress = Console.ReadLine();
            number = 0;
            Console.WriteLine("Добавить товар?(1 - да, все остальные символы - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                item1[number] = new Item();
                item1[number].read();
                number++;
                Console.WriteLine("Добавить еще один товар?(1 - да, все остальные символы -нет)");
                f = Console.ReadLine();
            }
            item = new Array<Item>(item1, number);
            number = 0;
            Console.WriteLine("Добавить игру?(1 - да, все остальные символы - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                game1[number] = new Game();
                game1[number].read();
                number++;
                Console.WriteLine("Добавить еще одну игру?(1 - да, все остальные символы -нет)");
                f = Console.ReadLine();
            }
            game = new Array<Game>(game1, number);
            number = 0;
            Console.WriteLine("Добавить консоль?(1 - да, все остальные символы - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                platform1[number] = new Platform();
                platform1[number].read();
                number++;
                Console.WriteLine("Добавить еще одну консоль?(1 - да, все остальные символы -нет)");
                f = Console.ReadLine();
            }
            platform = new Array<Platform>(platform1, number);
        }
        public Store(string name, string adress, int numberOfItems, Item[] item, int numberOfGames, Game[] game, int numberOfPlatforms, Platform[] platform)
        {
            this.name = name;
            this.adress = adress;
            this.item = new Array<Item>(item, numberOfItems);
            this.game = new Array<Game>(game, numberOfGames);
            this.platform = new Array<Platform>(platform, numberOfPlatforms);
        }
        public Store(string name)
        {
            this.name = name;
            this.adress = "-";
        }
        public Store()
        {
            this.name = "-";
            this.adress = "-";
        }
        public void display()
        {
            int i;
            Console.WriteLine("Название магазина:" + name);
            Console.WriteLine("Адрес:" + adress);
            item.display();
            game.display();
            platform.display();
        }
        public static Store operator ++ (Store store)
        {
            Store newStore = new Store();
            string f;
            int n;
            newStore.name = store.name;
            newStore.adress = store.adress;
            newStore.item = store.item;
            newStore.game = store.game;
            newStore.platform = store.platform;
            Console.WriteLine("Добавить товар (1), игру (2) или консоль (3)");
            f = Console.ReadLine();
            if (f == "1")
            {
                Item a = new Item();
                a.read();
                newStore.item.Add(a);
            }
            else if (f == "2")
            {
                Game a = new Game();
                a.read();
                newStore.game.Add(a);
            }
            else
            {
                Platform a = new Platform();
                a.read();
                newStore.platform.Add(a);
            }
            return newStore;
        }
        public void priceChange(string code, double price)
        {
            Item item1;
            item1 = null;
            Game game1;
            game1 = null;
            Platform platform1;
            platform1 = null;
            item1 = item.find(code);
            if(item1 != null)
            {
                item1.Price = price;
            }
            if (item1 == null)
            {
                game1 = game.find(code);
                if (game1 != null)
                {
                    game1.Price = price;
                }
            }
            if (game1 == null && item1 == null)
            {
                platform1 = platform.find(code);
                if (platform1 != null)
                {
                    platform1.Price = price;
                }
            }
        }
        public void amountChange(string code, int amountDifference)
        {
            Item item1;
            item1 = null;
            Game game1;
            game1 = null;
            Platform platform1;
            platform1 = null;
            item1 = item.find(code);
            if (item1 != null)
            {
                item1.Amount = item1.Amount + amountDifference;
            }
            if (item1 == null)
            {
                game1 = game.find(code);
                if (game1 != null)
                {
                    game1.Amount = game1.Amount + amountDifference;
                }
            }
            if (game1 == null && item1 == null)
            {
                platform1 = platform.find(code);
                if (platform1 != null)
                {
                    platform1.Amount = platform1.Amount + amountDifference;
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
            Store newStore = new Store();
            newStore.name = store1.name;
            newStore.adress = store1.adress;
            newStore.item = store1.item.sum(store2.item);
            newStore.game = store1.game.sum(store2.game);
            newStore.platform = store1.platform.sum(store2.platform);
            return newStore;
        }
        public void add(string code)
        {
            Game game1;
            game1 = null;
            Platform platform1;
            platform1 = null;
            game1 = game.find(code);
            if (game1 != null)
            {
                game1.add();
            }
            else
            {
                platform1 = platform.find(code);
                if (platform1 != null)
                {
                    platform1.add();
                }
            }
        }
    }
}
