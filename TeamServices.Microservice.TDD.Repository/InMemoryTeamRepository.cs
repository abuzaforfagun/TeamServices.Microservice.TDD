using System;
using System.Collections.Generic;
using System.Linq;
using TeamServices.Microservice.TDD.Domain.Models;

namespace TeamServices.Microservice.TDD.Repository
{
    public class InMemoryTeamRepository : ITeamRepository
    {
        private IList<Team> teams;

        public InMemoryTeamRepository()
        {
            if (teams == null)
            {
                teams = new List<Team>();
            }
        }

        public InMemoryTeamRepository(IList<Team> teams)
        {
            this.teams = teams;
        }

        public void AddTeam(Team team)
        {
            teams.Add(team);
        }

        public Team GetTeam(Guid id)
        {
            return this.teams.Single(t => t.Id == id);
        }

        public IList<Team> GetTeams()
        {
            return teams;
        }
    }
}
