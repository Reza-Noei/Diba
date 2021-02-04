using System;
using System.Collections.Generic;
using NFluent;
using Xunit;

namespace Diba.Core.Domain.Unit.Test.Model.Orders.States
{
    public class OrderStateTest_WhenBalanced
    {
        public OrderState _OrderState;
        public OrderStateTest_WhenBalanced()
        {
            _OrderState = new BalanacedState();
        }

        public static IEnumerable<object[]> InvalidStates()
        {
            return new List<Action<OrderState>[]>
            {
                new Action<OrderState>[] { a=> a.Calculate() },
                new Action<OrderState>[] { a=> a.Process() },

            };
        }

        [Theory]
        [MemberData(nameof(InvalidStates))]
        public void should_throw_on_transition_to_invalid_states(Action<OrderState> transition)
        {
            Check.ThatCode(() => transition(this._OrderState)).Throws<Exception>();
        }
    }
}