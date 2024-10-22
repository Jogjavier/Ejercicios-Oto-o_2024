public class Vendedor: Usuario
{
 
    static int id = 0;
    private List<Ticket> listaTickets {get;set;}

    public Vendedor()
     {
        listaTickets = new List<Ticket>();
     }
    public void MostrarBoletosDisponibles  () 
    { 

        foreach(var item in listaTickets)
        {
            Console.WriteLine($"Evento : {item.Id}");
            Console.WriteLine($" Nombre : {item.NombreEvento}");
            Console.WriteLine($"Precio : {item.Precio}");
        }
    } 


    public void CapturarNuevoTicket()
    { 
        Ticket ticket = new Ticket();
        Console.WriteLine("Evento del boleto");
        ticket.NombreEvento = Console.ReadLine();
        Console.WriteLine("Precio del boleto");
        string strprecio = Console.ReadLine();
         if(double.TryParse( strprecio, out double precio))
         {
            ticket.Precio = precio;
         }
         id++;
         ticket.Id = id;

         listaTickets.Add(ticket);


    }

    
 
}