using SmartFarm.Models;

namespace SmartFarm.Services
{
    public interface IStrategyContext
    {
        void SetStrategy(IDrawStrategy strategy);
        string ExecuteStrategy();
    }
}
