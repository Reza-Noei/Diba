using System;
using System.Collections.Generic;

namespace Diba.Core.Domain
{
    public class Service
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public int ProductId { get; private set; }

        private readonly Dictionary<long, decimal> _feeByBrand;

        public Service(int id, string title, int productId)
        {
            Id = id;
            Title = title;
            ProductId = productId;
            _feeByBrand = new Dictionary<long, decimal>();
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
    }
}