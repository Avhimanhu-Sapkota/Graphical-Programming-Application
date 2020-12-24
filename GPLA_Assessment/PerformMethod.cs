using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPLA_Assessment
{
    class PerformMethod
    {
        public String methodName;
        String methodParameters;
        bool methodFlag = true;
        public ArrayList methodCommands = new ArrayList();
        public String[] splittedParameters;

        public bool identifyMethod (String enteredCode)
        {
            try
            {
                methodFlag = true;
                String[] splittedMethod = enteredCode.Split(' ');
                String[] splittedMethodExpression = splittedMethod[1].Split('(');

                methodName = splittedMethodExpression[0].Trim();
                methodParameters = enteredCode.Split('(', ')')[1].Trim();

                if (splittedMethod[0].Equals("method"))
                {
                    if (!methodParameters.Equals(""))
                    {
                        splittedParameters = methodParameters.Split(',');
                        
                        foreach (String eachParameter in splittedParameters)
                        {
                            Canvas.storeVariables.Add(eachParameter,0);
                        }
                    }
                }

            }
            catch (IndexOutOfRangeException)
            {

            }
            return methodFlag;
        }

        public bool storeMethodCommands(String enteredCode)
        {

            if (enteredCode.Equals("endmethod"))
            {
                methodFlag = false;
            }
            else
            {
                methodCommands.Add(enteredCode);
            }

            return methodFlag;
        }
    }
}
