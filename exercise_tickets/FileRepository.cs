public class FileRepository : IFileRepository
{
    public string SaveFile(string fileName, string content)
    {
        try 
        {
            File.AppendAllText(fileName, content);
            return "Archivo guardado exitosamente.";
        }
        catch (Exception ex)
        {
            return $"Error al guardar el archivo: {ex.Message}";
        }
    }

    public string SaveFile (Vendedor vendedor)
    {
         // Crea una cadena que combina los datos del vendedor en formato CSV   
        var fila = $"{vendedor.Nombre}, {vendedor.Direccion}, {vendedor.Email}";

         File.AppendAllText("Vendedor_data.txt", fila);
            return "Archivo guardado exitosamente.";
    }
}