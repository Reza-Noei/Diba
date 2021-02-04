namespace Diba.Core.Domain
{
    public class RequestedState : OrderState
    {

        public override bool DelivelerCanModify()
        {
            return true;
        }

        public override bool CollectorCanModify()
        {
            return true;
        }

        public override OrderState Collect()
        {
            return new CollectedState();
        }

        public override OrderState Cancel()
        {
            return new CancelledState();
        }
    }
}