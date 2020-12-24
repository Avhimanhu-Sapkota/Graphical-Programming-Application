using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLA_Assessment
{
    /// <summary>
    /// InvalidCommand class which extends Exception class. Used to throw user defined error which can be caught later.
    /// </summary>
    public class InvalidCommand: Exception
    {
        /// <summary>
        ///  Default constructor.
        /// </summary>
        public InvalidCommand()
        {

        }

        /// <summary>
        /// Method triggered when throws InvalidCommand is entered in the program.
        /// </summary>
        /// <param name="message"> The error message typed along when the error is actually encountered.</param>
        public InvalidCommand(String message): base(message)
        {

        }
    }
}
