using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public abstract class BaseServiceResult
    {
        public BaseMessage Message { get; set; }
        public List<ValidationError> ModelValidationErrors { get; set; }
        public StatusCode StatusCode { get; set; }
    }

    public class ServiceResult<T>: BaseServiceResult
    {
        public ServiceResult()
        {

        }

        public ServiceResult(T Data)
        {
            this.Data = Data;
            StatusCode = StatusCode.Ok;
        }

        public ServiceResult(T Data, StatusCode Code)
        {
            this.Data = Data;
            this.StatusCode = Code;
        }

        public ServiceResult(StatusCode Code, BaseMessage Message)
        {
            this.StatusCode = Code;
            this.Message = Message;
        }

        public ServiceResult(StatusCode Code)
        {
            this.StatusCode = Code;
        }

        public ServiceResult(StatusCode Code, BaseMessage Message, List<ValidationError> ValidationErrors)
        {
            this.Message = Message;
            this.ModelValidationErrors = ValidationErrors;
            this.StatusCode = Code;
        }

        public T Data { get; set; }
    }
}
