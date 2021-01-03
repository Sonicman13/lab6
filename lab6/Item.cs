using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public delegate void Cha(int ab, Item item);
    interface Add
    {
        void add();
    }
    public class Item
    {
        protected string code;
        protected string name;
        protected int price;
        protected int amount;
        virtual public void read()
        {
            Console.WriteLine("Введите название товара");
            name = Console.ReadLine();
            Console.WriteLine("Введите код товара");
            code = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите цену");
                try
                {
                    price = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    price = -1;
                }
            } while (price < 0);
            do
            {
                Console.WriteLine("Введите колличество товара");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    amount = -1;
                }
            } while (amount < 0);
        }
        public Item(string code, string name, int price, int amount)
        {
            this.name = name;
            this.code = code;
            this.price = price;
            this.amount = amount;
        }
        public Item()
        {
            this.name = "-";
            this.code = "-";
            this.price = 0;
            this.amount = 0;
        }
        virtual public void display()
        {
            Console.WriteLine("Код товара:" + code);
            Console.WriteLine("Название товара:" + name);
            Console.WriteLine("Цена:" + price);
            Console.WriteLine("Колличество:" + amount);
        }
        static public void setAmount(int amount, Item item)
        {
            item.amount = item.amount + amount;
        }
        public int Amount
        {
            set
            {
                if(value > 0)
                {
                    amount = value;
                }
            }
            get
            {
                return amount;
            }
        }
        static public void setPrice(int price, Item item)
        {
            item.price = price;
        }
        public int Price
        {
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }
        public string Code
        {
            get
            {
                return code;
            }
        }
    }

    class Game : Item, Add, ICloneable
    {
        private int[] release = new int[3];
        private string[] platforms = new string[10];
        private string publisher;
        public Game()
        {
            this.name = "-";
            this.code = "-";
            this.price = 0;
            this.amount = 0;
            this.release[0] = this.release[1] = this.release[2] = -1;
            platforms[0] = "-";
            publisher = "-";
        }
        public Game(string code, string name, int price, int amount, int[] release, string[] platforms, string publisher):base(code, name, price, amount)
        {
            int i;
            for (i = 0; i < 3; i++)
            {
                this.release[i] = release[i];
            }
            for (i = 0; i < platforms.Length; i++)
            {
                this.platforms[i] = platforms[i];
            }
            this.publisher = publisher;
        }
        public override void read()
        {
            int d;
            Console.WriteLine("Введите название товара");
            name = Console.ReadLine();
            Console.WriteLine("Введите код товара");
            code = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите цену");
                try
                {
                    price = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    price = -1;
                }
            } while (price < 0);
            do
            {
                Console.WriteLine("Введите колличество товара");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    amount = -1;
                }
            } while (amount < 0);
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
        }
        public override void display()
        {        
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            int d;
            string s;
            s = "Код товара: " + code + "\n";
            s += "Название товара: " + name + "\n";
            s += "Цена: " + price + "\n";
            s += "Колличество: " + amount + "\n";
            s += "Дата выхода: " + release[0] + "." + release[1] + "." + release[2] + "\n";
            s += "Платформы: ";
            for (d = 0; d < platforms.Length; d++)
            {
                s += platforms[d] + ", ";
            }
            s += "\n" + "Издатель: " + publisher;
            return s;
        }
        public void add()
        {
            int i;
            i = 0;
            while (platforms[i] != "")
            {
                i++;
            }
            Console.WriteLine("Введите платформу на которой доступна игра");
            platforms[i] = Console.ReadLine();
        }
        public object Clone()
        {
            return new Game(code, name, price, amount, release, platforms, publisher);
        }
    }

    class Platform : Item, Add
    {
        private string[] components = new string[10];
        private string[] plusPlatforms = new string[10];
        private string publisher;
        public Platform()
        {
            this.name = "-";
            this.code = "-";
            this.price = 0;
            this.amount = 0;
            this.components[0] = "-";
            this.plusPlatforms[0] = "-";
            this.publisher = "-";
        }
        public Platform(string code, string name, int price, int amount, string[] components, string[] platforms, string publisher):base(code, name, price, amount)
        {
            int i;
            for (i = 0; i < components.Length; i++)
            {
                this.components[i] = components[i];
            }
            for (i = 0; i < platforms.Length; i++)
            {
                this.plusPlatforms[i] = platforms[i];
            }
            this.publisher = publisher;
        }
        public override void read()
        {
            int d;
            Console.WriteLine("Введите название товара");
            name = Console.ReadLine();
            Console.WriteLine("Введите код товара");
            code = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите цену");
                try
                {
                    price = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    price = -1;
                }
            } while (price < 0);
            do
            {
                Console.WriteLine("Введите колличество товара");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    amount = -1;
                }
            } while (amount < 0);
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
                plusPlatforms[d] = Console.ReadLine();
            } while (plusPlatforms[d] != "");
            Console.WriteLine("Введите издателя");
            publisher = Console.ReadLine();
        }
        public override void display()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            int d;
            string s;
            s = "Код товара: " + code + "\n";
            s += "Название товара: " + name + "\n";
            s += "Цена: " + price + "\n";
            s += "Колличество: " + amount + "\n";
            s += "Комплектация: ";
            for (d = 0; d < components.Length; d++)
            {
                s += components[d] + ", ";
            }
            s += "\n" + "Платформы доступные по обратной совместимости: ";
            for (d = 0; d < plusPlatforms.Length; d++)
            {
                s += plusPlatforms[d] + ", ";
            }
            s += "\n" + "Издатель: " + publisher;
            return s;
        }
        public void add()
        {
            int i;
            i = 0;
            while (components[i] != "")
            {
                i++;
            }
            Console.WriteLine("Введите комплектующие");
            components[i] = Console.ReadLine();
        }
    }

    class Array<T> where T : Item
    {
        private T[] it;
        private int size;
        public Array()
        {
            size = 0;
        }
        public Array(T[] o, int size)
        {
            it = o;
            this.size = size;
        }
        public void display()
        {
            int i;
            for(i = 0; i< size; i++)
            {
                Console.WriteLine("Товар" + i);
                it[i].display();
            }
        }
        public void Add(T o)
        {
            it[size] = o;
            size++;
        }
        public T find(string code)
        {
            int i;
            i = 0;
            while (i < size)
            {
                if (it[i].Code == code)
                {
                    return it[i];
                }
                i++;
            }
            return null;
        }
        public Array<T> sum(Array<T> it2)
        {
            Array<T> it3 = new Array<T>();
            int i;
            it3.it = this.it;
            it3.size = this.size;
            for(i = 0; i < it2.size; i++)
            {
                it3.it[it3.size] = it2.it[i];
                it3.size++;
            }
            return it3;
        }
    }

    
}
