public class TicketForms 
{
        static int id = 0;
    
    private readonly Vendedor _vendedor;
    private List<Ticket> _listaTickets {get;set;}

    public TicketForms(Vendedor vendedor)
    {
        this._vendedor = vendedor;
        this._listaTickets = GetTickets();
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

 

    public void MostrarBoletosDisponibles  () 
    { 

        foreach(var item in _listaTickets.Where(x=> x.Status == StatusTicket.OnSale))
        {
            Console.WriteLine($"Ticket id : {item.Id}");
            Console.WriteLine($"Nombre : {item.NombreEvento}");
            Console.WriteLine($"Precio : {item.Precio}");
            
        }
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
            }
         }
         else 
         {
            Console.WriteLine("Numero no valido");
         }
         
    }
}