using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportDesk.Logic;

namespace SupportDesk.Data
{
    public class TicketRepository : ITicketRepository
    {
        private readonly List<Ticket> _items = new()
        {
            new Ticket {Id = 1, Subject = "Не работает принтер", Priority = "high"},
            new Ticket {Id = 2, Subject = "Забыт пароль", Priority = "low"},
            new Ticket {Id = 3, Subject = "Сбой сети", Priority = "high"},
            new Ticket {Id = 4, Subject = "Залипание клавишь", Priority = "medium"}
        };
        public List<Ticket> GetAll()
        {
            return _items;
        }
        public void Add(Ticket item)
        {
            _items.Add(item);
        }
    }
}
