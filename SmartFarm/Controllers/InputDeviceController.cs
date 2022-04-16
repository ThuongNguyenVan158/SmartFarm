using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartFarm.Data.Entities;
using SmartFarm.Models;
using SmartFarm.Services;

namespace SmartFarm.Controllers
{
    public class InputDeviceController : Controller
    {
        private readonly IInputService _inputService;
        private readonly UserManager<Customer> _userManager;
        public InputDeviceController(IInputService inputService,UserManager<Customer> userManager)
        {
            _inputService = inputService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> SetUpNguong()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var idFarm = _userManager.GetUserAsync(User).Result.SoHuuTrangTrai;
            var input=await _inputService.GetInputsAsync(idFarm);
            return View(input);
        }
        [HttpPost]
        public IActionResult SetNguong(InputModel input)
        {
            input.timeSet=TimeSpan.FromSeconds(input.secondTime);
            _inputService.UpdateSetNguong(input);
            return RedirectToAction("SetUpNguong");
        }

    }
}
