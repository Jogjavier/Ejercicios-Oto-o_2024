public class VendedorForms 
{
    private readonly Vendedor _vendedor;

    public Vendedor Vendedor { get { return _vendedor;}}

    public VendedorForms(Vendedor vendedor)
     {
        
        this._vendedor = vendedor;
     }

    public void CapturaDatosVendedor ()
    {
                

        Console.WriteLine("Nombre: ");

        _vendedor.Nombre = Console.ReadLine();

        Console.WriteLine("Direccion");

        _vendedor.Direccion = Console.ReadLine();

        Console.WriteLine("Email");

        _vendedor.Email = Console.ReadLine();
    }


 

}