namespace Diba.Core.Domain
{
    public class DeliverdState : OrderState
    {
        public override bool ItemsCanModify()
        {
            return true;
        }

        public override OrderState Balance()
        {
            return new BalanacedState();
        }
    }
}