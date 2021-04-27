using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.Domain;

namespace Diba.Core.AppService.Order
{
    public class OrderMappingConfig : Profile
    {
        public OrderMappingConfig()
        {
            CreateMap<OrderState, int>().ConvertUsing(new OrderStateTypeConverter()); ;
            CreateMap<Domain.Order, OrderViewModel>();
            CreateMap<OrderViewModel, Domain.Order>();

            CreateMap<CreateOrderInputModel, Domain.Order>();
            CreateMap<Domain.Order, CreateOrderInputModel>();

            CreateMap<OrderItemViewModel, OrderItem>();
            CreateMap<OrderItem, OrderItemViewModel>();

            CreateMap<OrderItemsViewModel, List<OrderItem>>();
            CreateMap<List<OrderItem>, OrderItemsViewModel>();

        }
    }
    public class OrderStateTypeConverter : ITypeConverter<OrderState, int>
    {
        private static readonly Dictionary<int, Type> Values = new Dictionary<int, Type>()
        {
            {1, typeof(RequestedState)},
            {2, typeof(CollectedState)},
            {3, typeof(CalculatedState)},
            {4, typeof(ProcessedState)},
            {5, typeof(DeliverdState)},
            {6, typeof(BalanacedState)},
        };

        public int Convert(OrderState source, int destination, ResolutionContext context)
        {
            return Values.First(a => a.Value == source.GetType()).Key;
        }
    }

}