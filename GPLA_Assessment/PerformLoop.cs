using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA_Assessment
{
    /// <summary>
    /// Perform Loop class which performs task underneath the while statement until the endloop is not found.<br/>
    /// Implements methods <see cref="checkLoopCommand(string)"/>, <see cref="executeLoopCommand(string, string)"/>
    /// , <see cref="executeLoop(bool, bool, string, string, int, bool, ArrayList)"/> and <see cref="runLoop(int, bool, string, ArrayList)"/> methods.
    /// </summary>
    public class PerformLoop
    {
        /// <summary>
        /// ArrayList object: <br/>
        /// Stores all the lines underneath the while command until the endloop command is encountered.
        /// </summary>
        ArrayList loopCommands = new ArrayList();

        /// <summary>
        /// Stores boolean values:<br/>
        /// True when loop condition along with the while statement is logically correct and false otherwise.
        /// </summary>
        bool loopConditionFlag = false;

        /// <summary>
        /// Stores boolean values: <br/>
        /// True when while loop command has a valid operator and false otherwise.
        /// </summary>
        bool loopCommandFlag = false;

        /// <summary>
        /// Stores integer value: <br/>
        /// Stores the value entered along with the expression of while statement condition.
        /// </summary>
        int variableValue;

        /// <summary>
        /// Stores integer value: <br/>
        /// Stores the variable's value from data dictionary after comparing with variable entered along with the while statement condition.
        /// </summary>
        int variableName;

        /// <summary>
        /// Method triggered when while keyword id encountered in the program window <br/>
        /// Checks if the operator in the while statement is correct and also checks the syntax of while command.
        /// </summary>
        /// <param name="enteredCode">The line of code which contains if statement retrieved from program window</param>
        /// <returns> True when condition within the while statement is correct and when while syntax is correct and false otherwise.</returns>
        public bool checkLoopCommand(String enteredCode)
        {
            /// Replaces the entered code if the regular expression pattern specified is matched. 
            enteredCode = Regex.Replace(enteredCode, @"\s+", "");

            /// Splits the if statement with respect to '(' and stores the values separately in a string array.
            String[] command = enteredCode.Split('(');

            /// String variable which stores operator encountered in the while statement.
            String loopOperator;

            /// String variable which stores condition retrieved from the while statement.
            String loopCondition;

            /// Checks if the length of the splitted command is 2 and adds error if not so.
            if (command.Length != 2)
            {
                ///---------------------------------------------------------------------------
                Canvas.errorList.Add("Enter correct Statement");
            }

            /// Checks if the command's first parameter is true and performs the task underneath.
            if (command[0].Equals("while"))
            {
                /// Checks if the length of the splitted command is 2 and performs the task underneath
                if (command.Length == 2)
                {
                    /// splits the entire line with respect to '(' and ')' and stores the splitted code in loopCondition variable
                    loopCondition = enteredCode.Split('(', ')')[1].Trim();

                    /// Checks the operator contained by the while condition expressions and stores it in loopOperator variable.
                    if (loopCondition.Contains("=="))
                    {
                        loopOperator = "==";
                    }
                    else if (loopCondition.Contains("!="))
                    {
                        loopOperator = "!=";
                    }
                    else if (loopCondition.Contains("<=") && !loopCondition.Contains(">"))
                    {
                        loopOperator = "<=";
                    }
                    else if (loopCondition.Contains(">=") && !loopCondition.Contains("<"))
                    {
                        loopOperator = ">=";
                    }
                    else if (loopCondition.Contains("<") && !loopCondition.Contains("=") && !loopCondition.Contains(">"))
                    {
                        loopOperator = "<";
                    }
                    else if (loopCondition.Contains(">") && !loopCondition.Contains("=") && !loopCondition.Contains("<"))
                    {
                        loopOperator = ">";
                    }
                    else
                    {
                        loopOperator = "Invalid";
                    }
                   
                    /// Calls the method executeLoopCommand by passing loopOperator and loopCondition retrieved from the while statement.
                    loopCommandFlag = executeLoopCommand(loopOperator, loopCondition);
                }
            }
            return loopCommandFlag;
        }

        /// <summary>
        /// Method Triggered when loop Condition and loop operator is retrieved from while statement. <br/>
        /// Checks if the condition in th while statement is true.
        /// </summary>
        /// <param name="loopOperator"> The operator retrieved from the condition expression witten along with while statement</param>
        /// <param name="loopCondition"> The retrieved condition expression written along with the while statement</param>
        /// <returns> True when while condition expression is logically correct and false otherwise. </returns>
        public bool executeLoopCommand(String loopOperator, String loopCondition)
        {
            /// Boolean variable set to false which is true if the while condition is logically correct.
            bool conditionCheck = false;

            /// Creates an object of Canvas class in order to access methods of the class.
            Canvas canvasObject = new Canvas();

            /// Splits the while condition retrieved with respect to the operator retrieved. 
            String[] splittedLoopCondition = loopCondition.Split(new String[] { loopOperator }, StringSplitOptions.RemoveEmptyEntries);

            /// Checks if the splitted while condition contains any variable and performs task underneath accordingly.
            if (Canvas.storeVariables.ContainsKey(splittedLoopCondition[0]))
            {
                /// Retrieves the value from data dictionary by matching the name of variable stored and entered then stores in variableName.
                variableName = Canvas.storeVariables[splittedLoopCondition[0]];

                try
                {
                    /// Checks if the splitted while condition's other half contains any variable and performs task underneath.
                    if (Canvas.storeVariables.ContainsKey(splittedLoopCondition[1]))
                    {
                        /// Retrieves the value from data dictionary by matching the name of variable stored and entered then stores in variableValue.
                        variableValue = Canvas.storeVariables[splittedLoopCondition[1]];
                    }
                    else
                    {
                        /// Converts the constant value entered in the second half of the while condition expression and stores in variableValue.
                        variableValue = Convert.ToInt32(splittedLoopCondition[1]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Canvas.errorList.Add("Enter correct while statement");
                }
                catch (FormatException)
                {
                    Canvas.errorList.Add("Enter correct while statement");
                }

                /// Checks the operator contained by the while condition expressions and performs task underneath
                if (loopOperator.Equals("=="))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName == variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals("!="))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName != variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals(">="))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName >= variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals("<="))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName <= variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals("<"))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName < variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals(">"))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName > variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else
                {
                    /// As all of the condition above did not match the condition, conditionCheck's boolean value is by default false.
                    conditionCheck = false;
                }
            }
            else
            {
                try
                {
                    /// Converts the constant value entered in the second half of the while condition expression and stores in variableValue.
                    variableName = Convert.ToInt32(splittedLoopCondition[0]);
                    /// Converts the constant value entered in the second half of the while condition expression and stores in variableValue.
                    variableValue = Convert.ToInt32(splittedLoopCondition[1]);
                }
                /// Catches FormatException which is encountered if the constant value entered is not a number.
                catch (FormatException)
                {
                    ///------------------------------------------------------------------------------------
                    Canvas.errorList.Add("Enter Correct While statement");
                }
                catch (IndexOutOfRangeException)
                {
                    Canvas.errorList.Add("Enter Correct While statement");
                }

                /// Checks the operator contained by the while condition expressions and performs task underneath
                if (loopOperator.Equals("=="))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName == variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals("!="))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName != variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals(">="))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName >= variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals("<="))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName <= variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals("<"))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName < variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals(">"))
                {
                    /// Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName > variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else
                {
                    /// As all of the condition above did not match the condition, conditionCheck's boolean value is by default false.
                    conditionCheck = false;
                }
            }
            return conditionCheck;
        }

        /// <summary>
        /// Method triggered when while condition is still on but endloop command is not yet encountered in the program window. <br/>
        /// Checks if the endloop command is encountered and performs loop by calling <see cref="runLoop(int, bool, string, ArrayList)"/> method afterwards.
        /// </summary>
        /// <param name="whileFlag"> The boolean value which is true when while command is encountered untill the endloop command is encountered. </param>
        /// <param name="loopConditionMatched">The boolean value which is true when condition in the while statement typed in the Program Window is matched logically and false otherwise.</param>
        /// <param name="whileCommand">The while command line entered in the Program Window is stored in the variable in order to check while condition multiple times.</param>
        /// <param name="enteredCode">Holds each line of command retrieved from the program Window of the application</param>
        /// <param name="lineCounter">Holds the number of line of the text</param>
        /// <param name="syntaxButton">Holds the boolean value of syntaxButton which confirms if syntaxButton was pressed in the application</param>
        /// <param name="canvasList">A temporary ArrayList which stores all the canvas objects which helps in drawing object in the display canvas.</param>
        /// <returns> True when while condition is true and endloop is not encountered and false when endloop is found and all loop commands are executed</returns>
        public bool executeLoop(bool whileFlag, bool loopConditionMatched, String whileCommand, String enteredCode, int lineCounter, bool syntaxButton, ArrayList canvasList)
        {
            /// Checks if the endloop command is encountered in the program Window and performs the task underneath.
            if (enteredCode.Equals("endloop"))
            {
                /// Checks if the loop condition in the while statement is true and performs tasks underneath accordingly.
                if (loopConditionMatched)
                {
                    /// Calls runLoop method, which performs loop until the while condition is not false, as endloop command is encountered.
                    runLoop(lineCounter, syntaxButton, whileCommand, canvasList);

                    /// Clears all the command in the arraylist loopCommands as all the commands have been successfully executed.
                    loopCommands.Clear();

                    /// Sets the boolean value of whileFlag to false as all commands insid the loop has been executed and it is the end of while loop.
                    whileFlag = false;
                }
                else
                {
                    /// Clears all the command in the arraylist loopCommands as while condition is not matched.
                    loopCommands.Clear();

                    /// Sets the boolean value of whileFlag to false as all commands insid the loop has been executed and it is the end of while loop.
                    whileFlag = false;
                }
            }
            else
            {
                /// Adds the entire line of code into the arrayList as the command comes under the while condition and comes above endloop command. 
                loopCommands.Add(enteredCode);
            }

            return whileFlag;
        }

        /// <summary>
        /// Method triggered when the endloop command is encountered.<br/>
        /// Executes the loop statements stored in the arraylist until the while condition is matched.
        /// </summary>
        /// <param name="lineCounter">Holds the number of line of the text</param>
        /// <param name="syntaxButton">Holds the boolean value of syntaxButton which confirms if syntaxButton was pressed in the application</param>
        /// <param name="whileCommand">The while command line entered in the Program Window is stored in the variable in order to check while condition multiple times.</param>
        /// <param name="canvasList">A temporary ArrayList which stores all the canvas objects which helps in drawing object in the display canvas.</param>
        public void runLoop(int lineCounter, bool syntaxButton, String whileCommand, ArrayList canvasList)
        {

            /// Creates an object of Canvas class in order to access methods of the class.            
            Canvas canvasObject = new Canvas();

            /// Retrieves all the drawing objects of canvas class from the array.
            canvasObject.g = (Graphics)canvasList[0];
            canvasObject.pointX = (int)canvasList[1];
            canvasObject.pointY = (int)canvasList[2];
            canvasObject.pen = (Pen)canvasList[3];

            /// Sets the loopCondition flag to true as the loop condition is true when the method is triggred.
            loopConditionFlag = true;

            /// Performs the while loop until the loopConditionFlag is true.
            while (loopConditionFlag)
            {
                /// Retrieves each item from the loop Command arraylist and executes all of them line by line.
                foreach (String eachLineCode in loopCommands)
                {
                    /// Calls the programReader method of canvas class as it performs the drawing commands to draw objects into display canvas.
                    canvasObject.programReader(eachLineCode, lineCounter, syntaxButton);
                }

                /// Checks if the while condition is still true and iterates the commands again if true.
                loopConditionFlag = checkLoopCommand(whileCommand);
            }
        }
    }
}
