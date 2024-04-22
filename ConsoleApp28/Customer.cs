using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp28.Program;

namespace ConsoleApp28
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public PaymentMethod Payment { get; set; }
        public decimal CashBalance { get; set; }
        public decimal CardBalance { get; set; }

        public void InBasket()
        {
            Console.WriteLine("Səbətinizdə olan məhsul əməliyyatları icra olunacaq");
        }
    }
}
