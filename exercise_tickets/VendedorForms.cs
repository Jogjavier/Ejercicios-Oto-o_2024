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
        
        var fila = _vendedor.Nombre + "," + _vendedor.Direccion + "," + _vendedor.Email;
        List<string> lista = new List<string>();
        lista.Add(fila);
        
        File.WriteAllLines("archivot.txt",lista);
        File.WriteAllText("archivot.txt", fila);

        var filesreaded = File.ReadAllLines("archivot.txt");
    }


 

}