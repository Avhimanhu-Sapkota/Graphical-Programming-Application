using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA_Assessment
{
    /// <summary>
    /// PerformMethod class which implements <see cref="identifyMethod(string, bool)"/> and <see cref="storeMethodCommands(string)"/> methoods 
    /// which checks if the method statement is encountered and adds all the code under the method statement to arraylist until endmethod statement is encountered.
    /// </summary>
    public class PerformMethod
    {
        /// <summary>
        /// Stores String value:<br/>
        /// Stores name of the method entered in the program Window.
        /// </summary>
        public String methodName;

        /// <summary>
        /// Stores string value:<br/>
        /// Stores the name of parameteres entered along with the method command in the program window.
        /// </summary>
        String methodParameters;

        /// <summary>
        /// Stores boolean value.
        /// True when method is encountered in the program window and false when endmethod command is encountered.
        /// </summary>
        bool methodFlag = true;

        /// <summary>
        /// ArrayList object which stores all the commands that comes under the method tag until the endmethod statement is encountered.
        /// </summary>
        public ArrayList methodCommands = new ArrayList();

        /// <summary>
        /// String array which stores the splitted parameters passed along with the method statement.
        /// </summary>
        public String[] splittedParameters;

        /// <summary>
        /// Method triggered when method statement is encountered in the program window.
        /// Checks if the method tag has correct name and parameters and stores the parameters for future use. 
        /// </summary>
        /// <param name="enteredCode">Holds each line of command retrieved from the program Window of the application</param>
        /// <param name="syntaxButton">Holds the boolean value of syntaxButton which confirms if syntaxButton was pressed in the application</param
        /// <param name="lineCounter">Holds the number of line of the text</param>
        /// <returns> True when method is encountered and until endmethod is found. False otherwise. </returns>
        public bool identifyMethod (String enteredCode, bool syntaxButton, int lineCounter)
        {
            try
            {
                // Sets methodFlag to true as the method statement is encountered when the method is called.
                methodFlag = true;

                // Splits the entered code on the basis of space and stores in a string array.
                String[] splittedMethod = enteredCode.Split(' ');

                // Splits the splittedMethod array's second value with respect to '(' and stores in a string array.
                String[] splittedMethodExpression = splittedMethod[1].Split('(');

                // Retrieves the method name from the splitted array.
                methodName = splittedMethodExpression[0].Trim();

                // Splits the entered code on the basis of '(' and ')' to take all the parameters and stores in a string array.
                methodParameters = enteredCode.Split('(', ')')[1].Trim();

                // Checks if the splitted method's first value is equal to method and performs task underneath.
                if (splittedMethod[0].Equals("method"))
                {
                    // Checks if the parameter list is empty and performs the task underneath if not empty.
                    if (!methodParameters.Equals(""))
                    {
                        // Splits the parameters with respoect to ',' and stores in a string array.
                        splittedParameters = methodParameters.Split(',');
                        
                        // Executes loop to retrieve each item from the array splittedParameters.
                        foreach (String eachParameter in splittedParameters)
                        {
                            // Checks if the syntax button is pressend and performs only if syntax button is not pressed.
                            if (!syntaxButton)
                            {
                                // Stores each parameter to data dictionary along with the value 0.
                                Canvas.storeVariables.Add(eachParameter, 0);
                            }
                        }
                    }
                }
            }
            // Catches IndexOutOfRangeException and adds the error string underneath to the errorList.
            catch (IndexOutOfRangeException)
            {
                // Adds the following line as error in the error list.
                Canvas.errorList.Add("ERROR!!! AT LINE " + lineCounter + ". Please Enter Correct Method statement");
            }

            return methodFlag;
        }

        /// <summary>
        /// Method triggered when method statement is already encountered but endmethod is not encountered yet.
        /// Adds all the code underneath the method statement into a arraylist to retrieve later.
        /// </summary>
        /// <param name="enteredCode">Holds each line of command retrieved from the program Window of the application</param>
        /// <returns> True when method is still on and returns False when endmethod command is encountered. </returns>
        public bool storeMethodCommands(String enteredCode)
        {
            // Checks if the endmethod statement is encountered and performs task underneath
            if (enteredCode.Equals("endmethod"))
            {
                // Sets the methodFlag to false as endmethod command is already encountered.
                methodFlag = false;
            }
            else
            {
                // Adds all the code underneath method until endmethod is found.
                methodCommands.Add(enteredCode);
            }

            return methodFlag;
        }
    }
}
