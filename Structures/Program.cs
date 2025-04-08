using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
/*
 * Описать структуру Кассовый чек. Предусмотреть метод добаления информации о товаре (товар выражен в коде отдельной структурой) в чек (наименование товара, количество, цена за единицу товара, скидка) в чек, метод распечатки чека на экране консоли. 
 
 */
namespace Structures
{
    internal class Program
    {
        struct CashReceipt
        {
            private static int idCounter;
            private static string organization;

            private List<Good> goods;
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Cashier { get; set; }
            public List<Good> Goods
            {
                get { return goods; }
                private set { goods = value; }
            }
            static CashReceipt()
            {
                idCounter = 0;
                organization = "";
            }
           
            public CashReceipt( string cashier, string org)
            {
                if (organization == null || organization.Length == 0)
                {
                    organization = org;
                }

                ++idCounter;
                Id = idCounter;
                Date = DateTime.Now;
                Cashier = cashier;
                goods = new List<Good>();
            }
            public CashReceipt(string cashier) :this(cashier, "")
            {
            }

            public void AddGood(Good good)
            {
                if (goods == null)
                {
                    goods = new List<Good>();
                }
                bool isInList = false;
                for(int i = 0; i < goods.Count; i++) // 
                {
                    if (goods[i].id == good.id)
                    {
                        var updatedGood = goods[i];
                        updatedGood.Quantity++;
                        updatedGood.Price = goods[i].Price + good.Price;
                        goods[i] = updatedGood;
                        isInList = true;
                        break;                   
                    }
                }
                if (!isInList)
                    goods.Add(good);
            }
            public void PrintReceipt()
            {
                Console.WriteLine($"Receipt ID: {Id}");
                Console.WriteLine($"Date: {Date}");
                Console.WriteLine($"Organization: {organization}");
                Console.WriteLine($"Cashier: {Cashier}");
                Console.WriteLine("\nПродукты:\tКоличество:\tЦена:\tСкидка:");
                double sum = 0;
                int textLength = 5;
                foreach (var good in goods)
                {
                    Console.Write("- ");
                    Console.Write(good.Name.Length <= textLength ? good.Name : good.Name.Substring(0, textLength));
                    Console.WriteLine($"\t\t{good.Quantity}\t\t{good.Price - good.Price * good.Discount}\t{good.Discount}");
                    sum += good.Price - good.Price * good.Discount;
                }
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine($"Стоимость покупки: {sum} грн.");
            }
        }
        struct Good
        {
            static int idCounter = 0;
            public int id { get; set; } = idCounter++;
            public string Name { get; set; } = "unknown";
            public int Quantity { get; set; } = 1;
            public double Price { get; set; } = 0;
            public double Discount { get; set; } = 0;
            public Good(string name, double price) : this(name, 0, price, 0)
            {
            }
            public Good(string name, int quantity, double price) : this(name, quantity, price, 0)
            {
            }
            public Good(string name, int quantity, double price, double discount)
            {
                Name = name;
                Quantity = quantity;
                Price = price;
                Discount = discount;
            }
        }
        
        struct Basket
        {
            private List<Good> goods;
            public Basket()
            {
                goods = new List<Good>();
            }
            public List<Good> Goods
            {
                get { return goods; }
                private set { goods = value; }
            }
            public void AddGood(Good good)
            {
                goods.Add(good);
            }
        }

        /////////////////////////////////////////////////////////////////////////     
        /*Создайте три структуры, каждая из которых будет описывать один предмет из окружающего мира. У каждой структуры должно быть не менее 5 полей, которые подробно характеризуют выбранный предмет. Например: Книга: название, автор, количество страниц, год издания, жанр. Телефон: марка, модель, объем памяти, диагональ экрана, емкость батареи. Автомобиль: марка, модель, год выпуска, тип двигателя, пробег. Для каждой структуры создайте как минимум один экземпляр, заполните его данными и выведите информацию о каждом предмете в консоль. Код необходимо прислать ссылкой в комментарий к ДЗ на ваш публичный репозиторий с проектом
        */
        struct Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Pages { get; set; }
            public int Year { get; set; }
            public string Genre { get; set; }
            public Book(string title, string author, int pages, int year, string genre)
            {
                Title = title;
                Author = author;
                Pages = pages;
                Year = year;
                Genre = genre;
            }
            public void Print()
            {
                Console.WriteLine($"\nTitle: {Title}, \nAuthor: {Author}, \nPages: {Pages}, \nYear: {Year}, \nGenre: {Genre}");
            }
        }

        struct Phone
        {
           public string Brand { get; set; }
           public string Model { get; set; }
           public int Memory { get; set; }
           public double ScreenSize { get; set; }
           public int BatteryCapacity { get; set; }
            public Phone(string brand, string model, int memory, double screenSize, int batteryCapacity)
            {
                Brand = brand;
                Model = model;
                Memory = memory;
                ScreenSize = screenSize;
                BatteryCapacity = batteryCapacity;
            }
            public void Print()
            {
                Console.WriteLine($"\nBrand: {Brand}, \nModel: {Model}, \nMemory: {Memory}GB, \nScreen Size: {ScreenSize} inches, \nBattery Capacity: {BatteryCapacity}mAh");
            }
        }
        struct Car
        {
           public string Brand { get; set; }
           public string Model { get; set; }
           public int Year { get; set; }
           public string EngineType { get; set; }
           public int Mileage { get; set; }
           public Car(int year, string brand, string model, string engineType, int mileage)   
            {   Year = year;
                Brand = brand;
                Model = model;
                EngineType = engineType;
                Mileage = mileage;
            }
            public void Print()
            {
                Console.WriteLine($"\nBrand: {Brand},\nModel: {Model}, \nYear: {Year}, \nEngine Type: {EngineType}, \nMileage: {Mileage} km");
            }
        }
        static void Main(string[] args)
        {
            Basket basket = new Basket();
            Good good1 = new Good("Молоко", 1, 50);
            Good good2 = new Good("Хлеб", 1, 20);
            Good good3 = new Good("Масло", 1, 100, 0.1);
            Good good4 = new Good("Сыр", 1, 200, 0.2);
            Good good5 = new Good("Соус", 1, 300, 0.3);
            basket.AddGood(good1);
            basket.AddGood(good2);
            basket.AddGood(good2);
            basket.AddGood(good3);
            basket.AddGood(good4);
            basket.AddGood(good5);
            basket.AddGood(good5);
            CashReceipt receipt = new CashReceipt("Ковалева А. Н. идентификатор: 123456", "Milk Store");
            for (int i = 0; i < basket.Goods.Count; i++)
            {
                receipt.AddGood(basket.Goods[i]);
            }
            receipt.PrintReceipt();

            /////////////////////////////////
            Book book = new Book("Война и мир", "Лев Толстой", 1225, 1869, "Историческая фантастика");
            Book book2 = new Book("1984", "Джордж Орвел", 328, 1949, "фантастика");
            Console.WriteLine("\n\nbooks:");
            book.Print();
            book2.Print();

            
            Phone phone = new Phone("Apple", "iPhone 14", 128, 6.1, 3279);
            Phone phone2 = new Phone("Samsung", "Galaxy S21", 256, 6.2, 4000);
            Phone phone3 = new Phone("Xiaomi", "Mi 11", 128, 6.81, 4600);
            Console.WriteLine("\n\nphones:");
            phone.Print();
            phone2.Print();
            phone3.Print();

         
            Car car = new Car(2020, "Toyota", "Camry", "Бензиновый", 15000);
            Car car2 = new Car(2018, "Honda", "Civic", "Дизельный", 30000);
            Car car3 = new Car(2021, "Tesla", "Model 3", "Электрический", 5000);
            Console.WriteLine("\n\ncars:");
            car.Print();
            car2.Print();
            car3.Print();

        }
    }
}
