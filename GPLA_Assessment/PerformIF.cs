using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA_Assessment
{
    class PerformIF
    {
        bool ifCommandFlag = false;
        int variableValue;
        int variableName;

        public bool checkIfCommand(String enteredCode)
        {
            enteredCode = Regex.Replace(enteredCode, @"\s+", "");
            String[] command = enteredCode.Split('(');
            String ifOperator;
            String ifCondition;


            if (command[0].Equals("if"))
            {
                if (command.Length == 2)
                {
                    ifCondition = enteredCode.Split('(', ')')[1].Trim();

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

                    ifCommandFlag = executeIFCommand(ifOperator, ifCondition);
                }
            }
            return ifCommandFlag;
        }
        
        public bool executeIFCommand(String ifOperator, String ifCondition)
        {
            bool conditionCheck = false;
            Canvas canvasObject = new Canvas();
            String[] splittedIFCondition = ifCondition.Split(new String[] {ifOperator}, StringSplitOptions.RemoveEmptyEntries);
            //MessageBox.Show(splittedIFCondition[0] + splittedIFCondition[1]); 

            if (Canvas.storeVariables.ContainsKey(splittedIFCondition[0]))
            {
                // try ---------
                variableName = Canvas.storeVariables[splittedIFCondition[0]];

                if (Canvas.storeVariables.ContainsKey(splittedIFCondition[1]))
                {
                    variableValue = Canvas.storeVariables[splittedIFCondition[1]];
                }
                else
                {
                    variableValue = Convert.ToInt32(splittedIFCondition[1]);
                }

                if (ifOperator.Equals("=="))
                {
                   if (variableName == variableValue)
                    {
                        MessageBox.Show(" == ");
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals("!="))
                {
                    if (variableName != variableValue)
                    {
                        MessageBox.Show(" != ");
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals(">="))
                {
                    if (variableName >= variableValue)
                    {
                        MessageBox.Show(" >= ");
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals("<="))
                {
                    if (variableName <= variableValue)
                    {
                        MessageBox.Show(" <= ");
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals("<"))
                {
                    if (variableName < variableValue)
                    {
                        MessageBox.Show(" < ");
                        conditionCheck = true;
                    }
                }
                else if (ifOperator.Equals(">"))
                {
                    if (variableName > variableValue)
                    {
                        MessageBox.Show(" > ");
                        conditionCheck = true;
                    }
                }
                else
                {
                    MessageBox.Show(" Not Matched ");
                    conditionCheck = false;
                }
            }
            return conditionCheck;
        }
    }
}
