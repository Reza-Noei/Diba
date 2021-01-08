namespace Diba.Core.Domain
{
    public class FinalFeeVisitor : IServiceVisitor
    {
        private decimal _fee = 0;

        public void Visit(TransportationService transportationService)
        {
            _fee += transportationService.Fee;
        }

        public void Visit(CarpetCleaningService carpetCleaningService)
        {
            _fee += carpetCleaningService.Fee;

        }

        public void Visit(UnclearService unclearService)
        {
            _fee += unclearService.Fee.HasValue ? (decimal)unclearService.Fee : 0;
        }

        public decimal GetFinalFee()
        {
            return _fee;
        }
    }
}