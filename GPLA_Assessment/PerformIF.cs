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
        Canvas canvasObject = new Canvas();

        public bool checkIfCommand (String enteredCode)
        {
            enteredCode = Regex.Replace(enteredCode, @"\s+", "");
            String [] command = enteredCode.Split('(');
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
                        ifCommandFlag = true;
                    }
                    else if (ifCondition.Contains("!="))
                    {
                        ifOperator = "!=";
                        ifCommandFlag = true;
                    }
                    else if (ifCondition.Contains("<=") && !ifCondition.Contains(">"))
                    {
                        ifOperator = "<=";
                        ifCommandFlag = true;
                    }
                    else if (ifCondition.Contains(">=") && !ifCondition.Contains("<"))
                    {
                        ifOperator = ">=";
                        ifCommandFlag = true;
                    }
                    else if (ifCondition.Contains("<") && !ifCondition.Contains("=") && !ifCondition.Contains(">"))
                    {
                        ifOperator = "<";
                        ifCommandFlag = true;
                    }
                    else if (ifCondition.Contains(">") && !ifCondition.Contains("=") && !ifCondition.Contains("<"))
                    {
                        ifOperator = ">";
                        ifCommandFlag = true;
                    }
                    else
                    {
                        ifOperator = "Invalid";
                        ifCommandFlag = false;
                    }
                    MessageBox.Show("IF: " + ifOperator);
                    executeIFCommand(ifOperator, ifCondition);
                }
            }

            return ifCommandFlag;
        }

        public void executeIFCommand(String ifOperator, String ifCondition)
        {
            String[] splittedIFCondition = ifCondition.Split(new String[] {ifOperator}, StringSplitOptions.RemoveEmptyEntries);
            //MessageBox.Show(splittedIFCondition[0] + splittedIFCondition[1]);

            if (canvasObject.storeVariables.ContainsKey(splittedIFCondition[0]))
            {
                int variable = canvasObject.storeVariables[splittedIFCondition[0]];

                if (ifOperator == "==")
                {
                   // variable == Convert.ToInt32(splittedIFCondition[1]);
                }

            }
        }
    }
}
