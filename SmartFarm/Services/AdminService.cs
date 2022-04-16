using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartFarm.Data;
using SmartFarm.Data.Entities;
using SmartFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFarm.Services
{
    public class AdminService : IAdminService
    {
        private readonly SignInManager<Customer> _signInManager;
        private readonly UserManager<Customer> _userManager;
        private readonly AppDbContext _context;
        public AdminService(
            SignInManager<Customer> signInManager,
            UserManager<Customer> userManager,
            AppDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        public async Task<List<AdminAccountViewModel>> GetAdminAccountAsync()
        {
            var account = await (from a in _context.Customer
                                 where a.TrangThai==true
                                 select new AdminAccountViewModel
                                 {
                                     Email = a.Email,
                                     FullName = a.Ho +" " + a.Ten,
                                     UserName = a.UserName
                                 }).ToListAsync();
            return account;
        }
        public async Task<bool> InsertAccountAysnc(InsertAccountViewModel account)
        {
            if (account.Password != account.RePassword) return false;
            var customer = await _userManager.FindByNameAsync(account.UserName);
            if (customer != null)
            {
                return false;
            }
            var newCustomer = new Customer()
            {
                Id = System.Guid.NewGuid(),
                UserName = account.UserName,
                Ten=account.Ten,
                Ho=account.Ho,
                Email = account.Email,
                VaiTro=account.Role,
                SoHuuTrangTrai=account.FarmID,
                DiaChi=account.Address,
                PhoneNumber=account.PhoneNumber,
                TrangThai = true
            };
            var result = await _userManager.CreateAsync(newCustomer, account.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public void DeleteAccount(string UserName)
        {
            var account = (from p in _context.Customer
                           where p.UserName == UserName
                           select p).FirstOrDefault();
            account.TrangThai = false;
            _context.SaveChanges();
        }
        public async Task<EditUserViewModel> EditAccountAsync(string UserName)
        {
            var user = await (from a in _context.Customer
                              where a.UserName == UserName
                              select new EditUserViewModel
                              { 
                                  ImgUrl = a.Image,
                                  UserName = a.UserName,
                                  Ho = a.Ho,
                                  Ten = a.Ten,
                                  Address = a.DiaChi,
                                  Email = a.Email
                              }).FirstOrDefaultAsync();
            return user;
        }
        public void PostEditAccount(EditUserViewModel account)
        {
            var user = (from a in _context.Customer
                    where a.UserName == account.UserName
                    select a).FirstOrDefault();
            user.Ho = account.Ho;
            user.Ten = account.Ten;
            user.Email = account.Email;
            user.DiaChi = account.Address;
            _context.SaveChanges();
        }
        public async Task<bool> PostPassword(EditUserViewModel account)
        {
            var customer = (from a in _context.Customer
                        where a.UserName == account.UserName
                        select a.Id).FirstOrDefault();
            var customerID = customer.ToString();
            var user = await _userManager.FindByIdAsync(customerID);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, token, account.Password);
            _context.SaveChanges();
            return true;
        }
    }
}