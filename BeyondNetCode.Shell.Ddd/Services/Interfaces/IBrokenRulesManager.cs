using BeyondNetCode.Shell.Ddd.Rules;

namespace BeyondNetCode.Shell.Ddd.Services.Interfaces
{
    public interface IBrokenRulesManager
    {
        void Add(BrokenRule brokenRule);
        void Add(IReadOnlyCollection<BrokenRule> brokenRules);
        void Remove(BrokenRule brokenRule);
        void Clear();
        ReadOnlyCollection<BrokenRule> GetBrokenRules();
        string GetBrokenRulesAsString();
    }
}
