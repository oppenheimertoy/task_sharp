using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CLustAlgo;

abstract class AbstractCreator
{
    public abstract AbstractCloud CreateCLoud();
}

abstract class AbstractCloud 
{
    protected const double pi = 3.141592653589793;

    public abstract void RotateCenter(double phix);
    public abstract void RotateDecartCenter();
    public abstract void MoveX();
    public abstract void MoveY();
}

class OvalCreator : AbstractCreator
{
    private int amount;
    private double xc;
    private double yc;
    private double dspx;
    private double dspy;

    public OvalCreator(int aparam, double xparam, double yparam, double dxparam, double dyparam)
    {
        this.amount = aparam;
        this.xc = xparam;
        this.yc = yparam;   
        this.dspx = dxparam;
        this.dspy = dyparam;
    }
    public override Oval CreateCLoud()
    {
         return new Oval(this.amount, this.xc, this.yc, this.dspx, this.dspy);
    }
}

class Oval : AbstractCloud
{
    private List<Point> points;
    private int amount_of_points;
    private double xc;
    private double yc;
    private double dspx;
    private double dspy;

    public Oval(int aparam, double xparam, double yparam, double dxparam, double dyparam)
    {
        this.amount_of_points = aparam;
        this.xc = xparam;
        this.yc = yparam;
        this.dspx = dxparam;
        this.dspy = dyparam;
        this.points = new List<Point>();

        double sumx = 0, sumy = 0, accurx = 0, accury = 0, xpog = 0, ypog = 0;
        if (this.amount_of_points > 0)
        {
            Random rand = new Random();
            for (int i = 0; i < this.amount_of_points; ++i)
            {
                for (int j = 0; j < 1001; ++j)
                {
                    sumx += (rand.Next(1000) % 10001 - 5000) * 0.0001;
                    sumy += (rand.Next(1000) % 10001 - 5000) * 0.0001;
                }
                this.points.Add(new Point(this.xc + this.dspx * sumx / 1001, this.yc + this.dspy * sumy / 1001));
                sumx = sumy = 0;
                accurx += this.points[i].GetXCord();
                accury += this.points[i].GetYCord();
            }
            accurx = accurx / this.amount_of_points;
            accury = accury / this.amount_of_points;
            xpog = this.xc - accurx;
            ypog = this.yc - accury;
            for (int i = 0; i < this.amount_of_points; ++i)
            {
                this.points[i].SetAccure(xpog, ypog);
            }
        }
    }
    public void Show()
    {
        for (int i = 0; i < this.points.Count; ++i)
        {
            Console.WriteLine($" {this.points[i].GetXCord()}  {this.points[i].GetYCord()} {this.points[i].GetLable()}");
        }
    }
    public override void RotateCenter(double phix)
    {
        phix = phix * (180 / pi);
        double x1, y1, x2, y2;
        for (int i = 0; i < this.points.Count; ++i)
        {
            x1 = this.points[i].GetXCord();
            y1 = this.points[i].GetYCord();
            x2 = ((x1 - this.xc) * Math.Cos(phix)) + ((y1 - this.yc) * Math.Sin(phix)) + this.xc;
            y2 = ((x1 - this.xc) * Math.Sin(phix)) - ((y1 - this.yc) * Math.Cos(phix)) + this.yc;
            this.points[i] = new Point(x2, y2);
        }
    }
    public override void RotateDecartCenter()
    {

    }
    public override void MoveX()
    {

    }
    public override void MoveY()
    {

    }
}
