using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPLA_Assessment;
using System;
using System.Drawing;

namespace GPLA_Unit_Test
{
    /// <summary>
    /// Performs Unit tests on:
    /// <list type="bullet"><see cref="Canvas.CommandSplitter"/> method by passing 'Pen 100,100' as command. Checks if the splitted commands are equal to the expected result.</list>
    /// <list type="bullet"><see cref="Canvas.ParameterSplitter"/> method by passing '150,200' as command. Checks if the splitted parameters are equal to the expected results.</list>
    /// <list type="bullet"><see cref="Canvas.programReader(string, int)"/> method by passing 'pen red' to see if the penColor will be changed to 'red'</list>
    /// <list type="bullet"><see cref="Canvas.programReader(string, int)"/> method by passing 'fill on' to see if the fill will be changed to 'true' </list>
    /// <list type="bullet"><see cref="ShapeFactory.getShape(string)"/> method by passing 'rectangle', 'circle' and 'triangle' as commands simultaneously.
    ///                                 Checks if the command entered are valid shapes.</list>
    /// <list type="bullet"><see cref="Form1.programReader(string)"/> method by passing invalid command 'Square' to see if the method throws any error. 
    ///                                 Checks if the method throws the desired error.</list>
    /// <list type="bullet"><see cref="Form1.programReader(string)"/> method by passing invalid command 'Rectangle 10' to see if the method throws any error. 
    ///                                 Checks if the method throws the desired error. </list>
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Performs unit Test on <see cref="Canvas.CommandSplitter"/> method by passing 'Pen 100,100' as command and 
        /// Checks if the splitted commands are equal to the expected result.
        /// </summary>
        [TestMethod]
        public void TestCommandSplitter()
        {
            /*
             * Initializes all variables necessary to conduct tests.
             */
            String command;
            String parameters;
            String[] testSplittedCommand;

            /*
             * Initializes variables with expected Outputs.
             */
            String expectedCommand = "Pen";
            String expectedParameters = "100,100";

            // Object of Canvas class to access methods of Canvas Class.
            Canvas testCanvasObject = new Canvas();

            // Calls the CommandSplitter method which splits the enteredCode before and after a space then stores in the string array.
            testSplittedCommand = testCanvasObject.CommandSplitter("Pen 100,100");

            /* 
             * Stores the retrieved data in separate string variables to perform tests separately.
             */
            command = testSplittedCommand[0];
            parameters = testSplittedCommand[1];

            /*
             * Performs Unit Tests on areEqual tests using retrieved strings and expected results.
             */
            Assert.AreEqual(command, expectedCommand);
            Assert.AreEqual(parameters, expectedParameters);
        }

        /// <summary>
        /// Performs unit Test on <see cref="Canvas.ParameterSplitter"/> method by passing '150,200' as command and 
        /// Checks if the splitted parameters are equal to the expected results.
        /// </summary>
        [TestMethod]
        public void TestParameterSplitter()
        {
            /*
             * Initializes all variables necessary to conduct tests.
             */
            int parameter1;
            int parameter2;
            String[] testSplittedParameter;

            /*
             * Initializes variables with expected Outputs.
             */
            int expectedParameter1 = 150;
            int expectedParameter2 = 220;

            // Object of Canvas class to access methods of Canvas Class.
            Canvas testCanvasObject = new Canvas();

            /*
             * Calls the ParameterSplitter method which splits the parameters entered before and after a comma. 
             * Retrieves the string value, converts to integer and stores in an integer variable.
             */
            testSplittedParameter = testCanvasObject.ParameterSplitter("150,220");
            parameter1 = Convert.ToInt32(testSplittedParameter[0]);
            parameter2 = Convert.ToInt32(testSplittedParameter[1]);

            /*
             * Performs Unit Tests on areEqual tests using retrieved strings and expected results.
             */
            Assert.AreEqual(parameter1, expectedParameter1);
            Assert.AreEqual(parameter2, expectedParameter2);
        }

        /// <summary>
        /// Performs unit Test on <see cref="Canvas.programReader(string, int)"/> method by passing 'pen red' to see if the penColor will be changed accordingly and 
        /// Checks if the method changes the color of pen as desired.
        /// </summary>
        [TestMethod]
        public void TestPenColor()
        {
            // Initializes variable with expected Output.
            Color expectedColor = Color.Red;

            // Object of Canvas class to access methods of Canvas Class.
            Canvas testCanvasObject = new Canvas();

            // Calls programReader method by passing 'pen red', '1' and 'false' as parameters which is supposed to change the color of pen to 'Red'
            testCanvasObject.programReader("pen red", 1, false);

            // Performs Unit Tests on areEqual tests using retrieved color of pen and expected color.
            Assert.AreEqual(testCanvasObject.penColor, expectedColor);
        }

        /// <summary>
        /// Performs unit Test on <see cref="Canvas.programReader(string, int)"/> method by passing 'fill on' to see if the fill will be changed accordingly and 
        /// Checks if the method changes the boolean value of fill as desired.
        /// </summary>
        [TestMethod]
        public void TestFillOption()
        {
            // Initializes variable with expected Output.
            bool expectedOutput = true;

            // Object of Canvas class to access methods of Canvas Class.
            Canvas testCanvasObject = new Canvas();

            // Calls programReader method by passing 'fill on', '1' and 'false' as parameters which is supposed to change the boolean value of fill to 'true'
            testCanvasObject.programReader("fill on", 1, false);

            // Performs Unit Tests on areEqual tests using retrieved boolean value and expected boolean value.
            Assert.AreEqual(testCanvasObject.fill, expectedOutput);
        }

        /// <summary>
        /// Performs unit Test on <see cref="ShapeFactory.getShape(string)"/> method by passing 'rectangle', 'circle' and 'triangle' as commands simultaneously and 
        /// Checks if the command entered are valid shapes.
        /// </summary>
        [TestMethod]
        public void TestShapeFactory()
        {
            // Object of ShapeFactory class to access the method of ShapeFactory Class.
            ShapeFactory testSFObject = new ShapeFactory();

            /*
            * Calls getShape method of ShapeFactory with 'rectangle' as parameter and retrieves the name of object and saves it into an object of Shape class.
            * Calls the method of Shape class which sets the value as entered, which, if equal later in test, confirms that the entered shape is a valid shape.
            */
            Shape testShape1 = testSFObject.getShape("rectangle");
            testShape1.setX(100);

            /*
            * Calls getShape method of ShapeFactory with 'circle' as parameter and retrieves the name of object and saves it into an object of Shape class.
            * Calls the method of Shape class which sets the value as entered, which, if equal later in test, confirms that the entered shape is a valid shape.
            */
            Shape testShape2 = testSFObject.getShape("circle");
            testShape2.setX(50);

            /*
            * Calls getShape method of ShapeFactory with 'circle' as parameter and retrieves the name of object and saves it into an object of Shape class.
            * Calls the method of Shape class which sets the value as entered, which, if equal later in test, confirms that the entered shape is a valid shape.
            */
            Shape testShape3 = testSFObject.getShape("triangle");
            testShape3.setX(200);

            /*
             * Performs Unit Tests on areEqual tests using retrieved results and expected results.
             */
            Assert.AreEqual(testShape1.getX(), 100);
            Assert.AreEqual(testShape2.getX(), 50);
            Assert.AreEqual(testShape3.getX(), 200);
        }

        /// <summary>
        /// Performs unit Test on <see cref="Form1.programReader(string)"/> method by passing invalid command 'Square' to see if the method throws any error and 
        /// Checks if the method throws the desired error.
        /// </summary>
        [TestMethod]
        public void TestErrorMessage1()
        {

            // Initializes variable with expected Output.
            String expectedError = "ERROR!!! AT LINE 1. Please Enter Valid Command.";

            // Object of Form1 class to access methods of Form1 Class.
            Form1 testFormObject = new Form1();

            // Object of Canvas class to access methods of Canvas Class.
            Canvas testCanvasObject = new Canvas();

            // Calls programReader methods by passing 'Square' as the parameter, which is supposed to add error to the arrayList: errorList.
            testFormObject.programReader("Square");

            /*
            * Iterates to retrieve the contents of ArrayList: errorList created in the Canvas class and performs the test.
            */
            foreach (String eachError in testCanvasObject.errorList)
            {
                // Performs Unit Tests on areEqual tests using retrieved error and expected error.
                Assert.AreEqual(eachError, expectedError);
            }
        }

        /// <summary>
        /// Performs unit Test on <see cref="Form1.programReader(string)"/> method by passing invalid command 'Rectangle 10' to see if the method throws any error and 
        /// Checks if the method throws the desired error.
        /// </summary>
        [TestMethod]
        public void TestErrorMessage2()
        {
            // Initializes variable with expected Output.
            String expectedError = "ERROR!!! AT LINE 1. Please Enter Two Numeric Values for coordinates.";

            // Object of Form1 class to access methods of Form1 Class.
            Form1 testFormObject = new Form1();

            // Object of Canvas class to access methods of Canvas Class.
            Canvas testCanvasObject = new Canvas();

            // Calls programReader methods by passing 'Rectangle' as the parameter, which is supposed to add error to the arrayList: errorList.
            testFormObject.programReader("Rectangle 10");

            /*
            * Iterates to retrieve the contents of ArrayList: errorList created in the Canvas class and performs the test.
            */
            foreach (String eachError in testCanvasObject.errorList)
            {
                // Performs Unit Tests on areEqual tests using retrieved error and expected error.
                Assert.AreEqual(eachError, expectedError);
            }
        }
    }
}