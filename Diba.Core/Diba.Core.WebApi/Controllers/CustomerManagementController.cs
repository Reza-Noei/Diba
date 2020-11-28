using System.Collections.Generic;
using Diba.Core.AppService;
using Diba.Core.AppService.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerManagementController : Controller
    {
        private readonly ICustomerManagementCommand _customerManagementCommand;
        private readonly ICustomerManagementQuery _customerManagementQuery;

        public CustomerManagementController(ICustomerManagementCommand customerManagementCommand,
                                            ICustomerManagementQuery customerManagementQuery)
        {
            _customerManagementCommand = customerManagementCommand;
            _customerManagementQuery = customerManagementQuery;
        }

        /// <summary>
        /// ایجاد مشتری
        /// </summary>
        /// <param name="request">درخواست</param>
        /// <returns>مشتری ایجاد شده</returns>
        [HttpPost]
        public ServiceResult<CustomerViewModel> Post(CreateCustomerInputModel request)
        {
            return _customerManagementCommand.Create(request);
        }

        /// <summary>
        /// ایجاد مشتری
        /// </summary>
        /// <param name="request">درخواست</param>
        /// <returns>مشتری ایجاد شده</returns>
        [HttpGet]
        public ServiceResult<IEnumerable<CustomerViewModel>> Get()
        {
            return _customerManagementQuery.Search(new CustomerSearchInputModel()
            {
                Query = ""
            }) ;
        }
    }
}