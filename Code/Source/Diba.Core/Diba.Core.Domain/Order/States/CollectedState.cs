namespace Diba.Core.Domain
{
    public class CollectedState : OrderState
    {
        public override bool CanModify()
        {
            return true;
        }

        public override OrderState Calculate()
        {
            return new CalculatedState();
        }
    }
}