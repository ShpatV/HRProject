using HRProject.Application.wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace HRProject.API.Filters

{
    public class ErrorHandlingFilterAttribute : IExceptionFilter
    {
        //public override void OnException(ExceptionContext context)
        //{
        //   
        //}
        public void OnException(ExceptionContext context)
        {
            var exception = new ExceptionResponse(context.Exception);



              context.Result = new JsonResult(exception);
              context.HttpContext.Response.StatusCode = (int)Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest;

              context.ExceptionHandled = true;
        }
    }
}
