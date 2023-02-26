using System.Globalization;
using agrconclude.Domain.Models;

namespace agrconclude.Domain.Exceptions
{
    public class AppException : Exception
    {
        public IEnumerable<ErrorMessage>? ErrorMessages { get; private set; }

        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        public AppException(IEnumerable<ErrorMessage>? errorMessages) : base()
        {
            ErrorMessages = errorMessages;
        }
    }
}
