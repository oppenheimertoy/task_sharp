using CLustAlgo;

class Program
{
    static void Main()
    {
        OvalCreator creator = new OvalCreator(500, 10.0, 5.0, 100.4, 4.6);
        Oval cloud = creator.CreateCLoud();
        cloud.Show();
    }
}