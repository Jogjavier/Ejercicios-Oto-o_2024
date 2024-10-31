
// Crear un programa para reventa de boletos de eventos, donde un Usuario vendedor puede poner a la venta boletos y otro Usuario comprador, los puede elegir y pagar. +
//Hacer el modelado de los objetos que podrian ser utilizados


/* Si el usuario es comprador, mostrar la lista de todos los boletos disponibles */

/* Crear un metodo que, reciba como parametro el id del boleto y cambie el status a vendido y muestre los boletos comprados por el usuario
comprador */

/* Crear un metodo para guardar la informacion de los tickets para vender */


/* Obtener el listado de tickets disponibles desde este archivo cuando un comprador pregunte por ellos */

using exercise_tickets;

Console.WriteLine("Ingresar datos del usuario");



Console.WriteLine(" Compras o vendes boletos (V/C)");

var input = Console.ReadKey().KeyChar;

Usuario usuario;

if(input == 'V')
{ 
    usuario = new Vendedor();
    VendedorForms forms = new VendedorForms((Vendedor)usuario);
    forms.CapturaDatosVendedor();


}
else if (input == 'C')
{

    usuario = new Comprador();
    TicketForms ticketForms = new TicketForms(new Vendedor());
    ticketForms.MostrarBoletosDisponibles();
    Console.ReadKey();
    
    CompradorForms compradorForms = new CompradorForms((Comprador)usuario);
    Console.WriteLine("Ingresa el id del ticket que quieres comprar?");
    string strTicket = Console.ReadLine();
    int idTicket = Int32.Parse(strTicket);
    
    compradorForms.ComprarBoleto(idTicket, ticketForms._listaTickets);
     
}
else 
    return;

    



if( usuario.GetType() == typeof(Vendedor))
{
    TicketForms ticketForms = new TicketForms((Vendedor)usuario);
    Console.WriteLine("Quieres dar de alta un boleto o quieres vender? (A/V)");
    var input2 = Console.ReadKey().KeyChar;

    if(input2 == 'A')
    {
        ticketForms.CapturarNuevoTicket();
        ticketForms.MostrarBoletosDisponibles();
    }

}


