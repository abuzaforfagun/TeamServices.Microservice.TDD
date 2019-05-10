using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamServices.Microservice.TDD.Controllers;
using TeamServices.Microservice.TDD.Domain.Models;
using TeamServices.Microservice.TDD.Repository;
using Xunit;
using Microsoft.AspNetCore.Mvc.Abstractions;
using TeamServices.Microservice.TDD.Tests.Presistance;

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
        public void Add_Should_AddItem()
        {
            var previousTeamCount = (((controller.GetAll() as OkObjectResult).Value) as IList<Team>).Count;
            var team = new Team("New team");
            controller.Add(team);
            var currentTeamCount = (((controller.GetAll() as OkObjectResult).Value) as IList<Team>).Count;
            Assert.Equal(currentTeamCount, previousTeamCount + 1);

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
    }
}
