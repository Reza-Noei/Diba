namespace Diba.Core.Domain
{
    public class CollectedState : OrderState
    {
        public override bool ItemsCanModify()
        {
            return true;
        }

        public override bool DelivelerCanModify()
        {
            return true;
        }

        public override OrderState Calculate()
        {
            return new CalculatedState();
        }
    }
}