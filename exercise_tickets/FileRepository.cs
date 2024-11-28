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
}