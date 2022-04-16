using SmartFarm.Data;
using Microsoft.EntityFrameworkCore;
using SmartFarm.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SmartFarm.Services
{
    public class OutputService : IOutputService
    {
        private readonly AppDbContext _context;
        public OutputService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<OutputModel>> GetOutputAsync(int idFarm)
        {
            var result = await (from o in _context.Output
                                from f in _context.Farm
                                join e in _context.Equipment on o.Id equals e.Id
                                join io in _context.InputOutput on o.Id equals io.IdOutput
                                where e.TrangThai==true && e.ThuocVeTrangTrai==idFarm && f.Id==idFarm
                                select new OutputModel
                                {
                                    id = o.Id,
                                    name = e.Ten,
                                    trangThaiHoatDong = o.TrangThaiHoatDong,
                                    feedName = o.FeedName,
                                    thuocVeTrangTrai = e.ThuocVeTrangTrai,
                                    trangThai = e.TrangThai,
                                    viTri = e.ViTriDat,
                                    img = e.Image,
                                    valueOpen=o.ValueOpen,
                                    idInput=io.IdInput,
                                    loaiThietBi=io.LoaiThietBiInput,
                                    auto=o.Auto,
                                    AioKey=f.AioKey
                                }).ToListAsync();
            var resultInput = await (from i in _context.Input
                                    join io1 in _context.InputOutput on new {A=i.Id,B=i.LoaiThietBi} equals new{A=io1.IdInput,B=io1.LoaiThietBiInput}
                                    select new InputLinkOuptModel
                                    {
                                        idOutput=io1.IdOutput,
                                        idInput=io1.IdInput,
                                        loaiThietBiInput=io1.LoaiThietBiInput,
                                        feedName=i.FeedName,
                                        timeSet = i.ThoiGianTruyXuat,
                                        nguongMax=i.Max,
                                        nguongMin=i.Min,
                                    }).ToListAsync();
            foreach(var i in result)
            {
                if(i.auto==true) i.auto1=1;
                else i.auto1=0;
                foreach(var a in resultInput)
                {
                    if(i.id==a.idOutput)
                    {
                         i.inputOupts=a;
                         Console.WriteLine(a.timeSet.TotalSeconds);
                        break;
                    }
                }
            }
            return result;
        }
        public OutputModel GetOutputById(int id)
        {
            var result =  (from e in _context.Equipment
                                join o in _context.Output on e.Id equals o.Id
                                join f in _context.Farm on e.ThuocVeTrangTrai equals f.Id
                                where e.TrangThai==true && o.Id==id
                                select new OutputModel
                                {
                                    id = o.Id,
                                    name = e.Ten,
                                    trangThaiHoatDong = o.TrangThaiHoatDong,
                                    feedName = o.FeedName,
                                    thuocVeTrangTrai = e.ThuocVeTrangTrai,
                                    trangThai = e.TrangThai,
                                    viTri = e.ViTriDat,
                                    img = e.Image,
                                    valueOpen=o.ValueOpen,
                                    auto=o.Auto,
                                    AioKey=f.AioKey
                                }).FirstOrDefault();
            return result;
        }
        public void SetAutOutput(int i, int id)
        {
            var output= (from o in _context.Output
                        where o.Id == id
                        select o).FirstOrDefault();
            if(output != null)
            {
                output.Auto=(i==1);
                _context.SaveChanges();
            }

        }
    }

}