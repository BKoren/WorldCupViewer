using System;

namespace WorldCup.DataLayer.Exceptions
{
    public class ExceptionProcessor
    {
        private static string message;

        private static bool reset = false;

        public static string ProcessException(Exception error)
        {
            if (error == null)
                return null;

            if (reset)
                message = string.Empty;

            reset = false;

            Exception innerException = error.InnerException;

            if (innerException != null)
            {                
                message += $"\nAdditional information: " + $"{innerException.Message}\n";                
                ProcessException(innerException);
            }

            reset = true;

            return message;
        }

    }
}
