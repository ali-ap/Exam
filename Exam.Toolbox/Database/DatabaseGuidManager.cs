using System;

namespace Exam.Toolbox.Database
{
    public sealed class DatabaseGuidManager
    {
        private static volatile DatabaseGuidManager _instance;
        private static readonly object Lock = new object();
        private DatabaseGuidManager() { }
        public static DatabaseGuidManager GetInstance()
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    if (_instance == null)
                        _instance = new DatabaseGuidManager();
                }
            }
            return _instance;
        }

        public Guid GetGuid => Guid.NewGuid();
    }
}
