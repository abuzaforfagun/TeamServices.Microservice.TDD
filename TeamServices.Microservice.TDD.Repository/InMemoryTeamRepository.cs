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
            teams = teams == null ? new List<Team>() : teams;
        }

        public InMemoryTeamRepository(IList<Team> teams)
        {
            this.teams = teams;
        }

        public Team AddTeam(Team team)
        {
            if (teams.FirstOrDefault(t => t.Id == team.Id) != null)
            {
                return null;
            }
            teams.Add(team);
            return teams.Last();
        }

        public Team GetTeam(Guid id) => this.teams.SingleOrDefault(t => t.Id == id);

        public IList<Team> GetTeams() => teams;

        public Member AddMember(Guid teamId, Member member)
        {
            var team = this.teams.Single(t => t.Id == teamId);
            if (team.Members.SingleOrDefault(m => m.Id == member.Id) != null)
            {
                return null;
            }
            team.Members.Add(member);
            return member;
        }
    }
}
