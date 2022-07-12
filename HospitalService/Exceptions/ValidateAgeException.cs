using System;

namespace HospitalService.Exceptions
{
    public class ValidateAgeException : Exception
    {
        public ValidateAgeException() { }
        public ValidateAgeException(string message) : base(message) { }
    }
}
