using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportDesk.Logic;

namespace SupportDesk.Data
{
    public class DemoTicketRepository : ITicketRepository
    {
        public List<Ticket> GetAll()
        {
            return new List<Ticket>
            {
                new Ticket{ Id = 100, Subject = "Демонстрационная запись", Priority = "high"}
            };
        }
    }
}
