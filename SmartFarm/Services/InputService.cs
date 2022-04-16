using System.Collections.Generic;
using System.Threading.Tasks;
using SmartFarm.Data;
using SmartFarm.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace SmartFarm.Services
{
    public class InputService:IInputService
    {
        private readonly AppDbContext _context;
        public InputService(AppDbContext context){
            _context = context;
        }

        public async Task<InputModel> GetInputIdAsync(int id)
        {
            var result = await (from i in _context.Input
                                from f in _context.Farm
                                join e in _context.Equipment on i.Id equals e.Id
                                where i.Id==id && e.TrangThai==true && e.ThuocVeTrangTrai==f.Id
                                select new InputModel
                                {
                                    id = i.Id,
                                    name = e.Ten,
                                    feedName = i.FeedName,
                                    thuocVeTrangTrai = e.ThuocVeTrangTrai,
                                    viTri = e.ViTriDat,
                                    image = e.Image,
                                    thongTin=e.ThongTin,
                                    loaiThietBi=i.LoaiThietBi,
                                    nguongMin=i.Min,
                                    nguongMax=i.Max,
                                    timeSet=i.ThoiGianTruyXuat,
                                    donVi=i.DonVi,
                                    AioKey=f.AioKey
                                }).FirstOrDefaultAsync();
            return result;
        }
        public async Task<List<InputModel>> GetInputsAsync(int idFarm){
            var result = await (from i in _context.Input
                                from f in _context.Farm
                                join e in _context.Equipment on i.Id equals e.Id
                                where e.TrangThai==true && e.ThuocVeTrangTrai==idFarm && f.Id==idFarm
                                select new InputModel
                                {
                                    id = i.Id,
                                    name = e.Ten,
                                    feedName = i.FeedName,
                                    thuocVeTrangTrai = e.ThuocVeTrangTrai,
                                    viTri = e.ViTriDat,
                                    image = e.Image,
                                    thongTin=e.ThongTin,
                                    loaiThietBi=i.LoaiThietBi,
                                    nguongMin=i.Min,
                                    nguongMax=i.Max,
                                    timeSet=i.ThoiGianTruyXuat,
                                    donVi=i.DonVi,
                                    AioKey=f.AioKey
                                }).ToListAsync();
            return result;
        }
        public void UpdateSetNguong(InputModel input)
        {
            var input1= (from i in _context.Input
                        where i.Id == input.id && i.LoaiThietBi==input.loaiThietBi
                        select i).FirstOrDefault();
            input1.Max=input.nguongMax;
            input1.Min=input.nguongMin;
            input1.ThoiGianTruyXuat=input.timeSet;
            _context.SaveChanges();
        }
    }
}