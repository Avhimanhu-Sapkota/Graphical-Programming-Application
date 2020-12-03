﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA_Assessment
{
    /// <summary>
    /// Performs various tasks when changes are made in the application window and <br/>also makes changes in the application in reaction to the changes made.
    /// Implements methods: <br/><see cref="ClearScreen"/>, <see cref="MoveTo)"/>, <see cref="ResetPen"/>, <see cref="DrawLine(Color, int, int)"/>, <see cref="DrawRectangle(Color, bool, int, int)"/>
    /// <br/><see cref="DrawCircle(Color, bool, int)"/>, <see cref="DrawTriangle(Color, bool)"/>, and <see cref="programReader(string, int)"/>
    /// </summary>
    public class Canvas
    {
        /// <summary>
        /// Object of <see cref="Graphics"/>. Access methods of <see cref="Graphics"/> class. <br/>
        /// Helps to draw graphical contents in the displayCanvas pictureBox of the application.
        /// </summary>
        Graphics g;

        /// <summary>
        /// Object of <see cref="Pen"/> <br/>Accesses methods of <see cref="Pen"/>. Helps in drawing lines and
        /// curves in the displayCanvas pictureBox of the application.
        /// </summary>
        Pen pen = new Pen(Color.Black, 1);

        /// <summary>
        /// Stores the integer value of  x-coordinate of the displayCanvas PictureBox of the application
        /// </summary>
        int pointX;

        /// <summary>
        /// Stores the integer value of  y-coordinate of the displayCanvas PictureBox of the application
        /// </summary>
        int pointY;

        /// <summary>
        /// Object of <see cref="ArrayList"/><br/>
        /// Stores error messages that may occor in each line of text written in programWindow. 
        /// </summary>
        public ArrayList errorList = new ArrayList();
        
        /// <summary>
        /// Object of <see cref="Shape"/>. <br/>
        /// Access the methods of <see cref="Shape"/> class from <see cref="Canvas"/> class.
        /// </summary>
        Shape newShape;

        /// <summary>
        /// Object of <see cref="ShapeFactory"/>. <br/>
        /// Access the methods of <see cref="ShapeFactory"/> class from <see cref="Canvas"/> class.
        /// </summary>
        ShapeFactory identiferObject = new ShapeFactory();

        /// <summary>
        /// Stores boolean values:<br/>
        /// True when fill has been set to 'on' via programWindow/commandLineWindow, which helps in fill the objects to be drawn with the particular color of the pen.<br/>
        /// False when fill has been set to 'off'
        /// </summary>
        public bool fill;

        /// <summary>
        /// Stores the name of <see cref="Color"/> which will be used in pen to draw objects of different colors. 
        /// </summary>
        public Color penColor;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Canvas()
        {
            TextBox t = new TextBox();
            this.g = t.CreateGraphics();

            // Sets the initial value of x-coordinate to 0
            pointX = 0;

            // Sets the initial value of Y-coordinate to 0
            pointY = 0;

            // Sets the default color of pen to Black
            penColor = Color.Black;

            // Sets the default fill option to false.
            fill = false;
        }

        /// <summary>
        /// Method: Sets initial value of (x,y) coordiantes to (0,0). Sets default <see cref="penColor"/>to Black and deault value of <see cref="fill"/> to false/off.
        /// </summary>
        /// <param name="g">Object of <see cref="Graphics"/>. Helps to draw graphical contents in the displayCanvas pictureBox of the application.</param>
        public Canvas(Graphics g)
        {
            // Refers the value of 'g' to the current object of the method.
            this.g = g;

            // Sets the initial value of x-coordinate to 0
            pointX = 0;

            // Sets the initial value of Y-coordinate to 0
            pointY = 0;

            // Sets the default color of pen to Black
            penColor = Color.Black;

            // Sets the default fill option to false.
            fill = false;
        }

        /// <summary>
        /// Method: Triggered when 'clear' command is typed in the command Line Window of the application. <br/>
        /// Clears the graphical objects drawn in the drawing surface and sets the background color to white.
        /// </summary>
        public void ClearScreen()
        {
            g.Clear(Color.White);
        }

        /// <summary>
        /// Method: Triggered when 'moveTo' command, along with x and y coordinate, is typed along with the values of x and y coordinate.<br/>
        /// Sets the value of x and y coordinated to the specified values which eventually moves the position of cursor to the specified point in the drawing area. 
        /// </summary>
        /// <param name="x_coordinate"> Holds the new value of x-coordinate which is the new location of cursor in the drawing area. </param>
        /// <param name="y_coordinate"> Holds the new value of y-coordinate which is the new location of cursor in the drawing area. </param>
        public void MoveTo(int x_coordinate, int y_coordinate)
        {
            // Sets the value of x-coordinate as specified in the parameter x_coordinate.
            pointX = x_coordinate;

            // Sets the value of y-coordinate as specified in the parameter y_coordinate.
            pointY = y_coordinate;
        }

        /// <summary>
        /// Method: Triggered when 'clear' command is typed in the command Line Window of the application.
        /// Sets the value of x and y coordinates to (0,0) which is to reset the current position of the cursor in the drawing area to (0,0) 
        /// </summary>
        public void ResetPen()
        {
            // Sets the value of x-coordinate to 0 when the reset is typed in the command Line Window of the application
            pointX = 0;
            // Sets the value of y-coordinate to 0 when the reset is typed in the command Line Window of the application
            pointY = 0;
        }

        /// <summary>
        /// Method: Triggered when drawTo command, along with x and y coordinate, is typed in the application<br/>
        /// Draws line, with specified pen color, from the current position of cursor to the specified position of (x,y).
        /// </summary>
        /// <param name="newColor"> Holds the Color of line to be drawn.</param>
        /// <param name="x_coordinate">Holds the x-coordinate of the end point of the line.</param>
        /// <param name="y_coordinate">Holds the y-coordinate of the end point of the line.</param>
        public void DrawLine(Color newColor, int x_coordinate, int y_coordinate)
        {
            // Sets the penColor to the color specified in the parameter.
            pen.Color = newColor;

            // Draws line in the drawing area from (pointX, pointY) to (x_coordinate, y_coordinate)
            g.DrawLine(pen, pointX, pointY, x_coordinate, y_coordinate);

            // Sets the value of x-coordinate as specified in the parameter x_coordinate
            // As the new x-coordinate has to be the end point of the line drawn.
            pointX = x_coordinate;

            // Sets the value of y-coordinate as specified in the parameter y_coordinate
            // As the new y-coordinate has to be the end point of the line drawn.
            pointY = y_coordinate;
        }

        /// <summary>
        /// Method: Triggered when rectangle command, along with length and breadth, is typed in the application <br/>
        /// Calls a method which identifys the shape first then calls other methods :
        /// <list type="bullet"> Sets the Color, fill value, (x,y) of cursor, and length, breadth of rectangle. </list>
        ///<list type="bullet">Draws rectangle, in the displayCanvas, using the values set.</list>
        /// </summary>
        /// <param name="newColor">Holds the Color of pen which draws the rectangle.</param>
        /// <param name="fill">Holds the boolean value of fill - which is true when fill is on or false otherwise</param>
        /// <param name="length"> Holds the value of length of the rectangle</param>
        /// <param name="breadth">Holds the value of breadth of the rectangle</param>
        public void DrawRectangle(Color newColor, bool fill, int length, int breadth)
        {
            // Calls getShape method of FactoryShapeIdentifier class which returns the object of the rectangle Shape.
            newShape = identiferObject.getShape("rectangle");

            // Sets the Color, fill value, (x,y) of cursor, and length, breadth of rectangle.
            newShape.set(newColor, fill, pointX, pointY, length, breadth);

            // Draws rectangle, in the displayCanvas, using the values set.
            newShape.draw(g);
        }

        /// <summary>
        /// Method: Triggered when circle command, along with radius, is typed in the application <br/>
        ///  Calls a method which identifys the shape first then calls other methods :
        /// <list type="bullet"> Sets the Color, fill value, (x,y) of cursor, and radius of the circle. </list>
        ///<list type="bullet"> Draws circle, in the displayCanvas, using the values set.</list>
        /// </summary>
        /// <param name="newColor">Holds the Color of pen which draws the circle</param>
        /// <param name="fill">Holds the boolean value of fill - which is true when fill is on or false otherwise</param>
        /// <param name="radius">Holds the value of radius of the circle</param>
        public void DrawCircle(Color newColor, bool fill, int radius)
        {
            // Calls getShape method of FactoryShapeIdentifier class which returns the object of the circle Shape.
            newShape = identiferObject.getShape("circle");

            // Sets the Color, fill value, (x,y) of cursor, and radius of the circle.
            newShape.set(newColor, fill, pointX, pointY, radius);

            // Draws circle , in the displayCanvas, using the values set.
            newShape.draw(g);
        }

        /// <summary>
        /// Method: Triggered when triangle command is typed in the application <br/>
        ///  Calls a method which identifys the shape first then calls other methods :
        /// <list type="bullet"> Sets the Color, fill value, (x,y) of cursor, and other two verticies of the triangle. </list>
        ///<list type="bullet"> Draws triangle , in the displayCanvas, using the values set.</list>
        /// </summary>
        /// <param name="newColor">Holds the Color of pen which draws the triangle</param>
        /// <param name="fill">Holds the boolean value of fill - which is true when fill is on or false otherwise</param>
        public void DrawTriangle(Color newColor, bool fill)
        {
            // Calls getShape method of FactoryShapeIdentifier class which returns the object of the circle Shape.
            newShape = identiferObject.getShape("triangle");

            // Sets the Color, fill value, (x,y) of cursor, and other two verticies of the triangle.
            newShape.set(newColor, fill, pointX, pointY, pointX + 80, pointY + 80);

            // Draws triangle , in the displayCanvas, using the values set.
            newShape.draw(g);
        }

        /// <summary>
        /// Method: Erases all items which are stored in the ArrayList: <see cref="errorList"/>
        /// </summary>
        public void clearErrorList()
        {
            // Clears all the data items stored in the ArrayList.
            errorList.Clear();
        }

        /// <summary>
        /// Method: Triggered when enteredCode has command and parameters separated by space and are required to be split.
        /// Splits the command and parameters separated by space as different item and saves them into an array of string.
        /// </summary>
        /// <param name="enteredCode"> Holds the string value which contains command and parameters separated by space</param>
        /// <returns></returns>
        public String[] CommandSplitter(String enteredCode)
        {
            /// Array of strings which stores code, separated by space, as a different item. 
            String[] splittedCommand = enteredCode.Split(' ');

            return splittedCommand;
        }

        /// <summary>
        /// Method: Triggered when parameters has values separated by ',' and are required to be split.
        /// Splits the parameters separated by ',' as a different item and saves them into an array of string.
        /// </summary>
        /// <param name="parameters">Holds the string value of parameters which parameters separated by ',' </param>
        /// <returns> The string array which contains parameter's separated values as different items.</returns>
        public String[] ParameterSplitter(String parameters)
        {
            /// Array of strings which stores parameters, separated by ',' as a different item.
            String[] splittedParameter = parameters.Split(',');

            return splittedParameter;
        }

        /// <summary>
        /// Method Triggered when some text is written in the program Window and run command is pressed.<br/>
        /// Splits the string and stores their value in variables. Checks the string then: Implements <br/><see cref="DrawLine(Color, int, int)"/>, <see cref="DrawRectangle(Color, bool, int, int)"/>
        /// <see cref="DrawCircle(Color, bool, int)"/>, <see cref="DrawTriangle(Color, bool)"/> being based on the conditions. 
        /// </summary>
        /// <param name="enteredCode">Holds each line of command retrieved from the program Window of the application</param>
        /// <param name="lineCounter">Holds the number of line of the text</param>
        public void programReader(String enteredCode, int lineCounter)
        {
            /*
             * Checks if the enteredCode is triangle and concatenates " 1" so that it will avoid errors when the code is later splitted.
             */
            if (enteredCode.Equals("triangle"))
            {
                // Concatenates " 1" to the enteredCodes
                enteredCode = enteredCode + " 1";
            }

            try
            {
                /// Calls method which has Array of strings which stores command and parameters , separated by space as a different item.
                String[] splittedCommand = CommandSplitter(enteredCode);

                /// Retrieves the first string of the array and stores its string value to string: command
                String command = splittedCommand[0];

                /// Retrieves the first string of the array and stores its string value to string: command
                String parameters = splittedCommand[1];

                /*
                * Checks the string written in the String: command and calls appropriate methods accordingly.
                */
                if (command.Equals("pen"))
                {
                    /*
                    * Checks the string written in the String: parameters and performs tasks underneath accordingly.
                    */
                    if (parameters.Equals("red"))
                        // Sets the color of pen to red as the parameter holds the string red.
                        penColor = Color.Red;

                    else if (parameters.Equals("blue"))
                        // Sets the color of pen to blue as the parameter holds the string blue.
                        penColor = Color.Blue;

                    else if (parameters.Equals("yellow"))
                        // Sets the color of pen to yellow as the parameter holds the string yellow.
                        penColor = Color.Yellow;

                    else if (parameters.Equals("green"))
                        // Sets the color of pen to green as the parameter holds the string green.
                        penColor = Color.Green;

                    else
                    {
                        // Sets the color of pen to black which is default as none of the condition above is true.
                        penColor = Color.Black;

                        // Calls a method which adds the specified string in the arrayList errorList.
                        errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter a valid color - 'red', 'blue', 'yellow' or 'green'" );
                    }
                }

                else if (command.Equals("fill"))
                {
                    /*
                    * Checks the string written in the String: parameters and performs tasks underneath accordingly.
                    */
                    if (parameters.Equals("on"))
                        // Sets the boolean value of fill to true as the parameter holds the string on.
                        fill = true;

                    else if (parameters.Equals("off"))
                        // Sets the boolean value of fill to false as the parameter holds the string off. 
                        fill = false;

                    else
                    {
                        // Sets the boolean value of fill to false which is default as none of the condition above is true.
                        fill = false;

                        // Calls a method which adds the specified string in the arrayList errorList.
                        errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter valid parameter - 'on' or 'off'");
                    }
                }

                else if (command.Equals("triangle"))
                {
                    // Calls method DrawTriangle, which draws triangle, as the command holds string triangle.
                    DrawTriangle(penColor, fill);
                }

                else if (command.Equals("circle"))
                {
                    try
                    {
                        // Retrieves the value of parameters, converts it to Integer and stores to radius variable.
                        int radius = Convert.ToInt32(parameters);

                        // Calls method DrawCircle, which draws circle, as the command holds the string triangle
                        DrawCircle(penColor, fill, radius);
                    }
                    // Catches error if non-numeric value is detected in the variable: parameters. 
                    catch (FormatException)
                    {
                        // Calls a method which adds the specified string in the arrayList errorList.
                        errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter Numeric Value for Radius.");
                    }
                }

                else if (command.Equals("moveto"))
                {
                    try
                    {
                        /// Calls method which has Array of strings which stores parameters, separated by ',' as a different item.
                        String[] splittedParameters = ParameterSplitter(parameters);

                        /// Retrieves the first string of the array, converts it's value to integer and stores it as parameter1.
                        int parameter1 = Convert.ToInt32(splittedParameters[0]);

                        /// Retrieves the second string of the array, converts it's value to integer and stores it as parameter1.
                        int parameter2 = Convert.ToInt32(splittedParameters[1]);

                        // Calls method MoveTo, which changes the current position of cursor, as the command holds the string moveTo
                        MoveTo(parameter1, parameter2);
                    }
                    // Catches error if non-numeric value is detected in the variable: parameters. 
                    catch (FormatException)
                    {
                        // Calls a method which adds the specified string in the arrayList errorList.
                        errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter Numeric Value for coordinates.");
                    }
                    // Catches error if there is only one or more than two values in the variable: parameters. 
                    catch (IndexOutOfRangeException)
                    {
                        // Calls a method which adds the specified string in the arrayList errorList.
                        errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter Two Numeric Values for coordinates.");
                    }
                }

                else if (command.Equals("drawto"))
                {
                    try
                    {
                        /// Calls method which has Array of strings which stores parameters, separated by ',' as a different item.
                        String[] splittedParameters = ParameterSplitter(parameters);

                        /// Retrieves the first string of the array, converts it's value to integer and stores it as parameter1.
                        int parameter1 = Convert.ToInt32(splittedParameters[0]);

                        /// Retrieves the second string of the array, converts it's value to integer and stores it as parameter1.
                        int parameter2 = Convert.ToInt32(splittedParameters[1]);

                        // Calls method DrawLine, which draws a line, as the command holds the string drawTo
                        DrawLine(penColor, parameter1, parameter2);
                    }
                    // Catches error if non-numeric value is detected in the variable: parameters. 
                    catch (FormatException)
                    {
                        // Calls a method which adds the specified string in the arrayList errorList.
                        errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter Numeric Value for coordinates.");
                    }
                    // Catches error if there is only one or more than two values in the variable: parameters. 
                    catch (IndexOutOfRangeException)
                    {
                        // Calls a method which adds the specified string in the arrayList errorList.
                        errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter Two Numeric Values for coordinates.");
                    }
                }

                else if (command.Equals("rectangle"))
                {
                    try
                    {
                        /// Calls method which has Array of strings which stores parameters, separated by ',' as a different item.
                        String[] splittedParameters = ParameterSplitter(parameters);

                        /// Retrieves the first string of the array, converts it's value to integer and stores it as parameter1.
                        int parameter1 = Convert.ToInt32(splittedParameters[0]);

                        /// Retrieves the second string of the array, converts it's value to integer and stores it as parameter1.
                        int parameter2 = Convert.ToInt32(splittedParameters[1]);

                        // Calls method DrawRectangle, which draws rectangle, as the command holds the string triangle
                        DrawRectangle(penColor, fill, parameter1, parameter2);
                    }
                    // Catches error if non-numeric value is detected in the variable: parameters. 
                    catch (FormatException)
                    {
                        // Calls a method which adds the specified string in the arrayList errorList.
                        errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter Numeric Value for coordinates.");
                    }
                    // Catches error if there is only one or more than two values in the variable: parameters. 
                    catch (IndexOutOfRangeException)
                    {
                        // Calls a method which adds the specified string in the arrayList errorList.
                        errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter Two Numeric Values for coordinates.");
                    }
                }

                else
                {
                    // Calls a method which adds the specified string in the arrayList errorList. 
                    // As none of the condition above is true.
                    errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter Valid Command.");
                }
            }
            // Catches error if there is only one or more than two values in the variable: enteredCode. 
            catch (IndexOutOfRangeException)
            {
                errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter Valid Command.");
            }
        }
    }
}