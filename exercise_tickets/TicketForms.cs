public class TicketForms 
{   
    
    // Variable estática para generar identificadores únicos para los tickets
    static int id = 0;
    
    // Referencia al vendedor asociado a este formulario
    private readonly Vendedor _vendedor;
    
    private readonly TicketRepository _repository;

    
    // Lista de tickets disponibles para el vendedor
    public List<Ticket> _listaTickets {get;set;}

    // Constructor: Inicializa el formulario con un vendedor y obtiene la lista inicial de tickets
    public TicketForms(Vendedor vendedor, TicketRepository repository)
    {
        this._vendedor = vendedor;
        //this._listaTickets = GetTickets(); 
        this._repository = repository; 
        this._listaTickets = _repository.GetTickets();    
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
