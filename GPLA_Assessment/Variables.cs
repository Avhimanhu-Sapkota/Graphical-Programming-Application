using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    /// <summary>
    /// Specially created for Hand In (Part - 2). Created for Unit Test Purpose, for now. 
    /// Identifies variables from the program window. Checks for other expressions along with variables.
    /// Also, Read's the values assigned to the variables and stores it in order to perform tasks later in the program.
    /// </summary>
    public class Variables
    {

        /// <summary>
        /// Supposed to check if the entered variable expression is correct and splits the variables and values separately. 
        /// </summary>
        /// <param name="variablesExpression">Holds the variables and expression typed in the programWindow of the application</param>
        public String[] checkVariables(String variablesExpression)
        {
            //-----------------------------------------------------------------------------------------------------------------
            String[] splittedParameter = variablesExpression.Split('=');
            return splittedParameter;
        }

        /// <summary>
        ///  Supposed to read the variables and values stored in those variables separately which would be used further to perform tasks.
        /// </summary>
        /// <param name="variables">Holds the name of the variables</param>
        /// <param name="variableValues">Holds the values stored in that particular variable. </param>
        public String readVariableValue(String variable, String variableValue)
        {
            return variableValue;
        }
    }
}
