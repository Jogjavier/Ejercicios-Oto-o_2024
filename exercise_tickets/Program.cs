

// JAvier
// Mover metodos de carga, guardado y modificacion de status de tickets, moverlo a una clase TicketRepository,
// esta clase tendra los metodos GetTickets,  CambiarEstatusTicket, GuardarTicket 
// Todos estos metodos escribiran y leeran sobre un archivo de texto serializando los datos. 


// Alvaro
// Modificar Vendedor Forms para que los datos se guarden serializados en el archivo. 
// Modificar Comprador para que solo quede como DTO, 
// Agregar metodos para pedir y guardar los datos del comprador


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
    compradorForms.GuardarTicketsComprados();

    
     
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


