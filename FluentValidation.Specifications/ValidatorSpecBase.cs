using FluentValidation.Results;
using NBehave.Spec.NUnit;

namespace FluentValidation.Specifications
{
    public abstract class ValidatorSpecBase<TValidator, TEntity> : SpecBase<TValidator> where TValidator : AbstractValidator<TEntity>, new()
    {
        protected TEntity Subject;
        protected ValidationResult Result;
        protected int ExpectedErrorCount;

        protected override TValidator Establish_context()
        {
            return new TValidator();
        }

        protected override void Because_of()
        {
            Result = Sut.Validate(Subject);
        }
    }
}