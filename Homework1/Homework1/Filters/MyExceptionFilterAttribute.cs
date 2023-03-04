using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Homework1.Filters
{
    public class MyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContex)
        {
            string exceptionMessage = String.Empty;
            if (actionExecutedContex.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContex.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContex.Exception.InnerException.Message;
            }
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("New Error")
            };
            actionExecutedContex.Response = response;
        }
    }
}