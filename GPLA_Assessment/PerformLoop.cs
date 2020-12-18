using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    class PerformLoop
    {

        bool loopCommandFlag = false;
        int variableValue;
        int variableName;

        public bool checkLoopCommand(String enteredCode)
        {
            enteredCode = Regex.Replace(enteredCode, @"\s+", "");
            String[] command = enteredCode.Split('(');
            String loopOperator;
            String loopCondition;

            if (command[0].Equals("while"))
            {
                if (command.Length == 2)
                {
                    loopCondition = enteredCode.Split('(', ')')[1].Trim();

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
                   
                    loopCommandFlag = executeLoopCommand(loopOperator, loopCondition);
                }
            }
            return loopCommandFlag;
        }

        public bool executeLoopCommand(String loopOperator, String loopCondition)
        {
            bool conditionCheck = false;
            Canvas canvasObject = new Canvas();
            String[] splittedLoopCondition = loopCondition.Split(new String[] { loopCondition }, StringSplitOptions.RemoveEmptyEntries);

            if (Canvas.storeVariables.ContainsKey(splittedLoopCondition[0]))
            {
                // try ---------
                variableName = Canvas.storeVariables[splittedLoopCondition[0]];

                if (Canvas.storeVariables.ContainsKey(splittedLoopCondition[1]))
                {
                    variableValue = Canvas.storeVariables[splittedLoopCondition[1]];
                }
                else
                {
                    variableValue = Convert.ToInt32(splittedLoopCondition[1]);
                }

                if (loopOperator.Equals("=="))
                {
                    if (variableName == variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals("!="))
                {
                    if (variableName != variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals(">="))
                {
                    if (variableName >= variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals("<="))
                {
                    if (variableName <= variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals("<"))
                {
                    if (variableName < variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else if (loopOperator.Equals(">"))
                {
                    if (variableName > variableValue)
                    {
                        conditionCheck = true;
                    }
                }
                else
                {
                    conditionCheck = false;
                }
            }
            return conditionCheck;
        }
    }
}
