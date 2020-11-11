using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Item
    {
        private string code;
        private string name;
        private double price;
        private int amount;
        public void read()
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
                    price = Convert.ToDouble(Console.ReadLine());
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
        public Item(string code, string name, double price, int amount)
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
        public void display()
        {
            Console.WriteLine("Код товара:" + code);
            Console.WriteLine("Название товара:" + name);
            Console.WriteLine("Цена:" + price);
            Console.WriteLine("Колличество:" + amount);
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
        public double Price
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
}
