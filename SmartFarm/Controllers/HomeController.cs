using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartFarm.Data.Entities;
using SmartFarm.Models;
using SmartFarm.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly UserManager<Customer> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICustomerService customerService, UserManager<Customer> userManager)
        {
            _logger = logger;
            _customerService = customerService;
            _userManager = userManager;
        }

        public IActionResult Index(int a)
        {
            Console.WriteLine("HomeController");
            return RedirectToAction("Home"); 
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult InforUser(string UserName)
        {
            var user = _customerService.InforUser(UserName);
            return View(user);
        }
        public IActionResult PostEditAccount(UserInforViewModel account)
        {
            _customerService.PostEditAccount(account);
            return RedirectToAction("InforUser", "Home");
        }
        public async Task<IActionResult> ManageDevice(int idFarm)
        {
            var equipment = await _customerService.GetEquipmentAsync(idFarm);
            return View(equipment);
        
        }
        public async Task<IActionResult> InsertEquipment(InsertEquipmentViewModel equipment)
        {
            await _customerService.InsertEquipment(equipment,User);
            return RedirectToAction("ManageDevice", "Home", new { idFarm = _userManager.GetUserAsync(User).Result.SoHuuTrangTrai });
        }
        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var loginSucess = await _customerService.LoginAsync(loginViewModel.UserName, loginViewModel.Password);

            if (loginSucess == 1)
            {
                loginViewModel.ErrorMessage = "Tài khoản không tồn tại";
                return View(loginViewModel);
            }
            else if (loginSucess == 3)
            {
                return RedirectToAction("Home");
            }
            else
            {
                return RedirectToAction("ManageUser", "Admin");
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _customerService.SignOutAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> PostPassword(UserInforViewModel account)
        {
            if (account.Password != account.RePassword)
            {
                return RedirectToAction("InforUser", "Home");
            }
            var user = await _customerService.PostPassword(account);
            if (user == false)
            {
                RedirectToAction("InforUser", "Home");
            }
            return RedirectToAction("Home");
        }
        public IActionResult EquipmentDetail(int id)
        {
            var equipment = _customerService.GetEquipmentDetail(id);
            return View(equipment);
        }
        public IActionResult PostEditEquipment(EditEquipmentViewModel equipment)
        {
            _customerService.PostEditEquipment(equipment);
            return RedirectToAction("ManageDevice", "Home", new { idFarm = _userManager.GetUserAsync(User).Result.SoHuuTrangTrai });

        }
        public IActionResult DeleteEquipment(int id)
        {
            _customerService.DeleteEquipment(id);
            return RedirectToAction("ManageDevice", "Home", new { idFarm = _userManager.GetUserAsync(User).Result.SoHuuTrangTrai });
        }
    }
}
