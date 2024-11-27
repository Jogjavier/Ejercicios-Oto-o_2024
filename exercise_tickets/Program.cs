// JAvier
// Mover metodos de carga, guardado y modificacion de status de tickets, moverlo a una clase TicketRepository,
// esta clase tendra los metodos GetTickets,  CambiarEstatusTicket, GuardarTicket 
// Todos estos metodos escribiran y leeran sobre un archivo de texto serializando los datos. 


// Alvaro
// Modificar Vendedor Forms para que los datos se guarden serializados en el archivo. Listo
// Modificar Comprador para que solo quede como DTO. Listo
// Agregar metodos para pedir y guardar los datos del comprador


using exercise_tickets;

Console.WriteLine("Ingresar datos del usuario");

Console.WriteLine("¿Compras o vendes boletos (V/C)?:");

var input = Console.ReadKey().KeyChar;

Usuario usuario;

if (input == 'V')
{ 
    usuario = new Vendedor();

    // Crea una instancia de FileRepository
    IFileRepository fileRepository = new FileRepository();

    // Pasa la instancia de FileRepository al formulario
    VendedorForms forms = new VendedorForms( (Vendedor)usuario, fileRepository);

    // Llamamos al método que captura los datos del vendedor
    forms.CapturaDatosVendedor();
}
else if (input == 'C')
{
    usuario = new Comprador();
    // Creamos un formulario para capturar datos del comprador
    CompradorForms forms = new CompradorForms((Comprador)usuario);
    // Llamamos al método que captura los datos del comprador
    forms.CapturaDatosComprador();


    // Creamos un formulario de tickets con un vendedor
    TicketForms ticketForms = new TicketForms(new Vendedor());
    // Mostramos los boletos disponibles en el sistema
    ticketForms.MostrarBoletosDisponibles();
    Console.ReadKey();
    
    // Creamos un formulario de comprador asociado al usuario comprador 
    CompradorForms compradorForms = new CompradorForms((Comprador)usuario);
    Console.WriteLine("Ingresa el id del ticket que quieres comprar?");
    string strTicket = Console.ReadLine();
    int idTicket = Int32.Parse(strTicket);
    
    // Llamamos al método para realizar la compra del boleto, pasando el ID y la lista de tickets
    compradorForms.ComprarBoleto(idTicket, ticketForms._listaTickets);
    // Guardamos los boletos comprados por el usuario
    compradorForms.GuardarTicketsComprados();
}
else 
    return;

if( usuario.GetType() == typeof(Vendedor))
{
    // Creamos un formulario de tickets asociado al usuario vendedor
    TicketForms ticketForms = new TicketForms((Vendedor)usuario);
    Console.WriteLine("¿Quieres dar de alta un boleto o quieres vender? (A/V)?:");
    var input2 = Console.ReadKey().KeyChar;

    if(input2 == 'A')
    {
        // Llamamos al método para capturar los datos de un nuevo ticket
        ticketForms.CapturarNuevoTicket();
        // Mostramos la lista de boletos disponibles después de dar de alta
        ticketForms.MostrarBoletosDisponibles();
    }
}

