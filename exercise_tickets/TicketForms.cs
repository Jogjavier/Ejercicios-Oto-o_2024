using System.Security.Cryptography.X509Certificates;

public class TicketForms 
{
        static int id = 0;
    
    private readonly Vendedor _vendedor;
    private List<Ticket> _listaTickets {get;set;}

    public TicketForms(Vendedor vendedor)
    {
        this._vendedor = vendedor;
        this._listaTickets = new List<Ticket>();

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