using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartFarm.Data.Entities;
using SmartFarm.Models;
using SmartFarm.Services;

namespace SmartFarm.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInputService _inputService;
        private readonly IOutputService _outputservice;
        private readonly ICustomerService _customerService;
        private readonly UserManager<Customer> _userManager;
        private readonly IStrategyContext _strategyContext;

        public StatisticController(ILogger<HomeController> logger,IInputService inputService, ICustomerService customerService,IOutputService outputService, UserManager<Customer> userManager, IStrategyContext strategyContext)
        {
            _logger = logger;
            _inputService = inputService;
            _customerService = customerService;
            _outputservice = outputService;
            _userManager = userManager;
            _strategyContext = strategyContext;
        }
        public async Task<IActionResult> ThonkeAsync(int idFarm)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            //var input=await _inputService.GetInputsAsync();
            //InputAndOutputModel result=new InputAndOutputModel();
            //result.Inputs=input;
            //return View(result);
            idFarm = _userManager.GetUserAsync(User).Result.SoHuuTrangTrai;
            var equipment = await _customerService.GetEquipmentAsync(idFarm);
            return View(equipment);
        }
        [HttpGet]
        public async Task<IActionResult> InputAsync(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var input=await _inputService.GetInputIdAsync(id);
            input.typeChart = 1;
            return View(input);
        }
        [HttpPost]
        public async Task<IActionResult> InputAsync(int type, int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var input = await _inputService.GetInputIdAsync(id);
            input.typeChart = 2;
            if(type == 1)
            {
                _strategyContext.SetStrategy(new LineStrategy());
            }
            else if (type == 2)
            {
                _strategyContext.SetStrategy(new BarStrategy());
            }
            input.DrawFunction = _strategyContext.ExecuteStrategy();
            return View(input);
        }

        [HttpGet]
        public IActionResult Output(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var result = _outputservice.GetOutputById(id);
            return View(result);
        }
    }
}
