using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Diba.Core.AppService
{
    public class AuthenticationCommand : IAuthenticationCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IJsonWebTokenEngine _jsonWebTokenEngine;

        public AuthenticationCommand(IUserRepository userRepository,
                                     IJsonWebTokenEngine jsonWebTokenEngine)
        {
            _userRepository = userRepository;
            _jsonWebTokenEngine = jsonWebTokenEngine;
        }

        public ServiceResult<string> Login(UserAuthenticationBindingModel model)
        {
            // TODO: Hash user password in user creation process and login process.
            var user = _userRepository.Get(P => P.Username == model.Username && P.Password == model.Password);
            List<Domain.Role> t = user.Roles.ToList();

            IEnumerable<string> roles = t.Select(x => x.RoleName);
            var a = roles.ToList();
            if (user != null)
                return new ServiceResult<string>()
                {
                    Data = _jsonWebTokenEngine.GenerateToken(user.Id, user.Username, roles),
                    StatusCode = StatusCode.Ok
                };

            return new ServiceResult<string> { StatusCode = StatusCode.NotFound };
        }
    }
}