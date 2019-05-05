using System;
using System.Collections.Generic;
using System.Text;
using TeamServices.Microservice.TDD.Domain.Models;
using TeamServices.Microservice.TDD.Repository;

namespace TeamServices.Microservice.TDD.Tests.Presistance
{
    public class TestInMemoryTeamRepository : InMemoryTeamRepository
    {
        public TestInMemoryTeamRepository():base(AddInitialItems())
        {
            
        }

        private static IList<Team> AddInitialItems()
        {
            return new List<Team> {new Team("team a"), new Team("team b")};
        }
    }
}
