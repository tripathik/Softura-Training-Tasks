using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementBLLibrary
{
    public class UnabletoAddEmployeeException : ApplicationException
    {
        string _message;
        public UnabletoAddEmployeeException()
        {
            _message = "Unable to Add employee cod of Id duplication. Please Try again!!!";
        }
        public override string Message => _message;
    }
}
