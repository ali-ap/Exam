using Exam.Contract.Binding;
using FluentValidation;

namespace Exam.Contract.Validation
{
    public class ProductBindingModelValidator : AbstractValidator<ProductBindingModel>
    {
        public ProductBindingModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Sku).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }

}
