public class TicketForms 
{
    // Variable estática para generar identificadores únicos para los tickets
    static int id = 0;
    
    // Referencia al vendedor asociado a este formulario
    private readonly Vendedor _vendedor;
    
    // Lista de tickets disponibles para el vendedor
    public List<Ticket> _listaTickets {get;set;}

    // Constructor: Inicializa el formulario con un vendedor y obtiene la lista inicial de tickets
    public TicketForms(Vendedor vendedor)
    {
        this._vendedor = vendedor;
        this._listaTickets = GetTickets();        
    }
    
    // Muestra en consola los boletos disponibles que están a la venta
    public void MostrarBoletosDisponibles() 
    { 
        // Iterar sobre los tickets en estado "OnSale" y mostrarlos
        foreach(var item in _listaTickets.Where(x=> x.Status == StatusTicket.OnSale))
        {
            Console.WriteLine($"Ticket id : {item.Id}");
            Console.WriteLine($"Nombre : {item.NombreEvento}");
            Console.WriteLine($"Precio : {item.Precio}");
        }
    }
    
    // Genera una lista inicial de tickets predeterminados
    private List<Ticket> GetTickets()
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

    // Permite capturar un nuevo ticket y añadirlo a la lista de tickets disponibles
    public void CapturarNuevoTicket()
    { 
        Console.WriteLine("Evento del boleto");
        var NombreEvento = Console.ReadLine();

        Console.WriteLine("Precio del boleto");
        string strprecio = Console.ReadLine();

        // Validar el precio ingresado
        if(!double.TryParse( strprecio, out double precio))
        {
            Console.WriteLine("Precio no valido");
            return;
        }

        Console.WriteLine("Cuantos boletos tienes disponibles?");
        string strTicketDisp = Console.ReadLine();
       
        // Validar la cantidad de boletos disponibles
        if(int.TryParse(strTicketDisp, out int ticketsDisp))
         {
            for (int x=0; x<ticketsDisp;x++ )
            {
                id++; // Generar un nuevo ID para cada ticket
                Ticket ticket = new Ticket();
                ticket.Id = id;
                ticket.Precio = precio;
                ticket.NombreEvento = NombreEvento;
                ticket.Status = StatusTicket.OnSale;
                _listaTickets.Add(ticket); // Añadir el ticket a la lista
            }
         }
         else 
         {
            Console.WriteLine("Numero no valido");
        }
    }
  
    // Cambia el estado de un ticket
    public void CambiarEstadoTicket(int ticketId, int? compradorId, StatusTicket nuevoStatus)
    {
        // Buscar el ticket por ID
        var ticket = _listaTickets.FirstOrDefault(t => t.Id == ticketId);

        // Validar si el ticket existe
        if (ticket == null)
        {
            Console.WriteLine("El ticket no existe.");
            return;
        }

        // Validar si el ticket ya fue vendido
        if (ticket.Status == StatusTicket.Sold)
        {
            Console.WriteLine("El ticket ya ha sido vendido.");
            return;
        }

        // Actualizar el estado y asignar el ID del comprador
        ticket.Status = nuevoStatus;
        ticket.Comprador.Id =  compradorId.Value;

        Console.WriteLine($"El ticket con ID {ticket.Id} ahora tiene el estado {ticket.Status}.");
    }


    // Obtiene el listado de tickets desde un archivo de texto
    private List<Ticket> ObtenerTicketsDeArchivo()
    {
        var tickets = new List<Ticket>();

        // Verificar si el archivo existe antes de intentar leerlo
        if (File.Exists("tickets.txt"))
        {
            var lines = File.ReadAllLines("tickets.txt");

            // Leer cada línea y convertirla en un objeto Ticket
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    var ticket = new Ticket
                    {
                        Id = int.Parse(parts[0]),
                        NombreEvento = parts[1],
                        Status = Enum.Parse<StatusTicket>(parts[2]),
                        Precio = double.Parse(parts[3])
                    };
                    tickets.Add(ticket);
                }
            }
        }
        return tickets;
    } 
}
