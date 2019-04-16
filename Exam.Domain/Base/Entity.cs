using System;
using System.ComponentModel.DataAnnotations;

namespace Exam.Domain.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
