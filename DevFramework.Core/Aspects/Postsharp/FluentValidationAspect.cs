using FluentValidation;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp
{
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
        }
    }
}
