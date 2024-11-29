// Implementar metodo de guardado de archivo json en vez de .txt
// Con Serializacion y deserializacion

using System.Text.Json;
public class JsonFileRepository : IFileRepository
{
    private const string FileName = "vendedor_data.json"; 
    public string SaveFile(string fileName, string content)
    {
        try 
        {
            File.WriteAllText(fileName, content);
            return $"Archivo {fileName} guardado correctamente";
        }
        catch (Exception ex)
        {
            return $"Error al guardar el archivo: {ex.Message}";
        }
    }

    public string SaveFile(Vendedor vendedor)
    {
        try
        {
            List<Vendedor> vendedores;

            // Si el archivo ya existe, deserializamos su contenido
            if (File.Exists(FileName))
            {
                string existingContent = File.ReadAllText(FileName);
                vendedores = JsonSerializer.Deserialize<List<Vendedor>>(existingContent) ?? new List<Vendedor>();
            }
            else
            {
                // Si no existe, creamos una lista nueva
                vendedores = new List<Vendedor>();
            }

            // Agregamos el nuevo vendedor a la lista
            vendedores.Add(vendedor);

            // Serializamos la lista actualizada al archivo
            string jsonContent = JsonSerializer.Serialize(vendedores, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FileName, jsonContent);

            return $"Vendedor {vendedor.Nombre} guardado correctamente en {FileName}";

        }
        catch (Exception ex)
        {
            return $"Error al guardar el archivo: {ex.Message}";
        }

    }
}
