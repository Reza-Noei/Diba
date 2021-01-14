namespace Diba.Core.Domain
{
    public class UnderProcessedState : OrderState
    {
        public override bool CanModify()
        {
            return true;
        }

        public override OrderState Deliver()
        {
            return new DeliverdState();
        }
    }
}