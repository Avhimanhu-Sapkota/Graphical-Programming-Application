using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    class Triangle : Shape
    {
        int tgPoint1;
        int tgPoint2;

        public Triangle()
        {
        }

        public Triangle(Color penColor, int pointX, int pointY, int tgPoint1, int tgPoint2):base(penColor, pointX, pointY)
        {
            this.tgPoint1 = pointX + 12;
            this.tgPoint2 = pointY + 18;
        }

        public override void set(Color penColor, params int[] list)
        {
            base.set(penColor, list[0], list[1]);
            this.tgPoint1 = list[2];
            this.tgPoint2 = list[3];
        }

        public override void draw(Graphics g)
        {
            Point point1 = new Point(pointX, pointY);
            Point point2 = new Point(pointX, tgPoint1);
            Point point3 = new Point(tgPoint1, tgPoint2);
            Point[] trianglePoints = { point1, point2, point3 };

            Pen pen = new Pen(penColor, 1);
            SolidBrush brush = new SolidBrush(penColor);
            g.FillPolygon(brush, trianglePoints);
            g.DrawPolygon(pen, trianglePoints);
        }
    }
}
