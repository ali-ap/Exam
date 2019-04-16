using Exam.Exception.Base;

namespace Dong.Framework.Exception.Core
{
    public class BindingModelValidationException : BaseException
    {
        private readonly string _message;

        public BindingModelValidationException(string message) : base(message)
        {
            _message = message;
        }
    }
}