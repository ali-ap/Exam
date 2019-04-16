using Exam.Exception.Base;

namespace Exam.Exception.Core
{
    public class UpdateLostException : BaseException
    {
        private readonly string _message;


        public UpdateLostException(string message) : base(message)
        {
            _message = message;
        }
    }
}