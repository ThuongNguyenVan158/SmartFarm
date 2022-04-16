using SmartFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Services
{
    public interface IAdminService
    {
        Task<List<AdminAccountViewModel>> GetAdminAccountAsync();
        Task<bool> InsertAccountAysnc(InsertAccountViewModel account);
        void DeleteAccount(string account);
        Task<EditUserViewModel> EditAccountAsync(string UserName);
        void PostEditAccount(EditUserViewModel account);
        Task<bool> PostPassword(EditUserViewModel account);
    }
}
