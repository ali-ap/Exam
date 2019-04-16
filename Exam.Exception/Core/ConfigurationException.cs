using Exam.Exception.Base;

namespace Dong.Framework.Exception.Core
{
    public class ConfigurationException : BaseException
    {
        private readonly string _message;

        public ConfigurationException(string message) : base(message)
        {
            _message = message;
        }
    }
}