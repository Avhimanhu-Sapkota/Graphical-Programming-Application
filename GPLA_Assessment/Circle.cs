using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    /// <summary>
    /// Performs every tasks related to the graphical shape Triangle in the application window. 
    /// Extends <see cref="Shape"/> class.
    /// </summary>
    class Circle : Shape
    {
        /// <summary>
        /// Holds the integer value of radius of the circle which is obtained from parameter list.
        /// </summary>
        int radius;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Circle() 
        {
        }

        // 
        /// <summary>
        /// Overrides the set method of Shape class<br/>
        /// Sets the Color, fill value, (x,y) of cursor, and radius of the circle. 
        /// </summary>
        /// <param name="newColor">Holds the Color of pen which draws the circle</param>
        /// <param name="fill">Holds the boolean value of fill - which is true when fill is on or false otherwise</param>
        /// <param name="list">Holds the value of radius of the circle</param>
        public override void set(Color penColor, bool fill, params int[] list)
        {
            base.set(penColor, fill, list[0], list[1]);
            // Refers the value of list[2] to the current object of the method.
            this.radius = list [2];
        }

        ///<summary>
        /// Overrides the draw method of Shape class <br/>
        /// Method: Triggered when circle command along with radius is typed in the application<br/>
        /// Checks if the fill is on and fills the ellipse and draws ellipse with entered radius from the current position of x and y coordinate.
        /// </summary>
        /// <param name="g">Object of <see cref="Graphics"/>. Helps to draw graphical contents in the displayCanvas pictureBox of the application.</param>
        public override void draw(Graphics g)
        {
            // Object of Pen which accesses methods of Pen class.
            // Helps in drawing lines and shapes in the displayCanvas pictureBox of the application.
            Pen pen = new Pen(penColor, 1);

            /*
             * Checks if fill is on (true) and fills the ellipse at the given point within the circumference of ellipse.
             */
            if (fill == true)
            {
                // Object of SolidBrush which creates brush to fill the ellipse
                SolidBrush brush = new SolidBrush(penColor);

                // Fills the ellipse at the given point within the circumference of ellipse.
                g.FillEllipse(brush, pointX - radius, pointY - radius, radius*2, radius*2);
            }

            // Draws the ellipse at the given point with the entered radius 
            g.DrawEllipse(pen, pointX-radius, pointY-radius, radius*2, radius*2);
        }
    }
}
