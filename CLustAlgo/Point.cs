namespace CLustAlgo;

public class Point
{
    private double X;
    private double Y;
    private int с_flag;

    public Point()
    {
        X = 0;
        Y = 0;
        с_flag = 0;
    }
    public Point(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }
    public Point(double x, double y, int clust_flag) : this(x, y) { 
        this.с_flag = clust_flag;
    }

    public Point(Point source_point)
    {
        this.X = source_point.X;
        this.Y = source_point.Y;
        this.с_flag = source_point.с_flag;
    }

    // setter block
    public void SetClustFlag(int clust_flag) {
        this.с_flag = clust_flag;
    }
    public void SetAccure(double pog1, double pog2)
    {
        this.X += pog1;
        this.Y += pog2;
    }

    public void SetAccureX(double pog1)
    {
        this.X += pog1;
    }

    public void SetAccureY(double pog2)
    {
        this.Y += pog2;
    }
    // getters block 
    public double GetDistanceZero()
    {
        return Math.Sqrt(X + Y);
    }
    public int GetLable()
    {
        return this.с_flag;
    }
    public double GetXCord()
    {
        return this.X;
    }
    public double GetYCord()
    {
        return this.Y;
    }
    public Tuple<double, double> GetCoord()
    {
        return new Tuple<double, double>(this.X, this.Y);
    }

    public double Distance(Point point)
    {
        return (Math.Sqrt(((X - point.X) * (X - point.X)) + ((Y - point.Y) * (Y - point.Y))));
    } 

}
