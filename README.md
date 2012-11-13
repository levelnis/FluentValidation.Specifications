FluentValidation.Specifications
===============================

NBehave Specification based test framework for testing FluentValidation validators

Usage
-----

This library provides a couple of base classes that provide a simple way to test FluentValidation validators within your MVC project. Once you've created your Validator class that inherits from AbstractValidator<TEntity>, you can begin to test both the valid and invalid scenarios by inheriting from WhenValidatingValidEntity<TValidator, TEntity> or WhenValidatingInvalidEntity<TValidator, TEntity> according to your needs. The test methods themselves are included in the base types so you simply initialise the entity you're validating and add any errors you would expect from an invalid entity.

Example
-------

    public class WhenValidatingUserViewModelCorrectly : WhenValidatingValidEntity<UserViewModelValidator, UserViewModel>
    {
      protected override UserViewModelValidator Establish_context()
      {
        Subject = new UserViewModel { Username = "dave" };
        return base.Establish_context();
      }
    }

    public class WhenValidatingUserViewModelWithNoUsername : WhenValidatingInvalidEntity<UserViewModelValidator, UserViewModel>
    {
      protected override UserViewModelValidator Establish_context()
      {
        Subject = new UserViewModel();
        ExpectedErrorCount = 1;
        AddError("Username", "Please enter your username");
        return base.Establish_context();
      }
    }