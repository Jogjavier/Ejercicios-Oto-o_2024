namespace exercise_tickets;

public class CompradorForms
{
    private List<Ticket> boletosComprados;
    private readonly Comprador _comprador;
    private readonly Vendedor _vendedor;

    // Constructor: Inicializa la lista de boletos comprados y establece el comprador actual
    public CompradorForms(Comprador comprador)
    {
        boletosComprados = new List<Ticket>();
        this._comprador = comprador; 
    }
    
    public void CapturaDatosComprador()
    {
        Console.WriteLine("\nNombre: ");
        _comprador.Nombre = Console.ReadLine();

        Console.WriteLine("Direccion");
        _comprador.Direccion = Console.ReadLine();

        Console.WriteLine("Email");
        _comprador.Email = Console.ReadLine();

        // Crea una cadena que combina los datos del vendedor en formato CSV   
        var fila = $"{_comprador.Nombre}, {_comprador.Direccion}, {_comprador.Email}";

        // Agrega la cadena en formato csv al archivo
        File.AppendAllText("comprador_data.txt", fila + Environment.NewLine);

    }
    // Método para comprar un boleto específico
    public void ComprarBoleto(int ticketId, List<Ticket> listaTickets)
    {

        // Busca el ticket en la lista, verificando que esté disponible para la venta
        var ticket = listaTickets.FirstOrDefault(x => x.Id == ticketId && x.Status == StatusTicket.OnSale);

        // Si el ticket está disponible
        if (ticket != null)
        {
            // Cambia el estado del ticket a vendido
            ticket.Status = StatusTicket.Sold;
            
            // Añade el ticket a la lista de boletos comprados
            boletosComprados.Add(ticket);

            // Confirma la compra mostrando los detalles del ticket
            Console.WriteLine($"Boleto comprado: {ticket.NombreEvento} por {ticket.Precio}");
            
            // Muestra los boletos comprados hasta el momento
            MostrarBoletosComprados();
        }
        else
        {
            // Muestra un mensaje si el ticket no está disponible o no existe
            Console.WriteLine("Boleto no disponible o no existe.");
        }
    }

    // Método para mostrar en consola los boletos comprados por el comprador
    public void MostrarBoletosComprados()
    {
        // Verifica si la lista de boletos comprados está vacía
        if (boletosComprados.Count == 0)
        {
            Console.WriteLine("No has comprado boletos.");
            return;
        }
        // Muestra los detalles de cada boleto comprado
        Console.WriteLine("Boletos comprados: ");
        foreach (var boleto in boletosComprados)
        {
            Console.WriteLine($"ID: {boleto.Id}, Evento: {boleto.NombreEvento}, Precio: {boleto.Precio}");
        }
    }

    // Método para guardar los boletos comprados en un archivo de texto
    public void GuardarTicketsComprados()
    {
        // Crea un nombre de archivo único basado en el ID del vendedor
        string fileName = $"tickets_vendedor_{_vendedor.Id}.txt";

        // Usa StreamWriter para escribir los detalles de los boletos comprados en el archivo
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            // Escribe un encabezado con el nombre del comprador
            writer.WriteLine($"Tickets Comprados por {_comprador.Nombre}:");
            
            // Escribe los detalles de cada boleto comprado
            foreach (var ticket in boletosComprados)
            {
                writer.WriteLine($"ID: {ticket.Id}, Evento: {ticket.NombreEvento}, Precio: {ticket.Precio}");
            }
        }
        // Confirma que los datos fueron guardados
        Console.WriteLine($"Tickets comprados guardados en el archivo: {fileName}");
    }
}
