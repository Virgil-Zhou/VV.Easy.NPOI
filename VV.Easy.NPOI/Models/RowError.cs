using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Models
{
    public class RowError
    {
        public RowError(string errorMessage)
        {
            ErrorMessage = errorMessage ?? "";
        }

        public RowError(Exception exception) : this(exception.Message, exception)
        {

        }

        public RowError(string errorMessage, Exception exception) : this(errorMessage)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }

        public string ErrorMessage { get; }

        public Exception Exception { get; }
    }
}
