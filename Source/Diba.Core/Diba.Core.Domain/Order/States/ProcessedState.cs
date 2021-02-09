namespace Diba.Core.Domain
{
    public class ProcessedState : OrderState
    {
        public override bool ItemsCanModify()
        {
            return true;
        }

        public override bool DeliveryInfoCanModify()
        {
            return true;
        }

        public override OrderState Deliver()
        {
            return new DeliverdState();
        }
    }
}