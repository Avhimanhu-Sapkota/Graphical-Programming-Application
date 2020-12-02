using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA_Assessment
{
    /// <summary>
    /// Creates and displays Graphical Interface of an application and adds graphical contents to the application.
    /// It extends <see cref="Form"/> class.
    /// Implements methods: <see cref="exitToolStripMenuItem_Click(object, EventArgs)"/>, <see cref="aboutToolStripMenuItem_Click(object, EventArgs)"/>,
    /// <see cref="userGuidelinesToolStripMenuItem_Click(object, EventArgs), <see cref="programReader(string)"/>, <see cref="commandLineWindow_KeyDown(object, KeyEventArgs)"/>, 
    /// <see cref="displayCanvas_Paint(object, PaintEventArgs)"/>, <see cref="checkSyntaxButton_Click(object, EventArgs)"/>, <see cref="loadProgramMenu_Click(object, EventArgs)"/>, and
    /// <see cref="saveProgramMenu_Click(object, EventArgs)"/>
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Object of <see cref="Bitmap"/>: Holds all the contents, that is to be drawn in the canvas, before it is displayed in the canvas. 
        /// It's size has been set to x-axis = 500 and y-axis = 500 
        /// </summary>
        Bitmap bitmapCanvas = new Bitmap(500, 500);

        /// <summary>
        /// Object of <see cref="Canvas"/>: Allows <see cref="Form1"/> to use the methods and codes of <see cref="Canvas"/> class.
        /// </summary>
        Canvas canvasObject;

        /// <summary>
        /// Default Constructor: Initializes components which displays the Form and Graphical contents of the application.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            // Draws the contents from the bitmapCanvas into the application's pictureBox: displayCanvas
            canvasObject = new Canvas(Graphics.FromImage(bitmapCanvas));
        }

        /// <summary>
        /// Method: Triggered  when 'Exit' subMenu is clicked in the application. <br/>
        /// Exits the application
        /// </summary>
        /// <param name="sender">Object: Instantiated to send signal when 'Exit' menu is clicked.</param>
        /// <param name="e">Handles events that are to be performed in the application when 'Exit' subMenu is clicked</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Closes the graphical form and Exits the application.
            Application.Exit();         
        }

        /// <summary>
        /// Method: Triggered when 'About' subMenu is clicked in the application. <br/>
        /// Displays a message box which contains the information about the application 
        /// </summary>
        /// <param name="sender">Object: Instantiated to send signal when the 'About' is clicked.</param>
        /// <param name="e">Handles events that are to be performed in the application when 'About' subMenu is clicked</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// Holds the message to be displayed in the message box
            String message = "This application has been developed to produce a simplified programming " +
                "language and environment.The application is an assignment designed by " +
                "Leeds Beckett University for Level 6 Students who are studying " +
                "computing. It covers the basics of sequence, selection and iteration " +
                "and allows the developers to explore graphical developments in C# " +
                "using Visual Studio Community 2019.\n\nApplication Programmer: " +
                "\nAvhimanhu Sapkota\nUniversity ID: 77202323\nThe British College\n\n" +
                "Copyright © 2020. All rights reserved.";

            /// Holds the title of the message Box
            String title = "About - Graphical Programming Language Application";

            /// Displays Message box along with the title and message
            MessageBox.Show(message, title);
        }

        /// <summary>
        /// Method: Triggered when 'User Guidelines' subMenu is clicked in the application. <br/>
        /// Displays message box which contains the user guidelines, which will help the user to use the application, 
        /// </summary>
        /// <param name="sender">Object: Instantiated to send signal when 'User Guidelines' menu is clicked.</param>
        /// <param name="e">Handles events that are to be performed in the application when 'User Guidelines' subMenu is clicked</param>
        private void userGuidelinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// Holds the message to be displayed in the message box
            String message = "\n\nApplication Interface:\nDisplay Canvas: It is a display panel or drawing " +
                "area where you will be able to view your outputs in accordance to the commands you type in " +
                "Program Window and Command Line Window.\n\nProgram Window: A text area where you can " +
                "type your programming codes which will allow you to perform various tasks. This window supports " +
                "multiple line of codes. It only supports some command prompts listed below. If you fail to type commands " +
                "correctly, you may encounter errors.\n\nCommands supported in Program Window:\n1. moveTo <x>,<y> - " +
                "This command will change the position of your pen to the specified position in the canvas. In place of moveTo " +
                "you are supposed to give x-axis and y-axis coordinates to place you pen's position. Example: moveTo 50,100 will " +
                "change the position of your pen to x-axis: 50 and y-axis: 100\n\n2. drawTo <x>,<y> - This command will draw a " +
                "line from the current position of the pen to the specified position in the canvas. In place of drawTo you are " +
                "supposed to give x-axis and y-axis coordinates which will be the end point of your line.  Example: drawTo 50,100 " +
                "will draw a line from current pen position to x-axis: 50 and y-axis: 100\n\n3. Rectangle <width>, <height> - " +
                "This command will draw a rectangle of specified width and height from the current pen position. Example: " +
                "Rectangle 50,100 will draw a rectangle of height = 100 and width = 50 from the current pen position.\n\n4. Circle " +
                "< radius > - This command will draw a circle of specified radius from the current pen position.Example: Circle 20 will " +
                "draw a circle of radius = 20 from the current pen position.\n\n5. Triangle - This command will draw a triangle from " +
                "the current pen position. \n\n6. Pen <color> -This command will specify the color of the pen. However, this command " +
                "only supports limited colors, they are: red, blue, yellow and green. If you fail to specify colors from the list you may encounter " +
                "errors.\n\n7. Fill <on / off> -This command will specify color fills for shapes(rectangle, circle and triangle). Example: Fill on will " +
                "display the shape filled with the chosen color while Fill off will display the shape outlined with the chosen color but the inside " +
                "area of the shape will be transparent.\n\nCommand Line Window: A text area where you are supposed to type basic command " +
                "prompts which will help you perform operations within the application. This window supports single line of code. It supports " +
                "all the command that is accepted by Program Window but has to be in single line. Some more commands supported by this window" +
                " are listed below. If you fail to type commands correctly, you may encounter errors. \n\nCommands supported in Command Line " +
                "Window\nClear - This command clears the drawing area.\nRun - This command will execute the codes written in Program Window\n" +
                "Reset - This command resets the initial position of pen to top left corner of the screen\n\nCheck Syntax Button: A button which " +
                "scans your code in the Program Window and  returns error messages if the code has errors and returns proceed otherwise." + 
                "\n\nError Feedback Window: A text display area which holds all the error that has been detected in the Program Window and " +
                "Command Line Window. Errors are displayed in red colored text and if there are no errors then it displays proceed in green colored " +
                "text\n\nLoad Program File (File - SubMenu): This menu will allow user to choose txt file, which should contain program code, and " +
                "displays the contents of the file in Program Window.\n\nSave Program (File - SubMenu): This menu will allow user to save the code " +
                "that has been written in Program Window." ;

            /// Holds the title of the message Box
            String title = "User Guidelines - Graphical Programming Language Application";

            // Displays Message box along with the title and message
            MessageBox.Show(message, title);
        }

        /// <summary>
        /// Method: <list type="bullet">Checks the value stored in the parameter and calls <see cref="Canvas.ClearScreen"/> if 'clear' and <see cref="Canvas.ResetPen"/> if 'reset'</list>
        ///         <list type="bullet">Retrieves multiple line of code from programWindow and calls <see cref="Canvas.programReader"/> if 'run'. </list>
        ///         <list type="bullet">Else, calls <see cref="Canvas.programReader"/> to check if the code is valid and performs tasks otherwise.</list>
        ///</summary>
        /// <param name="enteredCode">The command retrieved from the Command Line Window of the application</param>
        public void programReader(String enteredCode)
        {
            /// Reads the value in the parameter and trims the text and stores in the String variable: code.
            String code = enteredCode.Trim();

            /*
             * Checks the string written in the String: code and calls appropriate methods accordingly.
             */
            if (code.Equals("clear"))
                // Calls clearScreen method of Canvas class which clears the displayCanvas pictureBox of the application
                canvasObject.ClearScreen();

            else if (code.Equals("reset"))
                // Calls ResetPen method of Canvas class which changes the position of pen to (0,0) coordinates.
                canvasObject.ResetPen();
            
            else if (code.Equals("run"))
            {
                /// Creates an array of string, retrieves the text from programWindow and stores the lines. 
                string[] multilineCodes = programWindow.Lines;

                /// Index to count the line number of the text
                int index = 1;

                /*
                 * Iterates to retrive each line of text that was initially written in the programWindow and 
                 * calls programReader method, of Canvas class, along with each line of text.
                */
                foreach (String line in multilineCodes)
                {
                    // Increases index every time the line is changed (the loop is iterated).
                    int counter = index++;

                    // Calls programReader method, of Canvas class, and sends the line retrieved and counter as the parameter.
                    canvasObject.programReader(line, counter);
                }
            }

            else 
            {
                // Calls programReader method, of Canvas class, and sends the line retrieved and 1 as the parameter.
                canvasObject.programReader(code, 1);
            }
        }

        /// <summary>
        ///  Method: Triggered when key is pressed in the command Line Window of the application
        ///                 <list type="bullet">Retrieves the text written in the Command Line Window and calls the programReader method along with command as parameter. </list>
        ///                 <list type="bullet">Retrieve the contents of ArrayList: errorList created in the <see cref="Canvas"/> class and displays it's contents in the errorDisplayArea.</list>
        /// </summary>
        ///<param name="sender">Object: Instantiated to send signal when key has been pressed in the Command Line Window.</param>
        /// <param name="e">Handles events that are to be performed in the application when key is pressed in the Command Line Window.</param>
        private void commandLineWindow_KeyDown(object sender, KeyEventArgs e)
        {
            /*
             * Checks if the key pressed is Enter and performs tasks, if TRUE.
             */
            if (e.KeyCode == Keys.Enter)
            {
                // Sets the text of errorDisplayArea to null so that it does not repeat previously presented Error Messages.
                errorDisplayArea.Text = "";

                // Sets the color of the text to be displayed in errorDisplayArea, to 'red'.
                errorDisplayArea.ForeColor = Color.Red;

                // Calls clearErrorList() method of Canvas class.
                canvasObject.clearErrorList();

                /// Retrieves and Stores the text written in Command Line Window
                String command = commandLineWindow.Text;

                // Trims the spaces before and after the text and changes the alphabets to lowercase.
                command = command.Trim().ToLower();

                // Calls programReader method and sends the command retrieved as the parameter.
                programReader(command);

                /*
                 * Iterates to retrieve the contents of ArrayList: errorList created in the Canvas class.
                 */
                foreach (String eachError in canvasObject.errorList)
                {
                    // Retrieves each item of the ArrayList  and appends it to errorDisplayArea of the application.
                    errorDisplayArea.AppendText(eachError + "\n\n");
                }

                // Sets the text of the commandLineWindow to null so that the contents written is cleared everytime when 'Enter' is pressed.
                commandLineWindow.Text = "";
                Refresh();
            }
        }

        /// <summary>
        /// Method: Creates object of <see cref="Graphics"/> and draws various objects/images in the <see cref="bitmapCanvas"/>
        /// </summary>
        /// <param name="sender">Object: Instantiated to send signal when Paint event is performed in displayCanvas Window.</param>
        /// <param name="e">Handles events that are to be performed in the application when key is pressed in displayCanvas Window</param>
        private void displayCanvas_Paint(object sender, PaintEventArgs e)
        {
            /// Creates Graphics object g to paint or draw contents in the application.
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(bitmapCanvas, 0, 0);
        }

        /// <summary>
        ///  Method: Triggered when check Syntax button is clicked in the application
        ///                 <list type="bullet">Retrieves the items: errors in the ArrayList: errorList and appends it to the errorDisplayArea</list>
        ///                 <list type="bullet">Checks if there are any error in the ArrayList: errorList and appends proceed if the are no errors.</list>
        ///                 <list type="bullet">Retrieves multiple line of codes from programWindow and calls the <see cref="Canvas.programReader"/> method, 
        ///                  of <see cref="Canvas"/> class along with each line retrived and lineCounterIndex as parameter. </list>
        /// </summary>
        /// <param name="sender">Object: Instantiated to send signal when Check Syntax button is clicked in the application.</param>
        /// <param name="e">Handles events that are to be performed in the application when Check Syntax button is clicked in the application. </param>
        private void checkSyntaxButton_Click(object sender, EventArgs e)
        {
            // Sets the text of errorDisplayArea to null so that it does not repeat previously presented Error Messages.
            errorDisplayArea.Text = "";

            // Sets the color of the text to be displayed in errorDisplayArea, to 'red'.
            errorDisplayArea.ForeColor = Color.Red;

            // Calls clearErrorList() method of Canvas class.
            canvasObject.clearErrorList();

            /// Creates an array of string, retrieves the text from programWindow and stores the lines. 
            String[] multilineCodes = programWindow.Lines;

            /// Index to count the line number of the text
            int index = 1;

            /*
             * Iterates to retrive each line of text that was initially written in the programWindow and 
             * calls programReader method, of Canvas class, along with each line of text.
             */
            foreach (String line in multilineCodes)
            {
                // Increases index every time the line is changed (the loop is iterated).
                int counter = index++;

                // Calls programReader method, of Canvas class, and sends the line retrieved and counter as the parameter.
                canvasObject.programReader(line, counter);
            }

            // Calls clearScreen method of Canvas class which clears the displayCanvas pictureBox of the application to return to default state after syntax check
            canvasObject.ClearScreen();

            // Calls resetPen method of Canvas class which resets the x and y coordinates of the pen in the displayCanvas pictureBox of the application to return to default state after syntax check
            canvasObject.ResetPen();

            // Changes the color of the pen to black to return to default after syntax check
            canvasObject.penColor = Color.Black;

            // Changes the fill value to false to return to default state after syntax check
            canvasObject.fill = false;

            /*
             * Iterates to retrieve the contents of ArrayList: errorList created in the Canvas class.
             */
            foreach (String eachError in canvasObject.errorList)
            {
                // Retrieves each item of the ArrayList and appends it to errorDisplayArea of the application.
                errorDisplayArea.AppendText(eachError + "\n\n");
            }

            /*
             * Checks if the ArrayList: errorList has any data and display proceed if there is no data. 
             */
            if(canvasObject.errorList.Count == 0)
            {
                // Sets the color of the text to be displayed in errorDisplayArea, to 'green'.
                errorDisplayArea.ForeColor = Color.Green;

                // Appends the message to proceed to errorDisplayArea of the application.
                errorDisplayArea.AppendText("The program does not have any Error!! \nYou may proceed with Run command.");
            }
        }

        /// <summary>
        /// Method: Triggered when Load program file subMenu is clicked in the application </summary>br>
        /// Opens the Dialog Box and allows user to choose a file to open. Reads the contents of the file, if any, and displays them
        /// in the programWindow.
        /// </summary>
        /// <param name="sender">Object: Instantiated to send signal when 'Load program file' subMenu is clicked in the application.</param>
        /// <param name="e">Handles events that are to be performed in the application when 'Load program file' subMenu is clicked in the application. </param>
        private void loadProgramMenu_Click(object sender, EventArgs e)
        {
            /// Creates object of <see cref="OpenFileDialog"/> which will help to open a dialog box to choose and open a file from the system.
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Sets the title of the dialog box
            openFileDialog.Title = "Choose File";

            /*
             * Opens the Dialog Box and checks if the file has been chose to Open then performs the task underneath if the file has been opened. 
             */
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /// Stores the text that has been read and retrieved from the opened file.
                    String lines;

                    /// Retrieves the path of the file which has been chosen by the user
                    String filePath = openFileDialog.FileName;

                    /// Opens the file from the specific path and stores all data from the file into StreamReader object: streamFile
                    StreamReader streamFile = File.OpenText(filePath);

                    /*
                     * Checks if the file has any data. If the file has any data then performs tasks underneath.
                     */
                    while ((lines = streamFile.ReadLine()) != null)
                    {
                        // Reads and retrieves the data from file. Then, displays the data into programWindow of the application.
                        programWindow.Text += lines + "\n";
                    }
                }

                // Handles error thrown while doing Input or Output Operation
                catch (IOException)
                {
                    // Displays message box if IO Exception is caught while in the application.
                    MessageBox.Show("ERROR!!!", " IO Exception");
                }
            }
        }

        /// <summary>
        /// Method: Triggered when Save Program subMenu is clicked in the application
        /// Opens a dialog box to choose path and filename. Creates the file in the destination folder
        /// then retrieves the text written in programWindow and stores every line in the file.
        /// </summary>
        /// <param name="sender">Object: Instantiated to send signal when 'Save Program' subMenu is clicked in the application.</param>
        /// <param name="e">Handles events that are to be performed in the application when 'Save Program' subMenu is clicked in the application. </param>
        private void saveProgramMenu_Click(object sender, EventArgs e)
        {
            /// Creates object of <see cref="SaveFileDialog"/> which will help to open a dialog box to choose path and filename, where some text is to be saved.
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Sets the title of the dialog box.
            saveFileDialog.Title = "Save Program Code";

            // Opens a dialog box which will allow user to choose destination folder and write a filename. 
            saveFileDialog.ShowDialog();

            /*
             * Checks if the filename has been given for the file and performs the task underneath if the filename in not empty.
             */
            if (saveFileDialog.FileName != "")
            {
                /// Retrieves the path of the destination folder where the file is meant to be saved.
                String filePath = saveFileDialog.FileName;

                /// Creates a file in the destination folder chosen by the user.
                StreamWriter writeProgram = File.CreateText(filePath);

                /// Retrieves the text that has been written in the programWindow and stores in String array: codeToSave.
                String [] codeToSave = programWindow.Lines;

                /*
                 * Iterates through the string array to get each line and writes every line.
                 */
                foreach (string line in codeToSave)
                {
                    // Writes line of code retrieved into the file which has been created in the destination folder.
                    writeProgram.WriteLine(line);
                }
                // Closes the file which has been created in the destination folder.
                writeProgram.Close();
            }
        }
    }
}