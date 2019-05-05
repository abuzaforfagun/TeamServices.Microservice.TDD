using System;
using System.Collections.Generic;
using System.Text;
using TeamServices.Microservice.TDD.Domain.Models;

namespace TeamServices.Microservice.TDD.Repository
{
    public interface ITeamRepository
    {
        IList<Team> GetTeams();
        void AddTeam(Team team);
    }
}
