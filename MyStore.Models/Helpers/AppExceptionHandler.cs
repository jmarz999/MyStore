using System;
using System.Globalization;

namespace MyStore.Helpers
{
    public class AppExceptionHandler : Exception
    {
        public AppExceptionHandler() : base() { }
        public AppExceptionHandler(string message) : base(message) { }
        public AppExceptionHandler(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
