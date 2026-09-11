using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using SupportDesk.Logic;
namespace SupportDesk.Data;
public class JsonTicketRepository : ITicketRepository
{
    private readonly string _path;
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
    public JsonTicketRepository(string path)
    {
        _path = path;
    }
    public List<Ticket> GetAll()
    {
        if (!File.Exists(_path))
        {
            return new List<Ticket>();
        }
        string text = File.ReadAllText(_path);
        try
        {
            return JsonSerializer.Deserialize<List<Ticket>>(text) ?? new
            List<Ticket>();
        }
        catch (JsonException)
        {
            return new List<Ticket>();
        }
    }

    public void Add(Ticket item)
    {
        List<Ticket> items = GetAll();
        items.Add(item);
        string text = JsonSerializer.Serialize(items, _options);
        File.WriteAllText(_path, text);
    }
}
