using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    class Rectangle : Shape
    {
        int length, breadth;
        public Rectangle() : base()
        {
            length = 100;
            breadth = 100;
        }

        public Rectangle(Color penColor, int pointX, int pointY, int length, int breadth):base(penColor, pointX, pointY)
        {
            this.length = length;
            this.breadth = breadth;
        }

        public override void set(Color penColor, params int[] list)
        {
            base.set(penColor, list[0], list[1]);
            this.length = list[2];
            this.breadth = list[3];
        }

        public override void draw (Graphics g)
        {
            Pen pen = new Pen(penColor, 1);
            SolidBrush brush = new SolidBrush(penColor);
            g.FillRectangle(brush, pointX, pointY, length, breadth);
            g.DrawRectangle(pen, pointX, pointY, length, breadth);
        }
    }
}
