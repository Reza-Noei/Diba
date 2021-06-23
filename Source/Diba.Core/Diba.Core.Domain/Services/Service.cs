using System;
using System.Collections.Generic;
using Diba.Core.Domain.DomainService;
using Diba.Core.Domain.Products;

namespace Diba.Core.Domain
{
    public class Service
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public int ProductId { get; private set; }

        public virtual Product Product { get; set; }


        private Dictionary<long, decimal> _feeByBrand;

        public virtual IReadOnlyDictionary<long, decimal> FeeByBrand => _feeByBrand;

        public Service()
        {
            _feeByBrand = new Dictionary<long, decimal>();
        }

        public Service(int id, string title, int productId)
        {
            Id = id;
            Title = title;
            ProductId = productId;
            _feeByBrand = new Dictionary<long, decimal>();
        }

        public void ModifyFeeByBrands(Dictionary<long, decimal> feeByBrands, IServiceDomainService domainService)
        {
            foreach (var entry in feeByBrands)
            {
                GuardAgainstWrongSelectedBrand(entry.Key, domainService);

                this.ModifyFeeByBrand(entry.Key, entry.Value);
            }
        }

        public void ModifyFeeByBrand(long brandId, decimal fee)
        {
            if (this._feeByBrand.ContainsKey(brandId))
            {
                this._feeByBrand[brandId] = fee;
            }
            else
            {
                this._feeByBrand.Add(brandId, fee);
            }
        }

        public decimal GetFeeByBrand(long brandId)
        {
            if (!this._feeByBrand.ContainsKey(brandId)) throw new Exception();
            return this._feeByBrand[brandId];
        }

        private static void GuardAgainstWrongSelectedBrand(long brandId, IServiceDomainService domainService)
        {
            if (!domainService.IsBrandExist(brandId)) throw new Exception();
        }
    }
}