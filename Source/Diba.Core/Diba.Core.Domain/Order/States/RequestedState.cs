namespace Diba.Core.Domain
{
    public class RequestedState : OrderState
    {

        public override bool DeliveryInfoCanModify()
        {
            return true;
        }

        public override bool CollectionInfoCanModify()
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