﻿namespace MyWebApi.Builders.Actions
{
    using System.Net;
    using System.Web.Http.Results;
    using Common.Extensions;
    using Contracts.Base;
    using Exceptions;

    /// <summary>
    /// Class containing methods for testing OkResult.
    /// </summary>
    /// <typeparam name="TActionResult">Result from invoked action in ASP.NET Web API controller.</typeparam>
    public partial class ActionResultTestBuilder<TActionResult>
    {
        /// <summary>
        /// Tests whether action result is StatusCodeResult.
        /// </summary>
        /// <returns>Base test builder with action result.</returns>
        public IBaseTestBuilderWithActionResult<TActionResult> ShouldReturnStatusCode()
        {
            this.ShouldReturn<StatusCodeResult>();
            return this.NewAndProvideTestBuilder();
        }

        /// <summary>
        /// Tests whether action result is StatusCodeResult and is the same as provided HttpStatusCode.
        /// </summary>
        /// <param name="statusCode">HttpStatusCode enumeration.</param>
        /// <returns>Base test builder with action result.</returns>
        public IBaseTestBuilderWithActionResult<TActionResult> ShouldReturnStatusCode(HttpStatusCode statusCode)
        {
            var statusCodeResult = this.GetReturnObject<StatusCodeResult>();
            if (statusCodeResult.StatusCode != statusCode)
            {
                throw new HttpStatusCodeAssertionException(string.Format(
                    "When calling {0} action in {1} expected to have {2} ({3}) status code, but received {4} ({5}).",
                    this.ActionName,
                    this.Controller.GetName(),
                    (int)statusCode,
                    statusCode,
                    (int)statusCodeResult.StatusCode,
                    statusCodeResult.StatusCode));
            }

            return this.NewAndProvideTestBuilder();
        }
    }
}
