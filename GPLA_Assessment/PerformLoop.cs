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
    class PerformLoop
    {
        ArrayList loopCommands = new ArrayList();
        bool loopConditionFlag = false;
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
            String[] splittedLoopCondition = loopCondition.Split(new String[] { loopOperator }, StringSplitOptions.RemoveEmptyEntries);

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

        public bool executeLoop(bool whileFlag, bool loopConditionMatched, String whileCommand, String enteredCode, int lineCounter, bool syntaxButton, ArrayList canvasList)
        {
            if (enteredCode.Equals("endloop"))
            {
                if (loopConditionMatched)
                {
                    runLoop(lineCounter, syntaxButton, whileCommand, canvasList);
                    loopCommands.Clear();
                    whileFlag = false;
                }
                else
                {
                    loopCommands.Clear();
                    whileFlag = false;
                }
            }
            else
            {
                loopCommands.Add(enteredCode);
            }

            return whileFlag;
        }

        public void runLoop(int lineCounter, bool syntaxButton, String whileCommand, ArrayList canvasList)
        {
            
            Canvas canvasObject = new Canvas();
            canvasObject.g = (Graphics)canvasList[0];
            canvasObject.pointX = (int)canvasList[1];
            canvasObject.pointY = (int)canvasList[2];
            canvasObject.pen = (Pen)canvasList[3];

            loopConditionFlag = true;

            while (loopConditionFlag)
            {
                foreach (String item in loopCommands)
                {
                    //MessageBox.Show(" " + item);
                    canvasObject.programReader(item, lineCounter, syntaxButton);
                }

                loopConditionFlag = checkLoopCommand(whileCommand);
            }
        }
    }
}
