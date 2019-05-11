using System;
using System.Collections.Generic;
using TeamServices.Microservice.TDD.Domain.Models;
using TeamServices.Microservice.TDD.Repository;

namespace TeamServices.Microservice.TDD.Tests.Presistance
{
    public class TestInMemoryTeamRepository : InMemoryTeamRepository
    {
        public TestInMemoryTeamRepository():base(AddInitialItems())
        {
            
        }

        public TestInMemoryTeamRepository(bool isEmptyTeam)
        {
            
        }

        private static IList<Team> AddInitialItems()
        {
            var teamA = new Team("team a", Guid.NewGuid());
            var teamB = new Team("team B", Guid.NewGuid())
            {
                Members = new List<Member>() { new Member("Shaon", "", Guid.NewGuid())}
            };
            return new List<Team> {teamA, teamB};
        }
    }
}
