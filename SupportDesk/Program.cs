using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportDesk.Logic;
using SupportDesk.Data;

namespace SupportDesk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SupportDesk - Олег");
            string jsonPath = Path.Combine(AppContext.BaseDirectory,"tickets.json");
            string xmlPath = Path.Combine(AppContext.BaseDirectory,"tickets.xml");
            string kind = args.Length > 0 ? args[0] : "json";
            ITicketRepository repository = kind switch
            {
                "xml" => new XmlTicketRepository(xmlPath),
                "memory" => new TicketRepository(),
                _ => new JsonTicketRepository(jsonPath)
            };
            Console.WriteLine($"Хранилище: {kind}");
            var service = new TicketService(repository);
            Console.Write($"Выбор:\n1-Добавить заявку;\n2-Подсчитать заявки по заданному приоритету.\nВвод: ");
            string a = Console.ReadLine() ?? "";
            string prior = "";
            if (a == "1")
            {
                Console.Write("Тема новой заявки: ");
                string subject = Console.ReadLine() ?? "";
                Console.Write("Приоритет новой заявки (high, medium, low): ");
                string priority = Console.ReadLine() ?? "";
                service.AddTicket(subject, priority);
            }
            else if (a == "2")
            {
                Console.Write($"По какому приоритету подсчитать заявки (high, medium, low): ");
                prior = Console.ReadLine() ?? "";
            }
            else
            {
                Console.WriteLine($"Ошибка ввода!");
            }
            int i = 0;
            Console.WriteLine("Отобранные записи:");
            foreach (var item in service.GetImportant())
            {
                Console.WriteLine($"{item.Id}: {item.Subject}, {item.Priority}");
                if(item.Priority == prior)
                {
                    i++;
                }
            }
            if (a == "2")
            {
                Console.WriteLine($"Количество заявок приоритета {prior}: {i}");
            }
        }
    }
}