using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLustAlgo;

// Facade pattern
class Search
{
    private List<Point> points;
    private int p_num;
    private double p_eps;
    private int minpts;
    private Wave _subsyst_1;
    private Hierarchical _subsyst_2;

    public Search(List<Point> points, int num, double eps, int minpts)
    {
        this.points = points;
        this.p_num = num;
        this.p_eps = eps;
        this.minpts = minpts;
        this._subsyst_1 = new Wave();
        this._subsyst_2 = new Hierarchical();
    }
    public void SHierarchical()
    {
        this._subsyst_2 = new Hierarchical(this.points, this.p_num);
        this._subsyst_2.HierarchicalSearch();
        //search.PrintToFile_H();
    }

    public void SWave()
    {
        this._subsyst_1 = new Wave(this.points, this.p_eps);
        this._subsyst_1.InitWave();
        // print to file
    }
    public void ChangeNum(int c_num)
    {
        this.p_num = c_num;
    }

    public void ChangeEps(double c_eps)
    {
        this.p_eps = c_eps;
    }

    public void ChangeMinpts(int c_Minpts)
    {
        this.minpts = c_Minpts;
    }
}
