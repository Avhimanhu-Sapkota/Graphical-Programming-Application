using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA_Assessment
{
    public partial class Form1 : Form
    {
        Bitmap bitmapCanvas = new Bitmap(500, 500);
        Canvas canvasObject;
        ArrayList shapes = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            canvasObject = new Canvas(Graphics.FromImage(bitmapCanvas));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "This application has been developed to produce a simplified programming " +
                "language and environment.The application is an assignment designed by " +
                "Leeds Beckett University for Level 6 Students who are studying " +
                "computing. It covers the basics of sequence, selection and iteration " +
                "and allows the developers to explore graphical developments in C# " +
                "using Visual Studio Community 2019.\n\nApplication Programmer: " +
                "\nAvhimanhu Sapkota\nUniversity ID: 77202323\nThe British College\n\n" +
                "Copyright © 2020. All rights reserved.";

            string title = "About - Graphical Programming Language Application";

            MessageBox.Show(message, title);
        }

        private void userGuidelinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "The application contains three different components. The empty area " +
                "at the top of the application is a 'Canvas'. The multiple line textbox area is 'Program Window'" +
                ". The single line textbox area, at the end of the application, is 'Command Line Window'" +
                "\n\nApplication Interface:\nCanvas: It is a display panel or drawing " +
                "area where you will be able to view your outputs in accordance to the commands " +
                "you type in Program Window and Command Line Window.\n\nProgram Window: A text " +
                "area where you can type your programming codes which will allow you to perform " +
                "various tasks. This window supports multiple line of codes. It only supports " +
                "some command prompts listed below. If you fail to type commands correctly, " +
                "you may encounter errors.\n\nCommands supported in Program Window:\n1. Position " +
                "Pen (moveTo) - This command will change the position of your pen to the " +
                "specified position in the canvas. In place of moveTo you are supposed to " +
                "give x-axis and y-axis coordinates to place you pen's position. Example: " +
                "Position Pen 50, 100 will change the position of your pen to x-axis: 50 and " +
                "y-axis: 100\n\n2. Pen draw (drawTo) - This command will draw a line from the " +
                "current position of the pen to the specified position in the canvas. " +
                "In place of drawTo you are supposed to give x-axis and y-axis coordinates " +
                "which will be the end point of your line.  Example: Position draw 50, 100 " +
                "will draw a line from current pen position to x-axis: 50 and y-axis: 100\n\n" +
                "3. Rectangle <width>, <height> - This command will draw a rectangle of specified " +
                "width and height from the current pen position. Example: Rectangle 50, 100 will " +
                "draw a rectangle of height = 100 and width = 50 from the current pen position." +
                "\n\n4. Circle < radius > -This command will draw a circle of specified radius from " +
                "the current pen position.Example: Circle 20 will draw a circle of radius = 20 from " +
                "the current pen position.\n\n5. Triangle - This command will draw a triangle from " +
                "the current pen position. \n\n6. Pen < color > -This command will specify the color " +
                "of the pen. However, this command only supports limited colors, they are: red, " +
                "blue, yellow and green. If you fail to specify colors from the list you may encounter " +
                "errors.\n\n7. Fill < on / off > -This command will specify color fills for " +
                "shapes(rectangle, circle and triangle).Example: Fill on will display the " +
                "shape filled with the chosen color while Fill off will display the shape " +
                "outlined with the chosen color but the inside area of the shape will be " +
                "transparent.\n\nCommand Line Window: A text area where you are supposed " +
                "to type basic command prompts which will help you perform operations within " +
                "the application.This window supports single line of code.It only supports " +
                "command prompts listed below.If you fail to type commands correctly, " +
                "you may encounter errors. \n\nCommands supported in Command Line Window:" +
                "\nClear - This command clears the drawing area.\nRun - This command will " +
                "execute the codes written in Program Window\nReset - This command resets the " +
                "initial position of pen to top left corner of the screen";

            string title = "User Guidelines - Graphical Programming Language Application";

            MessageBox.Show(message, title);
        }

        private void commandLineWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String command = commandLineWindow.Text;
                command = command.Trim().ToLower();

                ShapeIdentifier identiferObject = new ShapeIdentifier();
                /*try
                {
                    shapes.Add(identiferObject.getShape("rectangle"));
                    shapes.Add(identiferObject.getShape("circle"));
                    shapes.Add(identiferObject.getShape("triangle"));
                }
                catch (ArgumentException exp)
                {
                    Console.WriteLine("Invalid Shape: " + exp);
                }*/
                Shape newShape;
                Color newColor = Color.Black;
                //String programCode = programWindow.Text;
                //programReader(programCode);
        
                if (command.Equals("line") == true)
                {
                    canvasObject.DrawLine(100, 100);
                }
                else if (command.Equals("rectangle") == true)
                {
                    newShape = identiferObject.getShape("rectangle");
                    newShape.set(newColor, 10, 20, 180, 80);
                    shapes.Add(newShape);
                }
                else if (command.Equals("circle") == true)
                {
                    newShape = identiferObject.getShape("circle");
                    newShape.set(newColor, 10, 20, 50);
                    shapes.Add(newShape);
                }
                else if (command.Equals("triangle") == true)
                {
                    newShape = identiferObject.getShape("rectangle");
                    newShape.set(newColor, 10, 20, 22, 38);
                    shapes.Add(newShape);
                }
                else 
                { 

                }
                
                commandLineWindow.Text = "";
                Refresh();
            }
        }

        private void displayCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(bitmapCanvas, 0, 0);

            for (int index = 0; index < shapes.Count; index++)
            {
                Shape newShapeObject;
                newShapeObject = (Shape)shapes[index];

                if(newShapeObject != null)
                {
                    newShapeObject.draw(g);
                    Console.WriteLine(newShapeObject.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid Shape");
                }
            }
            
        }


        /*public void programReader(String enteredCode)
        {

           String code = enteredCode.Trim();
           String[] codeSplitter = code.Split(' ');

           String command = codeSplitter[0];
           String parameters = codeSplitter[1];

           String[] parameterSplitter = parameters.Split(',');
           int parameter1 = Convert.ToInt32(parameterSplitter[0]);
           int parameter2 = Convert.ToInt32(parameterSplitter[1]);

           Console.WriteLine(code + "\n" + command + "\n" + parameters + "\n" + parameter1 + "\n" + parameter2);
        }*/
    }
}
