using TDDNet6.Models.User;

namespace TDDNet6.Services.User
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUsers();
    }
    public class UserService : IUserService
    {
        public Task<List<UserModel>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
