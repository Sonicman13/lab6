using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    struct Item
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
                price = Convert.ToDouble(Console.ReadLine());
            } while (price < 0);
            do
            {
                Console.WriteLine("Введите колличество товара");
                amount = Convert.ToInt32(Console.ReadLine());
            } while (amount < 0);
        }
        public void init(string code, string name, double price, int amount)
        {
            this.name = name;
            this.code = code;
            this.price = price;
            this.amount = amount;
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
                amount = value;
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
                price = value;
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
