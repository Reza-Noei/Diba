﻿namespace Diba.Core.AppService.Contract.ProductConstraint.Model.ViewModel
{
    public class ProductStringConstraintsViewModel//: ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MaxLength { get; set; }
        public string Format { get; set; }
    }
}