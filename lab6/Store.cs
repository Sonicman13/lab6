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
        private int numberOfGames;
        private int numberOfPlatforms;
        private Game[] game = new Game[5];
        private Platform[] platform = new Platform[5];
        public void read()
        {
            string f;
            Console.WriteLine("Введите название магазина");
            name = Console.ReadLine();
            Console.WriteLine("Введите адрес магазина");
            adress = Console.ReadLine();
            numberOfGames = 0;
            Console.WriteLine("Добавить игру?(1 - да, все остальные символы - нет)");
            f = Console.ReadLine();
            while (f == "1")
            {
                game[numberOfGames] = new Game();
                game[numberOfGames].read(1);
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
                platform[numberOfPlatforms].read(1);
                numberOfPlatforms++;
                Console.WriteLine("Добавить еще одну консоль?(1 - да, все остальные символы -нет)");
                f = Console.ReadLine();
            }
        }
        public Store(string name, string adress, int numberOfGames, Game[] game, int numberOfPlatforms, Platform[] platform)
        {
            int i;
            this.name = name;
            this.adress = adress;
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
        public Store(string name)
        {
            this.name = name;
            this.adress = "-";
            this.numberOfGames = 0;
            this.numberOfPlatforms = 0;
        }
        public Store()
        {
            this.name = "-";
            this.adress = "-";
            this.numberOfGames = 0;
            this.numberOfPlatforms = 0;
        }
        public void display()
        {
            int i;
            Console.WriteLine("Название магазина:" + name);
            Console.WriteLine("Адрес:" + adress);
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
            string f;
            int n;
            newStore.name = store.name;
            newStore.adress = store.adress;
            newStore.numberOfGames = store.numberOfGames;
            newStore.numberOfPlatforms = store.numberOfPlatforms;
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
            Console.WriteLine("Добавить игру (1) или консоль (2)");
            f = Console.ReadLine();
            if (f == "1")
            {
                newStore.game[store.numberOfGames] = new Game();
                newStore.game[store.numberOfGames].read(1);
                newStore.numberOfGames = ++store.numberOfGames;
            }
            else
            {
                newStore.platform[store.numberOfPlatforms] = new Platform();
                newStore.platform[store.numberOfPlatforms].read(1);
                newStore.numberOfPlatforms = ++store.numberOfPlatforms;
            }
            return newStore;
        }
        public void priceChange(string code, double price)
        {
            int i, f;
            i = f = 0;
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
            int i, f;
            i = f = 0;
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
            newStore.name = store1.name;
            newStore.adress = store1.adress;
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
        public void add(string code)
        {
            int i, f;
            i = f = 0;
            while (i < numberOfGames)
            {
                if (game[i].Code == code)
                {
                    game[i].add();
                    i = numberOfGames;
                    f = 1;
                }
                i++;
            }
            if (f == 0)
            {
                i = 0;
                while (i < numberOfPlatforms)
                {
                    if (platform[i].Code == code)
                    {
                        platform[i].add();
                        i = numberOfPlatforms;
                        f = 1;
                    }
                    i++;
                }
            }
        }
    }
}
