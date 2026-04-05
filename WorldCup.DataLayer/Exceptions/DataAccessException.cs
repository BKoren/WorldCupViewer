using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.DataLayer.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message) : base(message) 
        
        { }

        public DataAccessException(
            string description,
            string solution = null,
            string consequences = null,
            string action = null,
            Exception innerException = null)
            
            : base($"Error description: {description}\n" + 

                  (string.IsNullOrEmpty(solution) ? "" : 
                   $"Solution: {solution}\n") + 

                  (string.IsNullOrEmpty(consequences) ? "" :
                   $"Consequences: {consequences}\n") +

                  (string.IsNullOrEmpty(action) ? "" :
                   $"Action: {action}\n"),
                   innerException
            )

        { }
    }
}
