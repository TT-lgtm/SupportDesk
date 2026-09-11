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
            return _repository.GetAll().ToList();
        }
        public void AddTicket(string subject, string priority)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                return;
            }
            int nextId = _repository.GetAll().Count + 1;
            _repository.Add(new Ticket
            {
                Id = nextId,
                Subject = subject,
                Priority = priority
            });
        }
    }
}
