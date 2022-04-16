using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartFarm.Data.Entities;
using SmartFarm.Services;

namespace SmartFarm.Controllers
{
    public class OutputDeviceController : Controller
    {
        private readonly IOutputService _output;
        private readonly UserManager<Customer> _userManager;
        public OutputDeviceController(IOutputService output,UserManager<Customer> userManager){
            _output = output;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> ControlDevice()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var idFarm = _userManager.GetUserAsync(User).Result.SoHuuTrangTrai;
            var outputs= await _output.GetOutputAsync(idFarm);
            return View(outputs);
        }
        [HttpPost]

        public IActionResult UpdateAutoController(int i,int id)
        {
            _output.SetAutOutput(i,id);
           return RedirectToAction("ControlDevice"); 
        }
    }
}
