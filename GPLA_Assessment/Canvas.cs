using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    public class Canvas
    {

        Graphics g;
        Pen pen;
        int pointX, pointY;

        public Canvas(Graphics g)
        {
            this.g = g;
            pointX = 0;
            pointX = 0;

            pen = new Pen(Color.Black, 1);
        }

        public void DrawLine(int x_coordinate, int y_coordinate)
        {
            g.DrawLine(pen, pointX, pointY, x_coordinate, y_coordinate);
            pointX = x_coordinate;
            pointY = y_coordinate;
        }


    }
}
