using System;
using Exam.Domain.Base;

namespace Exam.Domain.Model
{
    public class Product : Aggregate
    {
        public string Name { get; set; }
        public string StockKeepingUnit { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
