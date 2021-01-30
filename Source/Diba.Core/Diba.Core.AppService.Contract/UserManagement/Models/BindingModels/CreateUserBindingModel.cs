
namespace Diba.Core.AppService.Contract.BindingModels
{
    public class CreateUserBindingModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class GetUserBindingModel
    {
        public long Id { get; set; }
    } 
    
    public class GetAllUserBindingModel
    {
    }  

    public class UpdateUserBindingModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
    }

    public class DeleteUserBindingModel
    {
        public long Id { get; set; }
    }
}