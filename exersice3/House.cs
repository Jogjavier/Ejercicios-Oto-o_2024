public class House{
    private int area;
    public void ShowData()
    {
        Console.WriteLine("i'm house and my area is {0},i'm color and my color is {1}", area,color);
    }
    public House (int area,string color)
    {
        this.area =area;
        this.color=color;
    }
    private string color;
}