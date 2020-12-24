using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GPLA_Assessment
{
    /// <summary>
    /// Perform IF class which checks weather the if statement in the program windown is syntactically and logically correct.<br/>
    /// Implements methods <see cref="checkIfCommand(string, int)"/> and <see cref="executeIFCommand(string, string)"/>
    /// </summary>
    public class PerformIF
    {
        /// <summary>
        /// Stores boolean values: <br/>
        /// True when if command has correct syntax and logic and false otherwise.
        /// </summary>
        bool ifCommandFlag = false;

        /// <summary>
        /// Stores integer value: <br/>
        /// Stores the value entered along with the expression of if statement condition.
        /// </summary>
        int variableValue;

        /// <summary>
        /// Stores integer value: <br/>
        /// Stores the variable's value from data dictionary after comparing with variable entered along with the if statement condition.
        /// </summary>
        int variableName;

        /// <summary>
        /// Method triggered when if keyword is encountered in the program window.<br/>
        /// Checks if the operator in the if statement is correct and also checks the syntax of if command.
        /// Also implements a method <see cref="executeIFCommand(string, string)"/>
        /// </summary>
        /// <param name="enteredCode">The line of code which contains if statement retrieved from program window</param>
        /// <param name="lineCounter">The number of line in which if statement was found.</param>
        /// <returns> True when condition within if statement is correct and when if syntax is correct and false otherwise.</returns>
        public bool checkIfCommand(String enteredCode, int lineCounter)
        {
            // Replaces the entered code if the regular expression pattern specified is matched. 
            enteredCode = Regex.Replace(enteredCode, @"\s+", "");

            // Splits the if statement with respect to '(' and stores the values separately in a string array.
            String[] command = enteredCode.Split('(');

            // String variable which stores operator encountered in the if statement.
            String ifOperator;

            // String variable which stores condition retrieved from the if statement.
            String ifCondition;

            // Creates an object of Canvas class in order to access methods of the class.
            Canvas canvasObject = new Canvas();

            // Checks if the length of the splitted command is 2 and adds error if not so.
            if (command.Length != 2)
            {
                // Adds the following line as error in the errorList
                Canvas.errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter IF Statement  in Correct Syntax'");
            }

            // Checks if the command's first parameter is true and performs the task underneath.
            if (command[0].Equals("if"))
            {
                // Checks if the length of the splitted command is 2 and performs the task underneath
                if (command.Length == 2)
                {
                    // splits the entire line with respect to '(' and ')' and stores the splitted code in ifCondition variable.
                    ifCondition = enteredCode.Split('(', ')')[1].Trim();

                    // Checks the operator contained by the if condition expressions and stores it in ifOperator variable.
                    if (ifCondition.Contains("=="))
                    {
                        ifOperator = "==";
                    }
                    else if (ifCondition.Contains("!="))
                    {
                        ifOperator = "!=";
                    }
                    else if (ifCondition.Contains("<=") && !ifCondition.Contains(">"))
                    {
                        ifOperator = "<=";
                    }
                    else if (ifCondition.Contains(">=") && !ifCondition.Contains("<"))
                    {
                        ifOperator = ">=";
                    }
                    else if (ifCondition.Contains("<") && !ifCondition.Contains("=") && !ifCondition.Contains(">"))
                    {
                        ifOperator = "<";
                    }
                    else if (ifCondition.Contains(">") && !ifCondition.Contains("=") && !ifCondition.Contains("<"))
                    {
                        ifOperator = ">";
                    }
                    else
                    {
                        ifOperator = "Invalid";
                    }
                    // Calls the method executeIFCommand by passing if Operator retrieved and if Condition retrieved. 
                    ifCommandFlag = executeIFCommand(ifOperator, ifCondition, lineCounter);
                }
            }
           
            return ifCommandFlag;
        }

        /// <summary>
        /// Method Triggered when if condition and if operator is retrieved. <br/>
        /// Checks if the condition in if statement is true.
        /// </summary>
        /// <param name="ifOperator"> The operator retrieved from the condition expression witten along with if statement</param>
        /// <param name="ifCondition"> The retrieved condition expression written along with the if statement</param>
        /// <returns> True when if condition expression is logically correct and false otherwise. </returns>
        public bool executeIFCommand(String ifOperator, String ifCondition, int lineCounter)
        {
            // Creates an object of Canvas class in order to access methods of the class.
            Canvas canvasObject = new Canvas();

            // Boolean variable set to false which is true if the condition is logically correct.
            bool conditionCheck = false;

            // Splits the if condition retrieved with respect to the operator retrieved. 
            String[] splittedIFCondition = ifCondition.Split(new String[] {ifOperator}, StringSplitOptions.RemoveEmptyEntries);

            // Checks if the splitted if condition contains any variable and performs task underneath accordingly.
            if (Canvas.storeVariables.ContainsKey(splittedIFCondition[0]))
            {
                // Retrieves the value from data dictionary by matching the name of variable stored and entered then stores in variableName.
                variableName = Canvas.storeVariables[splittedIFCondition[0]];
                try
                {
                    // Checks if the splitted if condition's other half contains any variable and performs task underneath.
                    if (Canvas.storeVariables.ContainsKey(splittedIFCondition[1]))
                    {
                        // Retrieves the value from data dictionary by matching the name of variable stored and entered then stores in variableValue.
                        variableValue = Canvas.storeVariables[splittedIFCondition[1]];
                    }
                    else
                    {
                        try
                        {

                            // Converts the constant value entered in the second half of the if condition expression and stores in variableValue.
                            variableValue = Convert.ToInt32(splittedIFCondition[1]);
                        }
                        catch (FormatException)
                        {
                            // Adds the following line as error in the errorList
                            Canvas.errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter IF Statement  in Correct Syntax'");
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // Adds the following line as error in the errorList
                    Canvas.errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter IF Statement  in Correct Syntax'");
                }

                // Checks the operator contained by the if condition expressions and performs task underneath
                if (ifOperator.Equals("=="))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                   if (variableName == variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals("!="))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName != variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals(">="))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName >= variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals("<="))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName <= variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals("<"))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName < variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals(">"))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName > variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else
                {
                    // As all of the condition above did not match the condition, conditionCheck's boolean value is by default false.
                    conditionCheck = false;
                }
            }
            else
            {
                try
                {
                    // Converts the constant value entered in the second half of the if condition expression and stores in variableValue.
                    variableName = Convert.ToInt32(splittedIFCondition[0]);
                    // Converts the constant value entered in the second half of the if condition expression and stores in variableValue.
                    variableValue = Convert.ToInt32(splittedIFCondition[1]);
                }
                // Catches FormatException which is encountered if the constant value entered is not a number.
                catch (FormatException)
                {
                    // Adds the following line as error in the errorList
                    Canvas.errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter IF Statement  in Correct Syntax'");
                }
                catch (IndexOutOfRangeException)
                {
                    // Adds the following line as error in the errorList
                    Canvas.errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter IF Statement  in Correct Syntax'");
                }

                // Checks the operator contained by the if condition expressions and performs task underneath
                if (ifOperator.Equals("=="))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName == variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals("!="))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName != variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals(">="))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName >= variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals("<="))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName <= variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals("<"))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName < variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals(">"))
                {
                    // Checks if the condition is matched with respect to operator then returns true if matched and false otherwise.
                    if (variableName > variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else
                {
                    // As all of the condition above did not match the condition check's boolean value is by default false. 
                    conditionCheck = false;
                }
            }

            return conditionCheck;
        }
    }
}