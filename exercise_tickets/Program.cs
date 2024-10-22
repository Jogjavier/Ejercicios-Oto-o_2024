
// Crear un programa para reventa de boletos de eventos, donde un Usuario vendedor puede poner a la venta boletos y otro Usuario comprador, los puede elegir y pagar. +
//Hacer el modelado de los objetos que podrian ser utilizados


Console.WriteLine("Ingresar datos del usuario");



Console.WriteLine(" Compras o vendes boletos (V/C)");

var input = Console.ReadKey().KeyChar;

Usuario usuario;

if(input == 'V')
    usuario = new Vendedor();
else if (input == 'C')
    usuario = new Comprador();
else 
    return;

Console.WriteLine("Nombre: ");

usuario.Nombre = Console.ReadLine();

Console.WriteLine("Direccion");

usuario.Direccion = Console.ReadLine();

Console.WriteLine("Email");

usuario.Email = Console.ReadLine();



if( usuario.GetType() == typeof(Vendedor))
{
    Console.WriteLine("Quieres dar de alta un boleto o quieres vender? (A/V)");
    var input2 = Console.ReadKey().KeyChar;

    if(input2 == 'A')
    {
        ((Vendedor)usuario).CapturarNuevoTicket();
        ((Vendedor)usuario).MostrarBoletosDisponibles();
    }

}


