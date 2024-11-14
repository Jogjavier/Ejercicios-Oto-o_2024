public class TicketForms 
{
        static int id = 0;
    
    private readonly Vendedor _vendedor;
    public List<Ticket> _listaTickets {get;set;}

    public TicketForms(Vendedor vendedor)
    {
        this._vendedor = vendedor;
        this._listaTickets = GetTickets();

    }
    

 

    public void MostrarBoletosDisponibles  () 
    { 

        foreach(var item in _listaTickets.Where(x=> x.Status == StatusTicket.OnSale))
        {
            Console.WriteLine($"Ticket id : {item.Id}");
            Console.WriteLine($"Nombre : {item.NombreEvento}");
            Console.WriteLine($"Precio : {item.Precio}");
            
        }
    }
    
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


    public void CapturarNuevoTicket()
    { 

        Console.WriteLine("Evento del boleto");
        var NombreEvento = Console.ReadLine();
        Console.WriteLine("Precio del boleto");
        string strprecio = Console.ReadLine();
         if(!double.TryParse( strprecio, out double precio))
         {
            Console.WriteLine("Precio no valido");
         }

        Console.WriteLine("Cuantos boletos tienes disponibles?");
         string strTicketDisp = Console.ReadLine();
       
         if(int.TryParse(strTicketDisp, out int ticketsDisp))
         {
            for (int x=0; x<ticketsDisp;x++ )
            {
                id++;
                Ticket ticket = new Ticket();
                ticket.Id = id;
                ticket.Precio = precio;
                ticket.NombreEvento = NombreEvento;
                ticket.Status = StatusTicket.OnSale;
                _listaTickets.Add(ticket);
                GuardarTicketEnArchivo(ticket);
            }
         }
         else 
         {
            Console.WriteLine("Numero no valido");
        }
    }

    /* Crear un método para guardar la información de los tickets para vender y cada archivo de tickets deberá llamarse con el id del vendedor - Osvaldo */ 
    private void GuardarTicketEnArchivo(Ticket ticket)
    {
    
    }

    /* Obtener el listado de tickets disponibles desde este archivo cuando un comprador pregunte por ellos - Álvaro */ 
    private List<Ticket> ObtenerTicketsDeArchivo()
    {
        var tickets = new List<Ticket>();

        if (File.Exists("tickets.txt"))
        {
            var lines = File.ReadAllLines("tickets.txt");
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

    /* Crear un metodo para guardar la informacion de los tickets comprados y cada archivo de tickets debera llamarse con el id del vendedor - Itzel o Javier */

    

}