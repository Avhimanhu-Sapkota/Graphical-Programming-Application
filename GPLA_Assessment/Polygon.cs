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
        /// Integer array which holds the list of parameters containing points of the polygon
        /// </summary>
        int[] parameters;

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

            // Sets the parameters values from list into the array.
            parameters = list;
        }

        ///<summary>
        /// Overrides the draw method of Shape class <br/>
        /// Method: Triggered when polygon command along with its points is typed in the application<br/>
        /// Checks if the fill is on and fills the polygon and draws polygon with entered sides from the current position of x and y coordinate.
        /// </summary>
        /// <param name="g">Object of <see cref="Graphics"/>. Helps to draw graphical contents in the displayCanvas pictureBox of the application.</param>
        public override void draw(Graphics g)
        {
            // Creates array of point and stores all the verticies of triangle in the array which is required to draw a triangle in the displayCanvas.
            Point[] polygonPoints = new Point[parameters.Length/2];

            // Integer index counter.
            int index = 0;

            // Iterates the loop to add new point into polygonpoints array.
            for (int i=0; i<parameters.Length; i += 2)
            {
                // Sets the points of polygon into polygon points.
                polygonPoints[index] = new Point(parameters[i], parameters[i + 1]);
                index++;
            }

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
                g.FillPolygon(brush, polygonPoints);
            }

            // Draws the triangle at the given point with the points in the point array: trianglePoints.
            g.DrawPolygon(pen, polygonPoints);
        }
    }
}
