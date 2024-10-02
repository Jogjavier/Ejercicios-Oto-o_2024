public class Rectangule
{
    private int _rec;

    public double GetNextValue()
    {
        // Definir los valores del ancho y alto del rectángulo
        double ancho = 5.0; // Puedes cambiar este valor
        double alto = 10.0; // Puedes cambiar este valor

        // Calcular el perímetro
        double perimetro = 2 * (ancho + alto);

        // Calcular el área
        double area = ancho * alto;

        // Calcular la diagonal usando el teorema de Pitágoras
        double diagonal = Math.Sqrt(Math.Pow(ancho, 2) + Math.Pow(alto, 2));

        // Mostrar los resultados
        Console.WriteLine($"Perímetro: {perimetro}");
        Console.WriteLine($"Área: {area}");
        Console.WriteLine($"Diagonal: {diagonal}");

        return perimetro;
    }
}
