using Diba.Core.AppService.Contract.Constraint.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract.Constraint
{
    public interface IConstraintQueryService
    {
        ServiceResult<ConstraintViewModel> Get(int id);
        ServiceResult<IEnumerable<ConstraintViewModel>> GetList();
    }
}
