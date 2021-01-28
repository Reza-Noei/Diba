namespace Diba.Core.Domain
{
    public class CalculatedState : OrderState
    {
        public override bool CanModify()
        {
            return true;
        }

        public override OrderState Process()
        {
            return new UnderProcessedState();
        }
    }
}