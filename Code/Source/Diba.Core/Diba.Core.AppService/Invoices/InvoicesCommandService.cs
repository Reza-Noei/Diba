using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diba.Core.AppService.Invoices
{
    public class InvoicesCommandService : IInvoicesCommandService
    {
        public InvoicesCommandService(IInvoiceRepository invoiceRepository,
                                      ICustomerMembershipRepository customerMembershipRepository,
                                      IDeliveryMembershipRepository deliveryMembershipRepository,
                                      ICollectorMembershipRepository collectorMembershipRepository,
                                      IQuickAccessListRepository quickAccessListRepository,
                                      IQNameRepository qnameRepository,
                                      ISecretaryMembershipRepository secretaryMembershipRepository,
                                      IUnitOfWork unitOfWork,
                                      IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _customerMembershipRepository = customerMembershipRepository;
            _deliveryMembershipRepository = deliveryMembershipRepository;
            _collectorMembershipRepository = collectorMembershipRepository;
            _quickAccessListRepository = quickAccessListRepository;
            _secretaryMembershipRepository = secretaryMembershipRepository;

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ServiceResult<InvoiceShortViewModel> Create(CreateInvoiceInputModel request)
        {
            var customer = _customerMembershipRepository.GetById(request.CustomerMembershipId);
            if (customer == null)
                return new ServiceResult<InvoiceShortViewModel>(StatusCode.NotFound);

            var secretary = _secretaryMembershipRepository.GetMany(P => P.Id == request.SecretaryId).FirstOrDefault();
            if (secretary == null)
                return new ServiceResult<InvoiceShortViewModel>(StatusCode.Forbidden);

            Invoice invoice = new Invoice()
            {
                SerialNumber = request.SerialNumber,
                EarnestMoney = request.EarnestMoney,
                State = InvoiceState.Reception
            };

            if (request.Orders.Count() > 0)
            {
                invoice.State = InvoiceState.Scheduled;

                var ServiceTypes = _quickAccessListRepository.GetMany(P => P.Type == Domain.QuickAccessListType.ServiceType).FirstOrDefault();
                var Metrics = _quickAccessListRepository.GetMany(P => P.Type == Domain.QuickAccessListType.Metric).FirstOrDefault();

                var ServiceTypeQNames = ServiceTypes.Items.ToList();
                var MetricQNames = ServiceTypes.Items.ToList();

                foreach (var order in request.Orders)
                {
                    if (!MetricQNames.Any(P => P.Id == order.UnitId))
                        return new ServiceResult<InvoiceShortViewModel>(StatusCode.BadRequest);

                    if (!ServiceTypeQNames.Any(P => P.Id == order.ServiceTypeId))
                        return new ServiceResult<InvoiceShortViewModel>(StatusCode.BadRequest);

                    invoice.Orders.Add(new CustomerOrder()
                    {
                       ServiceDescription = order.ServiceDescription,
                       Count = order.Count,
                       Tax = order.Tax,                       
                       PaymentType = (Domain.PaymentType)order.PaymentType,
                       PricePerUnit = order.PricePerUnit,
                       Discount = order.Discount,
                       UnitId = order.UnitId,
                       ServiceTypeId = order.ServiceTypeId                       
                    });
                }
            }

            _invoiceRepository.Add(invoice);
            _unitOfWork.Commit();

            return new ServiceResult<InvoiceShortViewModel>()
            {
                Data = _mapper.Map<InvoiceShortViewModel>(invoice),
                StatusCode = StatusCode.Created
            };
        }

        public ServiceResult<InvoiceShortViewModel> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<InvoiceShortViewModel> Update(long id, UpdateInvoiceInputModel request)
        {
            throw new NotImplementedException();
        }

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICustomerMembershipRepository _customerMembershipRepository;
        private readonly IDeliveryMembershipRepository _deliveryMembershipRepository;
        private readonly ICollectorMembershipRepository _collectorMembershipRepository;
        private readonly IQuickAccessListRepository _quickAccessListRepository;
        private readonly ISecretaryMembershipRepository _secretaryMembershipRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    }
}
