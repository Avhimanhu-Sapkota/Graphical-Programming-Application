using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA_Assessment
{
    /// <summary>
    /// Performs every tasks related to the graphical shape Polygon in the application window. 
    /// Extends <see cref="Shape"/> class.
    /// </summary>
    class Polygon : Shape
    {
        /// <summary>
        /// Holds the integer value of length of the rectangle which is obtained from parameter list.
        /// </summary>
        int length;
        /// <summary>
        /// Holds the integer value of breadth of the rectangle which is obtained from parameter list.
        /// </summary>
        int breadth;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Polygon()
        {
        }

        /// <summary>
        /// Overrides the set method of Shape class<br/>
        /// Sets the Color, fill value, (x,y) of cursor, and all the sides of the polygon
        /// </summary>
        /// <param name="newColor">Holds the Color of pen which draws the rectangle.</param>
        /// <param name="fill">Holds the boolean value of fill - which is true when fill is on or false otherwise</param>
        /// <param name="list"> Holds the list of value of sides of the polygon</param>
        public override void set(Color penColor, bool fill, params int[] list)
        {
            base.set(penColor, fill, list[0], list[1]);
            // Refers the value of list[2] to the current object of the method.
            this.length = list[2];
            // Refers the value of list[3] to the current object of the method.
            this.breadth = list[3];
        }

        ///<summary>
        /// Overrides the draw method of Shape class <br/>
        /// Method: Triggered when polygon command along with its points is typed in the application<br/>
        /// Checks if the fill is on and fills the polygon and draws polygon with entered sides from the current position of x and y coordinate.
        /// </summary>
        /// <param name="g">Object of <see cref="Graphics"/>. Helps to draw graphical contents in the displayCanvas pictureBox of the application.</param>
        public override void draw(Graphics g)
        {
            // Object of Pen which accesses methods of Pen class.
            // Helps in drawing lines and shapes in the displayCanvas pictureBox of the application.
            Pen pen = new Pen(penColor, 1);

            /*
             * Checks if fill is on (true) and fills the rectangle at the given point within the area of polygon.
             */
            if (fill == true)
            {
                // Object of SolidBrush which creates brush to fill the polygon
                SolidBrush brush = new SolidBrush(penColor);

                // Fills the rectangle at the given point within the area of polygon.
                g.FillRectangle(brush, pointX, pointY, length, breadth);
            }
            // Draws the polygon at the given point with the entered sides.
            g.DrawRectangle(pen, pointX, pointY, length, breadth);
        }
    }
}
