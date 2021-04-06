using System;

namespace Diba.Core.AppService.Contract
{
    public class CreateUserInputModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class GetUserInputModel
    {
        public long Id { get; set; }
    }

    public class GetCustomerInputModel
    {
        public long Id { get; set; }
    }

    public class GetAllUserInputModel
    {
    } 
    
    public class GetAllCustomersInputModel
    {
    }  

    public class UpdateUserInputModel
    {
        public string Username { get; set; }
    }

    public class UpdateUserRequest
    {
        public long Id { get; set; }
        public string Username { get; set; }
    }


    public class DeleteUserInputModel
    {
        public long Id { get; set; }
    }  
    

}