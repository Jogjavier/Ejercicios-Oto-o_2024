public class CompradorForms
{
    private readonly Comprador _comprador;

    public Comprador Comprador { get { return _comprador;}}

    public CompradorForms(Comprador comprador)
     {
        
        this._comprador = comprador;
     }
    public void CapturaDatosComprador ()
    {
                
        Console.WriteLine("Nombre: ");

        _comprador.Nombre = Console.ReadLine();

        Console.WriteLine("Direccion");

        _comprador.Direccion = Console.ReadLine();

        Console.WriteLine("Email");

        _comprador.Email = Console.ReadLine();
    }
}
