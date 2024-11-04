using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ES.Services.API.FilterMessage;

public class CustomValidationExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException validationException)
        {
            var errors = validationException.Errors
                .Select(e => new { Field = e.PropertyName, Error = e.ErrorMessage })
                .ToList();

            context.Result = new BadRequestObjectResult(new { errors });
            context.ExceptionHandled = true;
        }
        else
        {
            var errors = context.ModelState
                .Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
                .SelectMany(x => x.Value.Errors.Select(e => e.ErrorMessage))
                .ToList();

            context.Result = new BadRequestObjectResult(new { errors });
            context.ExceptionHandled = true;
        }
    }
}


