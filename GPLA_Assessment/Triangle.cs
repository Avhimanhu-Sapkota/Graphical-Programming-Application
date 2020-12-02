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
    class Triangle : Shape
    {
        /// <summary>
        /// Holds the integer value, which helps in creating vertices of triangle, which is obtained from parameter list.
        /// </summary>
        int tgPoint1, tgPoint2;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Triangle()
        {
        }

        /// <summary>
        /// Overrides the set method of Shape class<br/>
        /// Sets the Color, fill value, (x,y) of cursor, and other two verticies of the triangle. 
        /// </summary>
        /// <param name="newColor">Holds the Color of pen which draws the triangle</param>
        /// <param name="fill">Holds the boolean value of fill - which is true when fill is on or false otherwise</param>
        public override void set(Color penColor, bool fill, params int[] list)
        {
            base.set(penColor, fill, list[0], list[1]);
            // Refers the value of list[2] to the current object of the method.
            this.tgPoint1 = list[2];
            // Refers the value of list[2] to the current object of the method.
            this.tgPoint2 = list[3];
        }

        ///<summary>
        /// Overrides the draw method of Shape class <br/>
        /// Method: Triggered when triangle command is typed in the application<br/>
        /// Checks if the fill is on and fills the triangle and draws triangle from the current position of x and y coordinate.
        /// </summary>
        /// <param name="g">Object of <see cref="Graphics"/>. Helps to draw graphical contents in the displayCanvas pictureBox of the application.</param>
        public override void draw(Graphics g)
        {
            // Create the current point as the first vertex of the triangle.
            Point point1 = new Point(pointX, pointY);

            // Create the second vertex of the triangle with two coordinates
            Point point2 = new Point(pointX, tgPoint1);

            // Create the third vertex of the triangle with two coordinates
            Point point3 = new Point(tgPoint1, tgPoint2);

            // Creates array of point and stores all the verticies of triangle in the array which is required to draw a triangle in the displayCanvas.
            Point[] trianglePoints = {point1, point2, point3};

            // Object of Pen which accesses methods of Pen class.
            // Helps in drawing lines and shapes in the displayCanvas pictureBox of the application.
            Pen pen = new Pen(penColor, 1);

            /*
             * Checks if fill is on (true) and fills the triangle at the given point within the area of triangle.
             */
            if (fill == true)
            {
                // Object of SolidBrush which creates brush to fill the triangle
                SolidBrush brush = new SolidBrush(penColor);

                //Fills the triangle at the given point within the area of triangle.
                g.FillPolygon(brush, trianglePoints);
            }

            // Draws the triangle at the given point with the points in the point array: trianglePoints.
            g.DrawPolygon(pen, trianglePoints);
        }
    }
}