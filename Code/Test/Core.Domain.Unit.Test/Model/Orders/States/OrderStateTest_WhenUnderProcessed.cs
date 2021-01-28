using System;
using System.Collections.Generic;
using NFluent;
using Xunit;

namespace Diba.Core.Domain.Unit.Test.Model.Orders.States
{
    public class OrderStateTest_WhenUnderProcessed
    {
        public OrderState _OrderState;
        public OrderStateTest_WhenUnderProcessed()
        {
            _OrderState = new UnderProcessedState();
        }
        public static IEnumerable<object[]> ValidStates()
        {
            return new List<object[]>
            {
                new object[] { new Func<OrderState,OrderState>(a=> a.Deliver()), typeof(DeliverdState) },
            };
        }

        [Theory]
        [MemberData(nameof(ValidStates))]
        public void should_transit_to_valid_states(Func<OrderState, OrderState> transition, Type typeOfExpectedState)
        {
            this._OrderState = transition.Invoke(this._OrderState);

            Check.That(this._OrderState).IsInstanceOfType(typeOfExpectedState);
        }

        public static IEnumerable<object[]> InvalidStates()
        {
            return new List<Action<OrderState>[]>
            {
                new Action<OrderState>[] { a=> a.Calculate() },
                new Action<OrderState>[] { a=> a.Balance() },
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