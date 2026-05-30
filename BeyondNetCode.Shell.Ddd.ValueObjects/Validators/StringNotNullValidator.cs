using BeyondNetCode.Shell.Ddd.Rules;
using BeyondNetCode.Shell.Ddd.Rules.Impl;

namespace BeyondNetCode.Shell.Ddd.ValueObjects.Validators
{
    public class StringNotNullValidator : AbstractRuleValidator<ValueObject<string>>
    {
        public StringNotNullValidator(ValueObject<string> subject) : base(subject)
        {
        }

        public override void AddRules(RuleContext? context)
        {
            var value = Subject.GetValue();

            if (value == null)
            {
                AddBrokenRule("CommonValidator", "Value for property cannot be null");
                return;
            }

        }
    }
}
