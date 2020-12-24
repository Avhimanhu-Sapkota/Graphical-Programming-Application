using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA_Assessment
{
    /// <summary>
    /// Implements a method which creates and returns the object of the shape being based on the command entered as parameter. 
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// Method: Triggered when the object of Rectangle/Triangle/Circle class is required. 
        /// Creates object of Rectangle/Triangle/Circle class if the parameter passed matches the Shape name. 
        /// </summary>
        /// <param name="shapeType">Holds the name of shape of which object is to be created.</param>
        /// <returns> The object of particular shape which was passed as a parameter. </returns>
        public Shape getShape(String shapeType)
        {
            // Trims the spaces before and after the text and changes the alphabets to lowercase. 
            shapeType = shapeType.Trim().ToLower();

            /*
             * Checks the string to different shape names. Returns their object if ture. 
             */
            if (shapeType.Equals("rectangle"))
            {
                // Creates an object of Rectangle class and returns it as the string in the parameter was 'rectangle'
                return new Rectangle();
            }

            else if (shapeType.Equals("circle"))
            {
                // Creates an object of Circle class and returns it as the string in the parameter was 'circle'
                return new Circle();
            }

            else if (shapeType.Equals("triangle"))
            {
                // Creates an object of Triangle class and returns it as the string in the parameter was 'Triangle'
                return new Triangle();
            }
            else if (shapeType.Equals("polygon"))
            {
                // Creates an object of Triangle class and returns it as the string in the parameter was 'Triangle'
                return new Polygon();
            }
            else
            {
                // Throws error if the string in parameter is not matched with any of the shapes
                System.ArgumentException argExpression = new System.ArgumentException("Identification Error: " + shapeType + "is not accepted as shape. Please Try Again!!!");
                throw argExpression;
            }
        }
    }
}
