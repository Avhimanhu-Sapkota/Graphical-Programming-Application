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

        public Circle() : base()
        {
        }

        public Circle (Color penColor, bool fill, int pointX, int pointY, int radius): base(penColor, fill,  pointX, pointY)
        {
            this.radius = radius;
        }

        public override void set(Color penColor, bool fill, params int[] list)
        {
            base.set(penColor, fill, list[0], list[1]);
            this.radius = list [2];
        }

        public override void draw(Graphics g)
        {
            Pen pen = new Pen(penColor, 1);
            if (fill == true)
            {
                SolidBrush brush = new SolidBrush(penColor);
                g.FillEllipse(brush, pointX, pointY, radius*2, radius*2);
            }
            g.DrawEllipse(pen, pointX, pointY, radius*2, radius*2);
        }
    }
}
