using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    public class Canvas
    {

        Graphics g;
        Pen pen = new Pen(Color.Black, 1);
        int pointX, pointY;

        Shape newShape;
        ShapeIdentifier identiferObject = new ShapeIdentifier();
        public bool fill;
        public Color penColor;

        public Canvas(Graphics g)
        {
            this.g = g;
            pointX = 0;
            pointX = 0;
            penColor = Color.Black;
            fill = false;
        }

        public void ClearScreen()
        {
            g.Clear(Color.White);
        }

        public void MoveTo(int x_coordinate, int y_coordinate)
        {
            pointX = x_coordinate;
            pointY = y_coordinate;
        }

        public void ResetPen()
        {
            pen.Color = Color.Black;
            pointX = 0;
            pointY = 0;
        }

        public void DrawLine(Color newColor, int x_coordinate, int y_coordinate)
        {
            pen.Color = newColor;
            g.DrawLine(pen, pointX, pointY, x_coordinate, y_coordinate);
            pointX = x_coordinate;
            pointY = y_coordinate;
        }

        public void DrawRectangle(Color newColor, bool fill, int length, int breadth)
        {
            newShape = identiferObject.getShape("rectangle");
            newShape.set(newColor, fill, pointX, pointY, length, breadth);
            newShape.draw(g);
        }

        public void DrawCircle(Color newColor, bool fill, int radius)
        {
            newShape = identiferObject.getShape("circle");
            newShape.set(newColor, fill, pointX, pointY, radius);
            newShape.draw(g);
        }

        public void DrawTriangle(Color newColor, bool fill)
        {
            newShape = identiferObject.getShape("triangle");
            newShape.set(newColor, fill, pointX, pointY, pointX + 80, pointY + 80);
            newShape.draw(g);
        }

        public void programReader(String enteredCode)
        {
            if (enteredCode.Equals("triangle"))
            {
                enteredCode = enteredCode + " 1";
            }

            String[] codeSplitter = enteredCode.Split(' ');
            String command = codeSplitter[0];
            String parameters = codeSplitter[1];

            if (command.Equals("pen"))
            {
                if (parameters.Equals("red"))
                    penColor = Color.Red;

                else if (parameters.Equals("blue"))
                    penColor = Color.Blue;

                else if (parameters.Equals("yellow"))
                    penColor = Color.Yellow;

                else if (parameters.Equals("green"))
                    penColor = Color.Green;

                else
                {
                    penColor = Color.Black;
                    // Generate Error !!! -- This color is not available.!!!!!!!!!!!!!!!!!!
                }
            }

            else if (command.Equals("fill"))
            {
                if (parameters.Equals("on"))
                    fill = true;

                else if (parameters.Equals("off"))
                    fill = false;

                else
                {
                    fill = false;
                    // Generate Error !!!!! -  Not valid instruction. !!!!!!!!!!!!!!!!!!!!!!!!
                }

            }

            else if (command.Equals("triangle"))
            {
                DrawTriangle(penColor, fill);
            }

            else if (command.Equals("circle"))
            {
                int radius = Convert.ToInt32(parameters);
                DrawCircle(penColor, fill, radius);
            }

            else if (command.Equals("moveto"))
            {
                String[] parameterSplitter = parameters.Split(',');
                int parameter1 = Convert.ToInt32(parameterSplitter[0]);
                int parameter2 = Convert.ToInt32(parameterSplitter[1]);

                MoveTo(parameter1, parameter2);
            }

            else if (command.Equals("drawto"))
            {
                String[] parameterSplitter = parameters.Split(',');
                int parameter1 = Convert.ToInt32(parameterSplitter[0]);
                int parameter2 = Convert.ToInt32(parameterSplitter[1]);

                DrawLine(penColor, parameter1, parameter2);
            }

            else if (command.Equals("rectangle"))
            {
                String[] parameterSplitter = parameters.Split(',');
                int parameter1 = Convert.ToInt32(parameterSplitter[0]);
                int parameter2 = Convert.ToInt32(parameterSplitter[1]);

                DrawRectangle(penColor, fill, parameter1, parameter2);
            }

        }
    }
}
