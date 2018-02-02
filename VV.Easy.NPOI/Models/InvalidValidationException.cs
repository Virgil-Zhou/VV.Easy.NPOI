using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Models
{
    public class InvalidValidationException : Exception
    {
        public InvalidValidationException()
        {

        }

        public InvalidValidationException(string message) : base(message)
        {

        }

        public InvalidValidationException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public InvalidValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
