using Exam.Exception.Base;

namespace Exam.Exception.Core
{
    public class ObjectNotFoundException : BaseException
    {
        private readonly string _message;

        public ObjectNotFoundException(string message) : base(message)
        {
            _message = message;
        }
    }
}