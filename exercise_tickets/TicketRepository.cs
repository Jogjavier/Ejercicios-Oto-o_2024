public class TicketRepository
{
    private List<Ticket> _listaTickets;

    public TicketRepository()
    {
        _listaTickets = GetTickets();
    }

    public List<Ticket> GetTickets()
    {
        return new List<Ticket>
        {
            new Ticket
            {
                Id = 1,
                NombreEvento = "Concierto Rock",
                Status = StatusTicket.OnSale,
                Precio = 75.50
            },
            new Ticket
            {
                Id = 2,
                NombreEvento = "Festival de Jazz",
                Status = StatusTicket.OnSale,
                Precio = 120.00
            },
            new Ticket
            {
                Id = 3,
                NombreEvento = "Teatro Musical",
                Status = StatusTicket.OnSale,
                Precio = 95.00
            },
            new Ticket
            {
                Id = 4,
                NombreEvento = "Partido de Fútbol",
                Status = StatusTicket.OnSale,
                Precio = 85.00
            },
            new Ticket
            {
                Id = 5,
                NombreEvento = "Exposición de Arte",
                Status = StatusTicket.OnSale,
                Precio = 45.00
            }
        };
    }

    public void CambiarEstadoTicket(int ticketId, int? compradorId, StatusTicket nuevoStatus)
    {
        var ticket = _listaTickets.FirstOrDefault(t => t.Id == ticketId);

        if (ticket == null)
        {
            Console.WriteLine("El ticket no existe.");
            return;
        }

        if (ticket.Status == StatusTicket.Sold)
        {
            Console.WriteLine("El ticket ya ha sido vendido.");
            return;
        }

        ticket.Status = nuevoStatus;

        ticket.Comprador = new Usuario { Id = compradorId.Value };

        Console.WriteLine($"El ticket con ID {ticket.Id} ahora tiene el estado {ticket.Status}.");
    }
}
