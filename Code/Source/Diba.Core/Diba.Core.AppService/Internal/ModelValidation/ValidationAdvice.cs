//using ArxOne.MrAdvice.Advice;
//using Diba.Core.AppService.Contract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;

//namespace Diba.Core.AppService.ModelValidation
//{
//    public class ValidationAdvice : Attribute, IMethodAdvice
//    {
//        readonly bool validateAllProperties;

//        public ValidationAdvice(bool validateAllProperties = true)
//        {
//            this.validateAllProperties = validateAllProperties;
//        }

//        public void Advise(MethodAdviceContext context)
//        {
//            Type returnType = (context.TargetMethod as MethodInfo).ReturnType;

//            if (!IsSubclassOfRawGeneric(typeof(ServiceResult<>), returnType))
//                throw new Exception("ValidationAdvice should only use at service methods with subclass of ResponseBase return type.");

//            if (context.Arguments.Count != 1)
//                throw new Exception("Service methods should have one and only one argument as subclass of RequestBase");

//            object requestObject = context.Arguments[0];

//            //if (!requestObject.GetType().GetInterfaces().Contains(typeof(IRequest)))
//            //    throw new Exception("Service methods should have one and only one argument as subclass of RequestBase");

//            //IList<ValidationResult> invalidItems = new List<ValidationResult>();

//            //bool objectIsvalid = Validator.TryValidateObject(requestObject, new ValidationContext(requestObject, null, null), invalidItems, validateAllProperties);

//            //if (!objectIsvalid)
//            //{
//            //    object instance = Activator.CreateInstance(returnType);
//            //    (instance as BaseServiceResult).StatusCode = StatusCode.BadRequest;
//            //    (instance as BaseServiceResult).ModelValidationErrors = invalidItems.ToList().Select(P => new ValidationError(P.ErrorMessage)).ToList();
//            //    context.ReturnValue = instance;
//            //}
//            //else
//                context.Proceed();
//        }

//        static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
//        {
//            while (toCheck != null && toCheck != typeof(object))
//            {
//                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
//                if (generic == cur)
//                {
//                    return true;
//                }
//                toCheck = toCheck.BaseType;
//            }
//            return false;
//        }
//    }
//}
