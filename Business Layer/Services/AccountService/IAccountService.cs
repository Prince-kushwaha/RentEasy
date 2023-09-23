using Data_Access_Layer.Entities;

namespace Business_Layer.Services.AccountService
{
    public interface IAccountService
    {
        Task<User?> Login(string username, string password);
        Task<bool> IsUserExistWithEmail(string email);
        Task<User?> FindUserByEmail(string email);
    }
}
