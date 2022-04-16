using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartFarm.Data.Entities;
using SmartFarm.Models;
using SmartFarm.Services;
using System.Threading.Tasks;

namespace SmartFarm.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly UserManager<Customer> _userManager;

        public AdminController(IAdminService adminService,UserManager<Customer> userManager)
        {
            _adminService = adminService;
            _userManager = userManager;
        }
        public async Task<IActionResult> ManageUser()
        {
            if(_userManager.GetUserAsync(User).Result.VaiTro!="admin")
            {
                return RedirectToAction("Home","Home");
            }
            var product = await _adminService.GetAdminAccountAsync();
            return View(product);
        }
        public async Task<IActionResult> EditUser(string UserName)
        {
            var account = await _adminService.EditAccountAsync(UserName);
            return View(account);
        }
        public IActionResult PostEditUser(EditUserViewModel account)
        {
            _adminService.PostEditAccount(account);
            return RedirectToAction("ManageUser", "Admin");
        }
        public async Task<IActionResult> PostPassword(EditUserViewModel account)
        {
            if (account.Password!=account.RePassword)
            {
                return RedirectToAction("EditUser", "Admin");
            }
            var user = await _adminService.PostPassword(account);
            if (user==false)
            {
                RedirectToAction("EditUser", "Admin");
            }
            return RedirectToAction("ManageUser", "Admin");
        }
        public async Task<IActionResult> InsertAccount(InsertAccountViewModel account)
        {
            var registerSucess = await _adminService.InsertAccountAysnc(account);
            if (!registerSucess)
            {
                return RedirectToAction("ManageUser", "Admin");
            }
            return RedirectToAction("Home", "Home");
        }
        public IActionResult DeleteAccount(string UserName)
        {
            _adminService.DeleteAccount(UserName);
            return RedirectToAction("ManageUser", "Admin");
        }
    }
}
