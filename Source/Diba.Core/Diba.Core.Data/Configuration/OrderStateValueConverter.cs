using System;
using System.Collections.Generic;
using System.Linq;
using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diba.Core.Data.Configuration
{
    public class OrderStateValueConverter : ValueConverter<OrderState, int>
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

        public OrderStateValueConverter(ConverterMappingHints mappingHints = null)
            : base(
                state => GetValue(state.GetType()),
                value => GetState(value),
                mappingHints
            )
        { }

        private static int GetValue(Type stateType)
        {
            return Values.First(a => a.Value == stateType).Key;
        }
        private static OrderState GetState(int value)
        {
            var type = Values[value];
            return Activator.CreateInstance(type) as OrderState;
        }
    }
}