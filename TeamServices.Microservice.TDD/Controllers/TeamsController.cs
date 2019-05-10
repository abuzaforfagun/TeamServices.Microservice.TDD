using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamServices.Microservice.TDD.Domain.Models;
using TeamServices.Microservice.TDD.Repository;

namespace TeamServices.Microservice.TDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        private readonly ITeamRepository repository;

        public TeamsController(ITeamRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult GetAll()
        {
            return Ok(repository.GetTeams());
        }

        public IActionResult Get(Guid id)
        {
            return Ok(repository.GetTeam(id));
        }

        public void Add(Team team)
        {
            this.repository.AddTeam(team);
        }
    }
}