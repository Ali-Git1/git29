using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueShopping = true;

            while (continueShopping)
            {
                var products = GetProductsFromUser();
                var market = new Market(products);
                var customer = GetCustomerInfoFromUser();

                customer.InBasket();

                market.Buy(customer);

                Console.Write("Tekrar alışveriş etmek isteyirsiz? (B/X): ");
                continueShopping = Console.ReadLine().Trim().ToLower() == "e";
            }
        }

        static Product[] GetProductsFromUser()
        {
            Console.WriteLine("Mehsul melumatlarini daxil edin:");
            Console.Write("Mehsulun sayi: ");
            int productCount;
            while (!int.TryParse(Console.ReadLine(), out productCount) || productCount <= 0)
            {
                Console.WriteLine("Zehmet olmasa musbet eded daxil edin");
                Console.Write("Mehsulun sayi: ");

            }

            var products = new Product[productCount];
            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine($"Mehsul {i + 1}:");
                Console.Write("Ad: ");
                var name = Console.ReadLine();

                decimal price;
                while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
                {
                    Console.WriteLine("Zehmet olmasa musbet eded daxil edin");
                    Console.Write("Qiymet: ");
                }

                int inStockCount;
                while (!int.TryParse(Console.ReadLine(), out inStockCount) || inStockCount < 0)
                {
                    Console.WriteLine("Zehmet olmasa musbet eded daxil edin");
                    Console.Write("Stok sayi: ");
                }

                products[i] = new Product { Name = name, Price = price, InStockCount = inStockCount };
            }

            return products;
        }

        static Customer GetCustomerInfoFromUser()
        {
            Console.WriteLine("Musteri melumatlarini daxil edin:");
            var customer = new Customer();

            Console.Write("Ad: ");
            customer.Name = Console.ReadLine();

            Console.Write("Soyad: ");
            customer.Surname = Console.ReadLine();

            decimal cashBalance;
            while (!decimal.TryParse(Console.ReadLine(), out cashBalance) || cashBalance < 0)
            {
                Console.WriteLine("Zehmet olmasa musbet eded daxil edin");
                Console.Write("Nagd vesaitiniz: ");
            }
            customer.CashBalance = cashBalance;

            decimal cardBalance;
            while (!decimal.TryParse(Console.ReadLine(), out cardBalance) || cardBalance < 0)
            {
                Console.WriteLine("Zehmet olmasa musbet eded daxil edin");
                Console.Write("Kart vesaitiniz: ");
            }
            customer.CardBalance = cardBalance;

            int paymentInput;
            while (!int.TryParse(Console.ReadLine(), out paymentInput) || !Enum.IsDefined(typeof(PaymentMethod), paymentInput))
            {
                Console.WriteLine("Zehmet olmasa 0 veya 1 girin.");
                Console.Write("Odenis novu (0: Nagd, 1: Bank Kartı): ");
            }
            customer.Payment = (PaymentMethod)paymentInput;

            return customer;
        }

        public enum PaymentMethod
        {
            Nagd = 0,
            BankKarti = 1
        }

    }
}
