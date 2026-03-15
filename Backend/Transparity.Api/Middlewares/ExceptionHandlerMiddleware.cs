using FluentValidation;
using System.Net;
using System.Text.Json;
using Transparity.Shared.Exceptions;
using Transparity.Shared.Models;

namespace Transparity.Api.Middlewares {
    public class ExceptionHandlerMiddleware {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            try {
                await _next(context);
            }
            catch (ArgumentNullException ex) {
                await HandleBadRequestError(context, ex.Message);
            }
            catch (ValidationException ex) {
                await HandleValidationError(context, ex);
            }
            catch (AppException ex) {
                await HandleInternalServerError(context, ex.Message);
            }
            catch (DataException ex) {
                await HandleBadRequestError(context, ex.Message);
            }
            catch (InvalidOperationException ex) {
                await HandleInternalServerError(context, ex.Message);
            }
            catch (OperationCanceledException ex) {
                await HandleGoneError(context, ex.Message);
            }
            catch (HealthException ex) {
                await HandleHealthError(context, ex);
            }
        }

        private Task HandleBadRequestError(HttpContext context, string message) {
            var errorObject = Result<object>
                    .Error(message);

            return WriteErrorResponse(context,
                HttpStatusCode.BadRequest, errorObject);
        }

        private Task HandleValidationError(HttpContext context, ValidationException ex) {
            var errorObject = Result<object>
                    .Error(ex.Message);

            return WriteErrorResponse(context,
                HttpStatusCode.BadRequest, errorObject);
        }

        private Task HandleInternalServerError(HttpContext context, string message) {
            var errorObject = Result<object>
                    .Error(message);

            return WriteErrorResponse(context,
                HttpStatusCode.InternalServerError, errorObject);
        }

        private Task HandleGoneError(HttpContext context, string message) {
            var errorObject = Result<object>
                    .Error(message);

            return WriteErrorResponse(context,
                HttpStatusCode.Gone, errorObject);
        }

        private Task HandleHealthError(HttpContext context, HealthException ex) {
            var innerEx = ex.InnerException;

            var errorData = JsonSerializer
                .Deserialize<object>(innerEx!.Message);

            var errorObject = Result<object>
                .Error(ex.Message, errorData);

            return WriteErrorResponse(context,
                HttpStatusCode.InternalServerError, errorObject);
        }

        private static async Task WriteErrorResponse(HttpContext context,
            HttpStatusCode statusCode, object errorObject) {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsJsonAsync(errorObject);
        }
    }
}
