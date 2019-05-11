using System;
using System.Collections.Generic;
using TeamServices.Microservice.TDD.Domain.Models;

namespace TeamServices.Microservice.TDD.Repository
{
    public interface ITeamRepository
    {
        IList<Team> GetTeams();
        Team GetTeam(Guid id);
        Team AddTeam(Team team);
        Member AddMember(Guid teamId, Member member);
    }
}
