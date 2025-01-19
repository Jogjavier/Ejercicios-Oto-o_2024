public class LugarEventos
{
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public string Localidad { get; set; }
    public string Colonia { get; set; }
    public string Numero { get; set; }
    public int CapacidadMaxima { get; set; }
    public bool TieneEstacionamiento { get; set; }

    // Lista estática para almacenar todos los lugares
    private static List<LugarEventos> Lugares = new List<LugarEventos>();

    public LugarEventos(string direccion, string ciudad, string localidad, string colonia, string numero, int capacidadMaxima, bool tieneEstacionamiento)
    {
        Direccion = direccion;
        Ciudad = ciudad;
        Localidad = localidad;
        Colonia = colonia;
        Numero = numero;
        CapacidadMaxima = capacidadMaxima;
        TieneEstacionamiento = tieneEstacionamiento;
    }
    
    // Método para registrar un nuevo lugar si no existe
    public static void RegistrarLugar(LugarEventos lugar)
    {
        // Verificar si el lugar ya existe basado en la dirección
        if (!Lugares.Exists(l => l.Direccion.Equals(lugar.Direccion, StringComparison.OrdinalIgnoreCase)))
        {
            Lugares.Add(lugar);
            Console.WriteLine("Lugar registrado exitosamente.");
        }
        else
        {
            Console.WriteLine("El lugar ya está registrado.");
        }
    }

    // Método para mostrar todos los lugares registrados
    public static void MostrarLugares()
    {
        Console.WriteLine("\nLugares registrados:");
        foreach (var lugar in Lugares)
        {
            Console.WriteLine($"- Dirección: {lugar.Direccion}, Ciudad: {lugar.Ciudad}, Localidad: {lugar.Localidad}, Colonia: {lugar.Colonia}, Número: {lugar.Numero}");
            Console.WriteLine($"  Capacidad Máxima: {lugar.CapacidadMaxima}, Estacionamiento: {(lugar.TieneEstacionamiento ? "Sí" : "No")}");
        }
    }
}