namespace Diba.Core.Domain
{
    public class ProcessedState : OrderState
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