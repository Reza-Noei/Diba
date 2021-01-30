namespace Diba.Core.Domain
{
    public interface IServiceVisitor
    {
        void Visit(TransportationService transportationService);
        void Visit(CarpetCleaningService carpetCleaningService);
        void Visit(UnclearService unclearService);
    }
}