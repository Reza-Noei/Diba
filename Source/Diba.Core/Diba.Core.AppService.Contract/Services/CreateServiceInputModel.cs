using System.Collections.Generic;

namespace Diba.Core.AppService.Contract.Services
{
    public class CreateServiceInputModel
    {
        public string Title { get; set; }

        public Dictionary<long, decimal> FeeByBrand { get; set; }

        public int ProductId { get; set; }
    }
}