using System;
using System.Collections;
using System.Collections.Generic;
using LocationServices.Api.Controllers;
using LocationServices.Domain;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace LocationServices.Tests
{
    public class LocationsControllerTests
    {
        private LocationsController controller;
        public LocationsControllerTests()
        {
            controller = new LocationsController();
        }

        [Fact]
        public void GetLatest_CallWith_ValidData_ShouldReturn_Ok()
        {
            var result = controller.GetLatest(Guid.NewGuid());
            Assert.True(result is OkResult);
        }

        [Fact]
        public void GetLatest_CallWith_InValidData_ShouldReturn_BadRequest()
        {
            var result = controller.GetLatest(new Guid());
            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void GetLatest_CallWith_ValidData_ShouldReturn_ListOfLocationRecord()
        {
            var response = controller.GetLatest(Guid.NewGuid()) as OkObjectResult;
            var result = response.Value as IList<LocationRecord>;
            Assert.True(result.Count > 0);
        }
    }
}
