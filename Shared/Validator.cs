using FluentValidation;
using Models;
using System;

namespace Shared
{
    public class Validator
    {
        protected static ResponseDto<TReturnType> Validate<TReturnType, TValidator, TCommand>(TCommand command) where TValidator : AbstractValidator<TCommand>, new()
        {
            var response = new ResponseDto<TReturnType>();
            TValidator validator = new TValidator();

            var validationResult = validator.Validate(command);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    response.Errors.Add(error.ErrorMessage);
                }
            }
            return response;
        }
    }
}
