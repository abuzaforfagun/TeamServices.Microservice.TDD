using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamServices.Microservice.TDD.Controllers;
using TeamServices.Microservice.TDD.Domain.Models;
using Xunit;
using TeamServices.Microservice.TDD.Tests.Presistance;
using ObjectResult = Microsoft.AspNetCore.Mvc.ObjectResult;

namespace TeamServices.Microservice.TDD.Tests
{
    public class TeamsControllerTest
    {
        TeamsController controller = new TeamsController(new TestInMemoryTeamRepository());
        [Fact]
        public void GetAll_ShouldReturn_CorrectTeams()
        {
            var result = controller.GetAll() as OkObjectResult;
            var teams = result.Value as IList<Team>;
            Assert.Equal(2, teams.Count);
        }

        [Fact]
        public void GetAll_ShouldReturn_NoContent_WhenNoTeamsAreAvailable()
        {
            var repository = new TestInMemoryTeamRepository(true);
            var controller = new TeamsController(repository);
            var result = controller.GetAll();
            Assert.True(result is NoContentResult);
        }

        [Fact]
        public void Add_Should_AddItem()
        {
            var previousTeamCount = (((controller.GetAll() as OkObjectResult).Value) as IList<Team>).Count;
            var team = new Team("New team");
            controller.Add(team);
            var currentTeamCount = (((controller.GetAll() as OkObjectResult).Value) as IList<Team>).Count;
            Assert.Equal(currentTeamCount, previousTeamCount + 1);
        }

        [Fact]
        public void Add_WithValidTeam_ShouldReturn_OkResult()
        {
            var guid = Guid.NewGuid();
            var team = new Team("Dhaka", guid);
            var result = controller.Add(team);
            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Add_WithValidTeam_ShouldReturn_NewlyAddedTeamDetails()
        {
            var guid = Guid.NewGuid();
            var team = new Team("Dhaka", guid);
            var result = (controller.Add(team) as ObjectResult).Value as Team;
            Assert.Equal(result.Name, team.Name);
            Assert.Equal(result.Id, team.Id);
        }

        [Fact]
        public void Add_WithOutGuId_ShouldAddItem_WithDefaultGuId()
        {
            var team = new Team("New team");
            controller.Add(team);
            var addedTeam = (((controller.GetAll() as OkObjectResult).Value) as IList<Team>).Last();
            Assert.Equal(addedTeam.Id, Guid.Empty);
        }

        [Fact]
        public void Add_WithExistingId_ShouldReturn_BadRequest()
        {
            var teams = (controller.GetAll() as ObjectResult).Value as IList<Team>;
            var team = new Team("New team", teams.Last().Id);
            var result = controller.Add(team);
            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void GetTeam_CallWithValidTeamId_ShoudReturn_CorrectTeam()
        {
            var guId = Guid.NewGuid();
            var team = new Team("Barca", guId);
            controller.Add(team);

            var result = (controller.Get(guId) as ObjectResult).Value as Team;
            Assert.Equal(result.Name, team.Name);
            Assert.Equal(result.Id, guId);
        }

        [Fact]
        public void GetTeam_CallWithInvalidTeamId_ShoudReturn_NotFound()
        {
            var guId = Guid.NewGuid();

            var result = controller.Get(guId);
            Assert.True(result is NotFoundResult);
        }
        
    }
}
