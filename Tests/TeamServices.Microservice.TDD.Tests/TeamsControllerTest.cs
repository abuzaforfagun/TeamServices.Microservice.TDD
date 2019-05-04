using System;
using TeamServices.Microservice.TDD.Controllers;
using Xunit;

namespace TeamServices.Microservice.TDD.Tests
{
    public class TeamsControllerTest
    {
        TeamsController controller = new TeamsController();
        [Fact]
        public void GetAll_ShouldReturn_CorrectTeams()
        {
            var teams = controller.GetAll();
            Assert.Equal(2, teams.Count);
        }
    }
}
