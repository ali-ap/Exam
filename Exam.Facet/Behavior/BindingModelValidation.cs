using System;
using System.Diagnostics;
using System.Linq;
using MethodBoundaryAspect.Fody.Attributes;

namespace Exam.Facet.Behavior
{
    public sealed class BindingModelValidation : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.Arguments.ToList().ForEach(x =>
            {
                if (x.GetType().Namespace.StartsWith("Exam.Contract.Binding"))
                    x.GetType().GetMethod("Validate")?.Invoke(x, new[] { x });
            });
        }

        public override void OnExit(MethodExecutionArgs args)
        {
        }


        public override void OnException(MethodExecutionArgs args)
        {
        }
    }
}
