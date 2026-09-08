using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDesk.Logic
{
    public class TicketService
    {
        private readonly ITicketRepository _repository;
        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }

        public List<Ticket> GetImportant()
        {
            return _repository.GetAll().Where(item => item.Priority == "high").ToList();
        }
    }
}
