public class VendedorForms 
{
    // Campo privado que almacena la referencia al objeto Vendedor asociado
    private readonly Vendedor _vendedor;

    private readonly IFileRepository _fileRepository;
    public Vendedor Vendedor 
    { 
        get { return _vendedor;}
    }

    public VendedorForms(Vendedor vendedor, IFileRepository _fileRepository)
     {
        // Asigna el vendedor recibido
        this._vendedor = vendedor;
        this._fileRepository = _fileRepository;
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

        _fileRepository.SaveFile("vendedor_data.txt", fila + Environment.NewLine  );
        // Agrega la cadena en formato csv al archivo         

    }
}
