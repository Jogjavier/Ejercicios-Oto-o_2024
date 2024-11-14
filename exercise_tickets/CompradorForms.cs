namespace exercise_tickets;

public class CompradorForms
{
    private List<Ticket> boletosComprados;
    private readonly Comprador _comprador;
    private readonly Vendedor _vendedor;

    public CompradorForms(Comprador comprador)
    {
        boletosComprados = new List<Ticket>();
        this._comprador = comprador; 
    }
    
    public void ComprarBoleto(int ticketId, List<Ticket> listaTickets)
    {
        var ticket = listaTickets.FirstOrDefault(x => x.Id == ticketId && x.Status == StatusTicket.OnSale);

        if (ticket != null)
        {
            ticket.Status = StatusTicket.Sold;
            boletosComprados.Add(ticket);  //este nombre depende del método que haga Javier
            Console.WriteLine($"Boleto comprado: {ticket.NombreEvento} por {ticket.Precio}");

            MostrarBoletosComprados();
        }
        else
        {
            Console.WriteLine("Boleto no disponible o no existe.");
        }
    }

    public void MostrarBoletosComprados()
    {
        if (boletosComprados.Count == 0)
        {
            Console.WriteLine("No has comprado boletos.");
            return;
        }
        Console.WriteLine("Boletos comprados: ");
        foreach (var boleto in boletosComprados)
        {
            Console.WriteLine($"ID: {boleto.Id}, Evento: {boleto.NombreEvento}, Precio: {boleto.Precio}");
        }
    }
    public void GuardarTicketsComprados()
    {
        string fileName = $"tickets_vendedor_{_vendedor.Id}.txt";

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"Tickets Comprados por {_comprador.Nombre}:");
            foreach (var ticket in boletosComprados)
            {
                writer.WriteLine($"ID: {ticket.Id}, Evento: {ticket.NombreEvento}, Precio: {ticket.Precio}");
            }
        }
        Console.WriteLine($"Tickets comprados guardados en el archivo: {fileName}");
    }
}