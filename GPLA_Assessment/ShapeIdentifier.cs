using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    class ShapeIdentifier
    {
        public Shape getShape(String shapeType)
        {
            shapeType = shapeType.Trim().ToLower();

            if (shapeType.Equals("rectangle"))
            {
                return new Rectangle();
            }

            else if (shapeType.Equals("circle"))
            {
                return new Circle();
            }

            else if (shapeType.Equals("triangle"))
            {
                return new Triangle();
            }
            else
            {
                System.ArgumentException argExpression = new System.ArgumentException("Identification Error: " + shapeType + "is not accepted as shape. Please Try Again!!!");
                throw argExpression;
            }
        }
    }
}
