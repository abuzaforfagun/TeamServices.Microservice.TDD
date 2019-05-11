using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeamServices.Microservice.TDD.Controllers;
using TeamServices.Microservice.TDD.Domain.Models;
using Xunit;

namespace TeamServices.Microservice.TDD.Tests.Presistance
{
    public class MemberControllerTests
    {
        private TestInMemoryTeamRepository repository;
        private TeamsController teamController;
        private MemberController memberController;

        public MemberControllerTests()
        {
            repository = new TestInMemoryTeamRepository();
            teamController = new TeamsController(repository);
            memberController = new MemberController(repository);
        }

        [Fact]
        public void Add_CalledWithValidTeamId_ShouldAddMember()
        {
            var team = new Team("BD Team", Guid.NewGuid());
            teamController.Add(team);

            var membersBeforeAdd = ((teamController.Get(team.Id) as ObjectResult).Value as Team).Members.Count;

            memberController.Add(team.Id, new Member("Abu Zafor", "Fagun", Guid.NewGuid()));
            var membersAfterAdd = ((teamController.Get(team.Id) as ObjectResult).Value as Team).Members.Count;
            Assert.Equal(membersAfterAdd, membersBeforeAdd + 1);
        }

        [Fact]
        public void Add_CalledWithValidTeamId_ShouldReturn_OkResponse()
        {
            var team = ((teamController.GetAll() as ObjectResult).Value as IList<Team>).Last();
            var result = memberController.Add(team.Id, new Member("Abu Zafor", "Fagun", Guid.NewGuid()));
            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public void Add_CalledWithValidData_ShouldReturn_NewlyAddedMember()
        {
            var member = new Member("Abu Zafor", "Fagun", Guid.NewGuid());
            var team = ((teamController.GetAll() as ObjectResult).Value as IList<Team>).First();
            var result = (memberController.Add(team.Id, member) as ObjectResult).Value as Member;
            Assert.Equal(result.Id, member.Id);
        }

        [Fact]
        public void Add_CalledWithInvalidTeamId_ShouldReturn_BadRequest()
        {
            var result = memberController.Add(Guid.NewGuid(), new Member("Abu Zafor", "Fagun", Guid.NewGuid()));
            Assert.True(result is BadRequestResult);
        }

        [Fact]
        public void Add_CalledWithExistingMemberId_ShouldReturn_BadRequest()
        {
            var team = ((teamController.GetAll() as ObjectResult).Value as IList<Team>).Last();
            var result = memberController.Add(team.Id, new Member("Jonh", "Sina", team.Members.First().Id));
            Assert.True(result is BadRequestResult);
        }
    }
}
