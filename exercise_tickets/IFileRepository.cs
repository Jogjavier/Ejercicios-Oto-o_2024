// Crear una clase que implemente el repositorio IFile repository, que serialize el dato del vendedor y lo guarde en el archivo

public interface IFileRepository
{ 
    public string SaveFile (string fileName, string Content);
}