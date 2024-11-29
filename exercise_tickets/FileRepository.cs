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
    public string SaveJsonInFile<T>(string fileName, T obj)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText(fileName, jsonString);
            return "Archivo JSON guardado exitosamente.";
        }
        catch (Exception ex)
        {
            return $"Error al guardar el archivo JSON: {ex.Message}";
        }
    }
}
