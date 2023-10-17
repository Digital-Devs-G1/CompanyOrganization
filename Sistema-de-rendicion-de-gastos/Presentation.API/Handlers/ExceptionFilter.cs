using Application.DTO.Response;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Presentation.API.Handlers
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            List<string> message = new List<string>();

            if(context.Exception is NotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
                message.Add(context.Exception.Message);
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message.Add("Ha ocurrido un error interno.");
            }

            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult(
                new MessageResponse()
                {
                    Messages = message
                }
            );
        }
    }
}
