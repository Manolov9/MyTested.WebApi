﻿namespace MyWebApi.Tests.BuildersTests
{
    using System.Collections.Generic;

    using ControllerSetups;
    using Exceptions;

    using NUnit.Framework;

    [TestFixture]
    public class ResponseModelTestBuilderTests
    {
        [Test]
        public void WithResponseModelShouldNotThrowExceptionWithCorrectResponseModel()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOkResult()
                .WithResponseModel<ICollection<ResponseModel>>();
        }

        [Test]
        public void WithResponseShouldNotThrowExceptionWithIncorrectInheritedTypeArgument()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOkResult()
                .WithResponseModel<IList<ResponseModel>>();
        }

        [Test]
        [ExpectedException(typeof(ResponseModelAssertionException))]
        public void WithResponseShouldThrowExceptionWithIncorrectResponseModel()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOkResult()
                .WithResponseModel<ResponseModel>();
        }

        [Test]
        [ExpectedException(typeof(ResponseModelAssertionException))]
        public void WithResponseShouldThrowExceptionWithIncorrectGenericTypeArgument()
        {
            MyWebApi
                .Controller<WebApiController>()
                .Calling(c => c.OkResultWithResponse())
                .ShouldReturnOkResult()
                .WithResponseModel<ICollection<int>>();
        }
    }
}
