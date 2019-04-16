using System;
using System.Linq;
using Dong.Framework.Exception.Core;
using FluentValidation;
using FluentValidation.Results;

namespace Exam.Contract.Base
{
    public abstract class BindingModel<TModel, TValidator> where TModel : class
        where TValidator : AbstractValidator<TModel>
    {
        public ValidationResult Validate(TModel instance)
        {
            var errorMessage = "";
            var validatorResult = ((AbstractValidator<TModel>)Activator.CreateInstance(typeof(TValidator))).Validate(instance);
            if (!validatorResult.IsValid)
            {
                validatorResult.Errors.ToList().ForEach(x => errorMessage = $"{errorMessage} /n {x.ErrorMessage}");
                throw new BindingModelValidationException(errorMessage);
            }
            return validatorResult;
        }

    }
}
