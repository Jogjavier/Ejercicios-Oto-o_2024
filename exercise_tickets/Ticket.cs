public class Ticket 
{
    public int Id {get;set;}

    public string NombreEvento {get;set;}
    public StatusTicket Status { get;set;}

    public double Precio {get;set;}
    
    public Usuario? Vendedor {get;set;}
    public Usuario? Comprador {get;set;}
    

}