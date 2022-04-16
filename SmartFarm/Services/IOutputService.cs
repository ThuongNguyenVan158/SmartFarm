using System.Collections.Generic;
using System.Threading.Tasks;
using SmartFarm.Models;
namespace SmartFarm.Services
{
    public interface IOutputService
    {
        Task<List<OutputModel>> GetOutputAsync(int idFarm);
        OutputModel GetOutputById(int id);
        void SetAutOutput(int i, int id);
    }
}