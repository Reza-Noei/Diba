namespace Diba.Core.Domain
{
    public class CalculatedState : OrderState
    {
        public override bool ItemsCanModify()
        {
            return true;
        }

        public override bool DelivelerCanModify()
        {
            return true;
        }

        public override OrderState Process()
        {
            return new ProcessedState();
        }
    }
}