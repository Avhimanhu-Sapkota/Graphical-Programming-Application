using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    abstract class Shape
    {
        protected Color penColor;
        protected int pointX, pointY;

        public Shape()
        {
            
        }

        public Shape (Color penColor, int pointX, int pointY)
        {
            this.penColor = penColor;
            this.pointX = pointX;
            this.pointY = pointY;
        }

        public abstract void draw(Graphics g);

        public virtual void set(Color penColor, params int[] list)
        {
            this.penColor = penColor;
            this.pointX = list[0];
            this.pointY = list[1];
        }

        public override string ToString()
        {
            return base.ToString()+"   "+this.pointX+""+this.pointY+" : ";
        }
    }
}
