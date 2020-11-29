using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    class Circle : Shape
    {
        int radius;
        Graphics g;

        public Circle() : base()
        {
            radius = 50;
        }

        public Circle (Color penColor, int pointX, int pointY, int radius): base(penColor, pointX, pointY)
        {
            this.radius = radius;
        }

        public override void set(Color penColor, params int[] list)
        {
            base.set(penColor, list[0], list[1]);
            this.radius = list [2];
        }

        public override void draw(Graphics g)
        {
            Pen pen = new Pen(penColor, 1);
            SolidBrush brush = new SolidBrush(penColor);
            g.FillEllipse(brush, pointX, pointY, radius * 2, radius * 2);
            g.DrawEllipse(pen, pointX, pointY, radius * 2, radius * 2);
        }
    }
}
