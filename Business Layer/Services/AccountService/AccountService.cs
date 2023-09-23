using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.AccountRepository;

namespace Business_Layer.Services.AccountService
{
    public class AccountService:IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        public async Task<User?> Login(string username, string password)
        {
            var user = await _accountRepository.Find((user) => user.Email == username && (user.Password==password));
            return user;
        }

        public async Task<bool> IsUserExistWithEmail(string email)
        {
            var user = await _accountRepository.Find((user) => user.Email == email);
            return user != null;
        }

        public async Task<User?> FindUserByEmail(string email)
        {
            var user = await _accountRepository.Find((user) => user.Email == email);
            return user;
        }
    }
}
