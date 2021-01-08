using System;

namespace Diba.Core.Domain
{
    public abstract class OrderState
    {
        public virtual bool CanModify()
        {
            return false;
        }

        public virtual OrderState Cancel()
        {
            throw new NotSupportedException();
        }

        public virtual OrderState Confirm()
        {
            throw new NotSupportedException();
        }
    }

    public class ConfirmedState : OrderState
    {
    }
    public class CancelledState : OrderState
    {
    }

    public class DraftState : OrderState
    {
        public override bool CanModify()
        {
            return true;
        }

        public override OrderState Cancel()
        {
            return new CancelledState();
        }

        public override OrderState Confirm()
        {
            return new ConfirmedState();
        }
    }
}