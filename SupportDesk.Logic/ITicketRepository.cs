using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDesk.Logic
{
    public interface ITicketRepository
    {
        List<Ticket> GetAll();
    }
}
