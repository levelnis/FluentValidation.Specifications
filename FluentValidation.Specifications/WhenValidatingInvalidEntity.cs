using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace FluentValidation.Specifications
{
    public abstract class WhenValidatingInvalidEntity<TValidator, TEntity> : ValidatorSpecBase<TValidator, TEntity> where TValidator : AbstractValidator<TEntity>, new()
    {
        private readonly IDictionary<string, string> errors = new Dictionary<string, string>();

        protected void AddError(string propertyName, string error)
        {
            errors.Add(propertyName, error);
        }

        [Test]
        public void ThenValidatorContainsCorrectErrorCount()
        {
            errors.Count.Should().Be(ExpectedErrorCount);
            Result.Errors.Count.Should().Be(ExpectedErrorCount);
        }

        [Test]
        public void ThenValidatorContainsExpectedErrors()
        {
            foreach (var error in errors)
            {
                var failure = Result.Errors.SingleOrDefault(e => e.PropertyName == error.Key);
                failure.Should().NotBeNull("because errors should contain '{0}' key", error.Key);
                failure.ErrorMessage.Should().Be(error.Value, "because '{0}' error should be correct", error.Key);
            }
        }

        [Test]
        public void ThenValidatorIsNotValid()
        {
            Result.IsValid.Should().Be(false);
        }
    }
}