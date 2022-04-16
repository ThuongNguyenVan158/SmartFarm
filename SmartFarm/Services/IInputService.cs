using System.Collections.Generic;
using System.Threading.Tasks;
using SmartFarm.Models;

namespace SmartFarm.Services
{
    public interface IInputService
    {
        Task<List<InputModel>> GetInputsAsync(int idFarm);
        Task<InputModel> GetInputIdAsync(int id);
         void UpdateSetNguong(InputModel input);
    }
}