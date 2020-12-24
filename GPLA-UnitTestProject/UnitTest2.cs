using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GPLA_Assessment;

namespace GPLA_UnitTestProject
{
    /// <summary>
    /// Performs Unit tests on:<br/>
    /// <list type="bullet"> <see cref="PerformIF.checkIfCommand(string, int)"/> method by passing command and
    /// checks if the if command is logically and syntactically correct with respect to expected result.  </list>
    ///<list type="bullet"> <see cref="PerformIF.checkIfCommand(string, int)"/> method by passing command and
    ///                         checks if the if command is logically and syntactically correct with respect to expected result.</list>
    /// <list type="bullet"><see cref="PerformLoop.checkLoopCommand(string)"/> method by passing command and
    ///                     checks if the while command if logicallay and syntactically correct with respect to exprected result.</list>
    /// <list type="bullet"><see cref="Canvas.programReader(string, int, bool)"/> method by passing commands.
    ///                     Checks if the passed codes are correct logically by checking on the values returned.</list>
    /// <list type="bullet"><see cref="Canvas.programReader(string, int, bool)"/> method by passing var command and
    ///                     checks if the data dictionary is functioning properly on the basis of entered code.</list>
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        /// <summary>
        /// Performs unit Test on <see cref="PerformIF.checkIfCommand(string, int)"/> method by passing command and
        /// checks if the if command is logically and syntactically correct with respect to expected result. 
        /// </summary>
        [TestMethod]

        public void TestIFCommand()
        {
            // Initializes all variables necessary to conduct tests. 
            String lineToPass = "if (100<200)";
            bool returnedOutput;

            // Initializes variable with expected outputs.
            bool expectedOutput = true;

            // Object of PerformIF class to access methods of PerformIF Class. 
            PerformIF testPerformIFObject = new PerformIF();

            // Calls the checkIfCommands method  which checks if condition is correct on the basis of syntax and logic.
            returnedOutput = testPerformIFObject.checkIfCommand(lineToPass, 1);

            // Performs unit test on areEqual tests using retrieved boolean value and expected results.
            Assert.AreEqual(expectedOutput, returnedOutput);
        }

        /// <summary>
        /// Performs unit test on <see cref="PerformLoop.checkLoopCommand(string)"/> method by passing while (150>120) as command and
        /// checks if the while command if logicallay and syntactically correct with respect to exprected result.
        /// </summary>
        [TestMethod]
        public void TestLoopCommand()
        {
            // Initializes all variables necessary to conduct tests.
            String lineToPass = "while (150>120)";
            bool returnedOutput;

            // Initializes variable with expected outputs.
            bool expectedOutput = true;

            // Object of PerformLoop class to access methods of PerformLoop class.
            PerformLoop testPerformIFObject = new PerformLoop();

            // Calls the checkLoopCommand method which checks if while condition is correct on the basis of syntax and logic.
            returnedOutput = testPerformIFObject.checkLoopCommand(lineToPass,1);

            // Performs unit test on areEqual test using retrieved boolean value and expected results.
            Assert.AreEqual(expectedOutput, returnedOutput);
        }

        /// <summary>
        /// Performs unit tests on <see cref="Canvas.programReader(string, int, bool)"/> method by passing commands. Checks if the passed codes are correct logically by checking on the values returned.
        /// </summary>
        [TestMethod]
        public void TestCommandName()
        {
            // Object of Canvas clas to access methods of Canvas class. 
            Canvas testCanvasObject = new Canvas();

            // Calls the programReader method which checks if the entered code encounters variable and changes the values inside it. 
            testCanvasObject.programReader("var x=100", 1, false);
            // Performs unit test on IsTrue by calling the variable within the Canvas class which must be triggered when var is entered as code.
            Assert.IsTrue(testCanvasObject.variableChecker);

            // Calls the programReader method which checks if the entered code encounters while and changes the values inside if the condition is true.
            testCanvasObject.programReader("while (100<200)", 1, false);
            // Performs  unit test on IsTrue by calling the variable within the Canvas class which must be triggered when loop condition is matched.
            Assert.IsTrue(testCanvasObject.loopConditionMatched);

            // Calls the programReader method which checks if the entered code encounters if and changes the values inside if the condition is true.
            testCanvasObject.programReader("if (199<200)", 1, false);
            // Performs unit test on IsFalse by calling the variable within the Canvas class which must be triggered when the if condition is not matched.
            Assert.IsFalse(testCanvasObject.conditionNotMatched);
        }

        /// <summary>
        /// Performs unit tests on <see cref="Canvas.programReader(string, int, bool)"/> method by passing 'var z=100' and
        /// checks if the data dictionary is functioning properly on the basis of entered code.
        /// </summary>
        [TestMethod]
        public void TestVariable()
        {
            // Object of Canvas clas to access methods of Canvas class. 
            Canvas testCanvasObject = new Canvas();

            // Initializes the code which is to be passed inside programReader method. 
            String enteredCommand = "var z=100";

            // Splits the enteredCommadn on the basis of <space> ' ' and stores in a string array.
            String[] splittedVariableExpression = enteredCommand.Split(' ');

            // Further splits the second part of the string with respect to '=' sign and stores in a new string array.
            String[] splittedVariable = splittedVariableExpression[1].Split('=');

            // Retrieves the supposed variable name from the splitted array string and stores into variableName. 
            String variableName = splittedVariable[0];
            // Retrieves the supposed variable value from the splitted array string and stores into variableValue.
            int variableValue = Convert.ToInt32(splittedVariable[1]);

            // Calls the programReader method and checks if the enteredcode triggers and add values to data dictionary.
            testCanvasObject.programReader(enteredCommand, 1, false);

            // Performs IsTrue unit test by checking if the variable name already exists in the dictionary.
            Assert.IsTrue(Canvas.storeVariables.ContainsKey(variableName));
            // Performs AreEqual unit test by checking if the variable name in dictionary has same value as expected variableValue.
            Assert.AreEqual(Canvas.storeVariables[variableName], variableValue);
        }

        /// <summary>
        /// Performs unit test on <see cref="PerformMethod.identifyMethod(string, bool)"/> method by passing 'method (l,m)' and 
        /// checks if the method returns true or false when method is correctly declared.
        /// </summary>
        [TestMethod]
        public void TestMethod()
        {
            // Creates object of PerformMethod class to access its methods.
            PerformMethod testMethodObject = new PerformMethod();

            // Initialized the string required to perform test.
            String enteredCode1 = "method (l,m)";
            String enteredCode2 = "endmethod";

            // Calls the identifyMethod and stores the returned value in boolean variable.
            bool expecetedOutput1 = testMethodObject.identifyMethod(enteredCode1, false,1);

            // Calls storeMethodCommands and stores the returned value in boolean variable.
            bool expectedOutput2 = testMethodObject.storeMethodCommands(enteredCode2);

            // Performs IsTrue unit test as the expected output has to be true.
            Assert.IsTrue(expecetedOutput1);

            // Performs IsFalse unit test as the expected output has to be false.
            Assert.IsFalse(expectedOutput2);
        }
    }
}
