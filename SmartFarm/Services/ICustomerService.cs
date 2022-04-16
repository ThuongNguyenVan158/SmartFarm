using SmartFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartFarm.Services
{
    public interface ICustomerService
    {
        Task<int> LoginAsync(string username, string password);
        Task SignOutAsync();
        UserInforViewModel InforUser(string UserName);
        void PostEditAccount(UserInforViewModel account);
        Task<bool> PostPassword(UserInforViewModel account);
        Task<List<EquipmentViewModel>> GetEquipmentAsync(int idFarm);
        Task InsertEquipment(InsertEquipmentViewModel equipment, ClaimsPrincipal user);
        void DeleteEquipment(int id);
        EditEquipmentViewModel GetEquipmentDetail(int id);
        void PostEditEquipment(EditEquipmentViewModel equipment);
    }
}