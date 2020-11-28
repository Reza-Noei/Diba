using AutoMapper;
using Diba.Core.AppService.Contract;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using System;
using System.Linq;

namespace Diba.Core.AppService
{
    using QuickAccessListType = Contract.QuickAccessListType;

    public class QuickAccessListsQuery : IQuickAccessListQuery
    {
        private readonly IQuickAccessListRepository _quickAccessListRepository;
        private readonly IMapper _mapper;

        public QuickAccessListsQuery(IQuickAccessListRepository quickAccessListRepository,
                                     IMapper mapper)
        {
            _quickAccessListRepository = quickAccessListRepository;
            _mapper = mapper;
        }

        public ServiceResult<QuickAccessListViewModel> Get(QuickAccessListType ListType)
        {
            QuickAccessList List = _quickAccessListRepository.GetMany(P => P.Type == (Domain.QuickAccessListType)ListType).FirstOrDefault();
            if (List == null)
            {
                return new ServiceResult<QuickAccessListViewModel>(StatusCode.NotFound);
            }

            return new ServiceResult<QuickAccessListViewModel>()
            {
                Data = _mapper.Map<QuickAccessListViewModel>(List),
                StatusCode = StatusCode.Ok
            };
        }
    }
}
