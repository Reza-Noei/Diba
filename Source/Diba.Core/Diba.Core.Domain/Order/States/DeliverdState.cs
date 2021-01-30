namespace Diba.Core.Domain
{
    public class DeliverdState : OrderState
    {
        public override bool CanModify()
        {
            return true;
        }

        public override OrderState Balance()
        {
            return new BalanacedState();
        }
    }
}