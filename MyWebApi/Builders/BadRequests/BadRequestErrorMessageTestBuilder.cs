﻿namespace MyWebApi.Builders.BadRequests
{
    using System.Web.Http;
    using System.Web.Http.Results;
    using Base;
    using Common.Extensions;
    using Contracts.And;
    using Contracts.BadRequests;
    using Exceptions;

    /// <summary>
    /// Used for testing specific bad request error messages.
    /// </summary>
    public class BadRequestErrorMessageTestBuilder<TBadRequestResult>
        : BaseTestBuilderWithActionResult<TBadRequestResult>, IBadRequestErrorMessageTestBuilder<TBadRequestResult>
    {
        private readonly string actualMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestErrorMessageTestBuilder{TBadRequestResult}" /> class.
        /// </summary>
        /// <param name="controller">Controller on which the action will be tested.</param>
        /// <param name="actionName">Name of the tested action.</param>
        /// <param name="actualMessage">Actual error message received from bad request result.</param>
        public BadRequestErrorMessageTestBuilder(
            ApiController controller,
            string actionName,
            TBadRequestResult actionResult,
            string actualMessage)
            : base(controller, actionName, actionResult)
        {
            this.actualMessage = actualMessage;
        }

        /// <summary>
        /// Tests whether particular error message is equal to given message.
        /// </summary>
        /// <param name="errorMessage">Expected error message for particular key.</param>
        public IAndTestBuilder<TBadRequestResult> ThatEquals(string errorMessage)
        {
            if (this.actualMessage != errorMessage)
            {
                this.ThrowNewBadRequestResultAssertionException(
                    "When calling {0} action in {1} expected bad request error message to be '{2}', but instead found '{3}'.",
                    errorMessage);
            }

            return this.NewAndTestBuilder();
        }

        /// <summary>
        /// Tests whether particular error message begins with given message.
        /// </summary>
        /// <param name="beginMessage">Expected beginning for particular error message.</param>
        public IAndTestBuilder<TBadRequestResult> BeginningWith(string beginMessage)
        {
            if (!this.actualMessage.StartsWith(beginMessage))
            {
                this.ThrowNewBadRequestResultAssertionException(
                    "When calling {0} action in {1} expected bad request error message to begin with '{2}', but instead found '{3}'.",
                    beginMessage);
            }

            return this.NewAndTestBuilder();
        }

        /// <summary>
        /// Tests whether particular error message ends with given message.
        /// </summary>
        /// <param name="endMessage">Expected ending for particular error message.</param>
        public IAndTestBuilder<TBadRequestResult> EndingWith(string endMessage)
        {
            if (!this.actualMessage.EndsWith(endMessage))
            {
                this.ThrowNewBadRequestResultAssertionException(
                    "When calling {0} action in {1} expected bad request error message to end with '{2}', but instead found '{3}'.",
                    endMessage);
            }

            return this.NewAndTestBuilder();
        }

        /// <summary>
        /// Tests whether particular error message contains given message.
        /// </summary>
        /// <param name="containsMessage">Expected containing string for particular error message.</param>
        public IAndTestBuilder<TBadRequestResult> Containing(string containsMessage)
        {
            if (!this.actualMessage.Contains(containsMessage))
            {
                this.ThrowNewBadRequestResultAssertionException(
                    "When calling {0} action in {1} expected bad request error message to contain '{2}', but instead found '{3}'.",
                    containsMessage);
            }

            return this.NewAndTestBuilder();
        }

        private void ThrowNewBadRequestResultAssertionException(string messageFormat, string operation)
        {
            throw new BadRequestResultAssertionException(string.Format(
                messageFormat,
                this.ActionName,
                this.Controller.GetName(),
                operation,
                this.actualMessage));
        }
    }
}
