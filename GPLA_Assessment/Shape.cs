using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    /// <summary>
    /// Receives values of shapes, then sets color, fill, and other parameters of that particular shape then<br/> calls a method which helps to draw that particular shape.
    /// </summary>
    abstract class Shape
    {
        /// <summary>
        /// Stores the name of <see cref="Color"/> which will be used in pen to draw objects of different colors.
        /// </summary>
        protected Color penColor;

        /// <summary>
        /// Stores boolean values:<br/>
        /// True when fill has been set to 'on' via programWindow/commandLineWindow, which helps in fill the objects to be drawn with the particular color of the pen.<br/>
        /// False when fill has been set to 'off'
        /// </summary>
        protected bool fill;

        /// <summary>
        /// Stores the integer value of  y-coordinate of the displayCanvas PictureBox of the application
        /// </summary>
        protected int pointX;

        /// <summary>
        /// Stores the integer value of  y-coordinate of the displayCanvas PictureBox of the application
        /// </summary>
        protected int pointY;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Shape()
        {
            
        }

        /// <summary>
        /// Method: Triggered when shape command (rectangle, circle, triangle), along with parameters, is typed in the application <br/>
        /// Refers the value of parameters to the current object of the method
        /// </summary>
        /// <param name="penColor">Holds the Color of pen which draws the rectangle.</param>
        /// <param name="fill">Holds the boolean value of fill - which is true when fill is on or false otherwise</param>
        /// <param name="pointX">Holds the value for x-coordinate</param>
        /// <param name="pointY">Holds the value for y-coordinate</param>
        public Shape (Color penColor, bool fill, int pointX, int pointY)
        {
            // Refers the value of 'penColor' to the current object of the method.
            this.penColor = penColor;

            // Refers the value of 'fill' to the current object of the method.
            this.fill = fill;

            // Refers the value of 'pointX' to the current object of the method.
            this.pointX = pointX;

            // Refers the value of 'pointY' to the current object of the method.
            this.pointY = pointY;
        }

        /// <summary>
        /// Method: Triggered when shape command along with parameters is typed in the application<br/>
        /// Passes the obligation to implement them to the derieved classes by declaring them as abstract
        /// </summary>
        /// <param name="g">Object of <see cref="Graphics"/>. Helps to draw graphical contents in the displayCanvas pictureBox of the application.</param>
        public abstract void draw(Graphics g);

        /// <summary>
        /// Sets the penColor, fill and list of parameters and refers their to the current object of the method
        /// </summary>
        /// <param name="penColor">Holds the Color of pen which draws the rectangle.</param>
        /// <param name="fill">Holds the boolean value of fill - which is true when fill is on or false otherwise</param>
        /// <param name="list">Holds verticies/ radius/ length,breath to be set for the shape. It has values in accordance to the shape </param>
        public virtual void set(Color penColor, bool fill, params int[] list)
        {
            // Refers the value of 'penColor' to the current object of the method.
            this.penColor = penColor;

            // Refers the value of 'fill' to the current object of the method.
            this.fill = fill;

            // Refers the value of params's list[0] to the current 'pointX' object of the method.
            this.pointX = list[0];

            // Refers the value of params's list[1] to the current 'pointX' object of the method.
            this.pointY = list[1];
        }
    }
}
