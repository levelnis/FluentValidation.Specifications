using FluentAssertions;
using NUnit.Framework;

namespace FluentValidation.Specifications
{
    public abstract class WhenValidatingValidEntity<TValidator, TEntity> : ValidatorSpecBase<TValidator, TEntity> where TValidator : AbstractValidator<TEntity>, new()
    {
        [Test]
        public void ThenValidatorContainsNoErrors()
        {
            Result.Errors.Count.Should().Be(0);
        }

        [Test]
        public void ThenValidatorIsValid()
        {
            Result.IsValid.Should().Be(true);
        }
    }
}