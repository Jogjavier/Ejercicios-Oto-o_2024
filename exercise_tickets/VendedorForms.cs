public class VendedorForms 
{
    // Campo privado que almacena la referencia al objeto Vendedor asociado
    private readonly Vendedor _vendedor;

    public Vendedor Vendedor 
    { 
        get { return _vendedor;}
    }

    public VendedorForms(Vendedor vendedor)
     {
        // Asigna el vendedor recibido
        this._vendedor = vendedor;
     }

    public void CapturaDatosVendedor()
    {
        Console.WriteLine("\nNombre: ");
        _vendedor.Nombre = Console.ReadLine();

        Console.WriteLine("Direccion");
        _vendedor.Direccion = Console.ReadLine();

        Console.WriteLine("Email");
        _vendedor.Email = Console.ReadLine();

        // Crea una cadena que combina los datos del vendedor en formato CSV   
        var fila = $"{_vendedor.Nombre}, {_vendedor.Direccion}, {_vendedor.Email}";

        // Agrega la cadena en formato csv al archivo
        File.AppendAllText("vendedor_data.txt", fila + Environment.NewLine);

    }
}
