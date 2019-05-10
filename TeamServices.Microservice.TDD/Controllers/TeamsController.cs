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
            var result = repository.GetTeam(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(repository.GetTeam(id));
        }

        public IActionResult Add(Team team)
        {
            var result = this.repository.AddTeam(team);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
