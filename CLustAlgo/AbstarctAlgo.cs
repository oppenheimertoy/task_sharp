using System;
using System.Globalization;

namespace CLustAlgo;

abstract class AbstractAlgo
{
    private List<Point>? points;
    // вынести как пример на принцип единственной ответсвенности
    // public abstract void PrintToFile();
	public abstract void PrintToConsole();
    public List<Point>? GetPoints()
    {
        return this.points;
    }
}

class Wave : AbstractAlgo
{
    private List<Point> points;
    //private List<List<double>>? matrix; 
    private double eps;

    public Wave(List<Point> points, double eps)
    {
        this.points = points;
        this.eps = eps;
        //this.matrix = new List<List<double>>();
    }

    public override void PrintToConsole()
    {
        Console.WriteLine("rrfr");
    }
    public override void PrintToFile()
    {
        Console.WriteLine("rrfr");
    }

    public void FireNeighbours(int p_lable, int p_index)
    {
        if (this.points[p_index].GetLable() == 0)
        {
            this.points[p_index].SetClustFlag(p_lable);
            for(int i = 0; i < this.points.Count; i++)
            {
                if (this.points[p_lable].Distance(this.points[i]) < eps && this.points[i].GetLable() == 0)
                {
                    p_index = i;
                    FireNeighbours(p_lable, p_index);
                }
            }
        }
    }

    public void InitWave()
    {
        int c_lab = 1;
        int index = 0;
        for(int i = 0; i < this.points.Count; i++) {
            index = i;
            FireNeighbours(c_lab, index);
            c_lab++;
        }
        PrintToFile();
    }
    public bool CheckAllClusters()
    {
        int cnt = 0;
        for (int i = 0; i < this.points.Count; i++)
        {
            if (this.points[i].GetLable() == 0)
            {
                cnt++;
            }
        }
        if(cnt == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

class Hierarchical : AbstractAlgo
{
    private int num;
    private List<Point> points;
    private List<List<double>> matrix;

    public Hierarchical(List<Point> points, int num)
    {
        this.points = points;
        this.num = num;
        this.matrix = new List<List<double>>();
    }
    public override void PrintToConsole()
    {
        Console.WriteLine("rrfr");
    }
    public override void PrintToFile()
    {
        Console.WriteLine("rrfr");
    }
    public void HierInit()
    {
        int lable = 1;
        for(int i = 0; i < this.points.Count; ++i)
        {
            this.points[i].SetClustFlag(lable);
            lable++;
        }
    }

    public void FillMatrix()
    {
        for (int i = 0; i<= this.points.Count; ++i)
        {
            List<double> row = new List<double>();
            this.matrix.Add(row);
            for(int j = 0; j < this.points.Count; ++j)
            {
                this.matrix[i].Add(this.points[i].Distance(this.points[j]));
            }

        }
    }

    public int AmountOfClusters()
    {
        int cnt = 0;
        List<int> p_points = new List<int>();
        for (int i = 0; i < this.points.Count; ++i)
        {
            p_points.Add(this.points[i].GetLable());
        }
        p_points.Sort();
        p_points.Distinct().ToList();
        cnt = p_points.Count;
        return cnt;
    }

    public void DeleteClusters(int lable)
    {
        for(int i = 0; i < this.points.Count; ++i)
        {
            for(int j = 0; j < this.points.Count; ++j)
            {
                if (this.points[i].GetLable() == lable && this.points[j].GetLable() == lable)
                {
                    this.matrix[i][j] = -1;
                }
            }
        }
    }

    public void HierarchicalSearch()
    {
        FillMatrix();
        HierInit();
        int clusters = this.points.Count; 
        while(clusters < num){
            double min_d = 1000000;
            int minind_1 = 0, minind_2 = 0;
            for(int i = 0; i < this.points.Count; ++i)
            {
                for (int j = 0; j < this.points.Count; ++j)
                {
                    if ((this.matrix[i][j] < min_d) && (this.matrix[i][j] > 0))
                    {
                        min_d = this.matrix[i][j];
                        minind_1 = i;
                        minind_2 = j;
                    }
                }
            }
            int actlable = Math.Min(this.points[minind_1].GetLable(), this.points[minind_2].GetLable());
            int oldlable = Math.Max(this.points[minind_1].GetLable(), this.points[minind_2].GetLable());
            for (int i = 0; i < this.points.Count; ++i)
            {
                if (this.points[i].GetLable() == oldlable)
                {
                    this.points[i].SetClustFlag(actlable);
                }
            }
            DeleteClusters(actlable);
            clusters = AmountOfClusters();
        }
    }
}

