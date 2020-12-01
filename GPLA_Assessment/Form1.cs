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
    public partial class Form1 : Form
    {
        Bitmap bitmapCanvas = new Bitmap(500, 500);
        Canvas canvasObject;

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
            string message = "\n\nApplication Interface:\nDisplay Canvas: It is a display panel or drawing " +
                "area where you will be able to view your outputs in accordance to the commands " +
                "you type in Program Window and Command Line Window.\n\nProgram Window: A text " +
                "area where you can type your programming codes which will allow you to perform " +
                "various tasks. This window supports multiple line of codes. It only supports " +
                "some command prompts listed below. If you fail to type commands correctly, " +
                "you may encounter errors.\n\nCommands supported in Program Window:\n1. " +
                "moveTo <x>,<y> - This command will change the position of your pen to the " +
                "specified position in the canvas. In place of moveTo you are supposed to " +
                "give x-axis and y-axis coordinates to place you pen's position. Example: " +
                "moveTo 50,100 will change the position of your pen to x-axis: 50 and " +
                "y-axis: 100\n\n2. drawTo <x>,<y> - This command will draw a line from the " +
                "current position of the pen to the specified position in the canvas. " +
                "In place of drawTo you are supposed to give x-axis and y-axis coordinates " +
                "which will be the end point of your line.  Example: drawTo 50,100 " +
                "will draw a line from current pen position to x-axis: 50 and y-axis: 100\n\n" +
                "3. Rectangle <width>, <height> - This command will draw a rectangle of specified " +
                "width and height from the current pen position. Example: Rectangle 50,100 will " +
                "draw a rectangle of height = 100 and width = 50 from the current pen position." +
                "\n\n4. Circle < radius > - This command will draw a circle of specified radius from " +
                "the current pen position.Example: Circle 20 will draw a circle of radius = 20 from " +
                "the current pen position.\n\n5. Triangle - This command will draw a triangle from " +
                "the current pen position. \n\n6. Pen <color> -This command will specify the color " +
                "of the pen. However, this command only supports limited colors, they are: red, " +
                "blue, yellow and green. If you fail to specify colors from the list you may encounter " +
                "errors.\n\n7. Fill <on / off> -This command will specify color fills for " +
                "shapes(rectangle, circle and triangle). Example: Fill on will display the " +
                "shape filled with the chosen color while Fill off will display the shape " +
                "outlined with the chosen color but the inside area of the shape will be " +
                "transparent." +
                "\n\nCommand Line Window: A text area where you are supposed " +
                "to type basic command prompts which will help you perform operations within " +
                "the application. This window supports single line of code. It supports all the command that is accepted" +
                " by Program Window but has to be in single line. Some more commands supported by this window" +
                " are listed below. If you fail to type commands correctly, " +
                "you may encounter errors. \n\nCommands supported in Command Line Window:" +
                "\nClear - This command clears the drawing area.\nRun - This command will " +
                "execute the codes written in Program Window\nReset - This command resets the " +
                "initial position of pen to top left corner of the screen" +
                "\n\nCheck Syntax Button: A button which scans your code in the Program Window" +
                "and  returns error messages if the code has errors and returns proceed otherwise." + 
                "\n\nError Feedback Window: A text display area which holds all the error that has been detected" +
                "in the Program Window and Command Line Window. Errors are displayed in red colored text " +
                "and if there are no errors then it displays proceed in green colored text" + 
                "\n\nLoad Program File (File - SubMenu): This menu will allow user to choose txt file, which should contain" +
                " program code, and displays the contents of the file in Program Window.\n\nSave Program (File - SubMenu): This" +
                " menu will allow user to save the code that has been written in Program Window." ;

            string title = "User Guidelines - Graphical Programming Language Application";

            MessageBox.Show(message, title);
        }
        public void programReader(String enteredCode)
        {
            ShapeIdentifier identiferObject = new ShapeIdentifier();

            String code = enteredCode.Trim();
            if (code.Equals("clear"))
            {
                canvasObject.ClearScreen();
            }

            else if (code.Equals("reset"))
            {
                canvasObject.ResetPen();
            }

            else if (code.Equals("run"))
            {
                string[] multilineCodes = programWindow.Lines;
                int index = 1;
                foreach (string line in multilineCodes)
                {
                    int counter = index++;
                    canvasObject.programReader(line, counter);
                }
            }

            else 
            {
                canvasObject.programReader(code, 1);
            }
            
            
        }

        private void commandLineWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                errorDisplayArea.Text = "";
                errorDisplayArea.ForeColor = Color.Red;
                canvasObject.clearErrorList();

                String command = commandLineWindow.Text;
                command = command.Trim().ToLower();
                programReader(command);
                foreach (string eachError in canvasObject.errorList)
                {
                    errorDisplayArea.AppendText(eachError + "\n\n");
                }

                commandLineWindow.Text = "";
                Refresh();
                
            }
        }

        private void displayCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(bitmapCanvas, 0, 0);

        }

        private void checkSyntaxButton_Click(object sender, EventArgs e)
        {
            errorDisplayArea.Text = "";
            errorDisplayArea.ForeColor = Color.Red;
            canvasObject.clearErrorList();

            string[] multilineCodes = programWindow.Lines;
            int index = 1;
            foreach (string line in multilineCodes)
            {
                int counter = index++;
                canvasObject.programReader(line, counter);
            }

            foreach (string eachError in canvasObject.errorList)
            {
                errorDisplayArea.AppendText(eachError + "\n\n");
            }

            if(canvasObject.errorList.Count == 0)
            {
                errorDisplayArea.ForeColor = Color.Green;
                errorDisplayArea.AppendText("The program does not have any Error!! \nYou may proceed with Run command.");
            }
        }

        private void loadProgramMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String line;
                    String filePath = openFileDialog.FileName;
                    StreamReader streamFile = File.OpenText(filePath);

                    while ((line = streamFile.ReadLine()) != null)
                    {
                        programWindow.Text += line + "\n";
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("ERROR!!!", " IO Exception");
                }

            }
        }

        private void saveProgramMenu_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Program Code";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                String filePath = saveFileDialog.FileName;
                StreamWriter writeProgram = File.CreateText(filePath);

                String [] codeToSave = programWindow.Lines;

                foreach (string line in codeToSave)
                {
                    writeProgram.WriteLine(line);
                }
                writeProgram.Close();
            }
        }
    }
}
