using System;
using Exam.Contract.Base;
using Exam.Contract.Validation;

namespace Exam.Contract.Binding
{
    public class ProductBindingModel : BindingModel<ProductBindingModel, ProductBindingModelValidator>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string RowVersion { get; set; }
    }
}
