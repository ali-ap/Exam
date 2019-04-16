namespace Exam.Exception.Base
{
    public abstract class BaseException : System.Exception
    {
        protected BaseException()
           : base() { }

        protected BaseException(string message)
           : base(message) { }

        protected BaseException(string format, params object[] args)
           : base(string.Format(format, args)) { }

        protected BaseException(string message, System.Exception innerException)
           : base(message, innerException) { }

        protected BaseException(string format, System.Exception innerException, params object[] args)
           : base(string.Format(format, args), innerException) { }
    }
}
