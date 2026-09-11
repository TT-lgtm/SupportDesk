using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SupportDesk.Logic;
namespace SupportDesk.Data;
public class XmlTicketRepository : ITicketRepository
{
    private readonly string _path;
    private readonly XmlSerializer _serializer =
    new(typeof(List<Ticket>));
    public XmlTicketRepository(string path)
    {
        _path = path;
    }
    public List<Ticket> GetAll()
    {
        if (!File.Exists(_path))
        {
            return new List<Ticket>();
        }
        using var reader = new StreamReader(_path);
        return _serializer.Deserialize(reader) as List<Ticket> ?? new
        List<Ticket>();
    }
    public void Add(Ticket item)
    {
        List<Ticket> items = GetAll();
        items.Add(item);
        using var writer = new StreamWriter(_path);
        _serializer.Serialize(writer, items);
    }
}
