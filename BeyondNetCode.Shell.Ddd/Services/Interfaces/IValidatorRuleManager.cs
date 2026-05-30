using BeyondNetCode.Shell.Ddd.Rules;
using BeyondNetCode.Shell.Ddd.Rules.Interfaces;

namespace BeyondNetCode.Shell.Ddd.Services.Interfaces
{
    public interface IValidatorRuleManager<TValidator> where TValidator : IRuleValidator
    {
        void Add(TValidator rule);
        void Add(IEnumerable<TValidator> rules);
        void Remove(TValidator rule);
        void Clear();
        ReadOnlyCollection<TValidator> GetValidators();
        ReadOnlyCollection<BrokenRule> GetBrokenRules(RuleContext? context = null);
    }
}
