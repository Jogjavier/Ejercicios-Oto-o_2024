public class Vendedor: Usuario
{
 
    private List<int> listaTickets {get;set;}
    public List<int> MostrarBoletosDisponibles  () => listaTickets;


}