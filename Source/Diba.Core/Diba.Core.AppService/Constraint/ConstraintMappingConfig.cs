using AutoMapper;
using Diba.Core.AppService.Contract.Constraint.Model.InputModels;
using Diba.Core.AppService.Contract.Constraint.Model.ViewModels;

namespace Diba.Core.AppService.Constraint
{
    public class ConstraintMappingConfig : Profile
    {
        public ConstraintMappingConfig()
        {
            CreateMap<Domain.Constraints.Constraint, ConstraintViewModel>();
            CreateMap<ConstraintViewModel, Domain.Constraints.Constraint>();
            CreateMap<CreateConstraintViewModel, ConstraintViewModel>().ForMember(x => x.Id, opt => opt.Ignore()); ;
            CreateMap<CreateConstraintViewModel, Domain.Constraints.Constraint>();
        }
    }
}
