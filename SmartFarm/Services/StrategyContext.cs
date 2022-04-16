using SmartFarm.Models;

namespace SmartFarm.Services
{
    public class StrategyContext: IStrategyContext
    {
        private IDrawStrategy _strategy;
        public StrategyContext()
        { }

        public StrategyContext(IDrawStrategy strategy)
        {
            this._strategy = strategy;
        }
        public void SetStrategy(IDrawStrategy strategy)
        {
            _strategy = strategy;
        }
        public string ExecuteStrategy()
        {
            return _strategy.DrawFunction();
        }
    }
}
