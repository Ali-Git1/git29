using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp28.Program;

namespace ConsoleApp28
{
    internal class Market
    {
        private Product[] products;

        public Market(Product[] products)
        {
            this.products = products;
        }

        public void Buy(Customer customer)
        {
            decimal totalPrice = 0;
            foreach (var product in products)
            {
                totalPrice += product.Price;
            }

            if (customer.Payment == PaymentMethod.Nagd)
            {
                if (totalPrice > customer.CashBalance)
                {
                    Console.WriteLine("Nagd odenis catmir. Eskik hisseni bank kartindan odemek isteyirsiz? (B/X): ");
                    var response = Console.ReadLine().Trim().ToLower();
                    if (response == "e")
                    {
                        if (totalPrice <= customer.CashBalance + customer.CardBalance)
                        {
                            Console.WriteLine("Qalan pul bank kartinizdan cixildi.");
                            customer.CashBalance -= totalPrice;
                            customer.CardBalance -= totalPrice - customer.CashBalance;
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Nagd odenis catmir. Zehmet olmasa balans yoxlayin.");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    customer.CashBalance -= totalPrice;
                }
            }
            else if (customer.Payment == PaymentMethod.BankKarti)
            {
                if (totalPrice > customer.CardBalance)
                {
                    Console.WriteLine("Kart balansi catmir Eskik olan hisseni nagd odemek isteyirsiz? (B/X): ");
                    var response = Console.ReadLine().Trim().ToLower();
                    if (response == "e")
                    {
                        if (totalPrice <= customer.CashBalance + customer.CardBalance)
                        {
                            Console.WriteLine("Qalan hisse nagd pul ile odenildi");
                            customer.CardBalance -= totalPrice;
                            customer.CashBalance -= totalPrice - customer.CardBalance;
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Nagd ve kart balansiniz catmir. Zehmet olmasa balansi yoxlayin.");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    customer.CardBalance -= totalPrice;
                }
            }
        }
    }
}
