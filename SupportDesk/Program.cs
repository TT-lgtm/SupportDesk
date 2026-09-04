using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportDesk.Logic;

namespace SupportDesk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SupportDesk - Олег");
            var service = new TicketService();
            Console.WriteLine("Отобранные записи:");
            foreach (var item in service.GetImportant())
            {
                Console.WriteLine($"{item.Id}: {item.Subject}");
            }
        }
    }
}