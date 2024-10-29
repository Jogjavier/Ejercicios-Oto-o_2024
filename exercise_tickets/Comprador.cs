public class Comprador : Usuario
{   
   /* Crear un metodo que, reciba como parametro el id del boleto y cambie el status a vendido y muestre los boletos comprados por el usuario comprador */

    public void ComprarBoleto(int ticketId, List<Ticket> listaTickets)
    {
        var ticket = listaTickets.FirstOrDefault(this => this.Id == ticketId && this.Status == StatusTicket.OnSale);

        if (ticket != null)
        {
            ticket.Status = StatusTicket.Sold;
            boletosComprados.Add(ticket);  //este nombre depende del método que haga Javier
            Console.WriteLine($"Boleto comprado: {ticket.NombreEvento} por {ticket.Precio}");

            MostrarBoletosComprados()
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
            Console.WriteLine($"ID: {boleto.Id}, Evento: {boleto.NombreEvento}, Precio: {ticket.Precio}");
        }
    }
}