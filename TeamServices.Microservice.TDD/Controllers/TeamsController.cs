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
            var result = repository.GetTeams();
            return result.Count == 0 ? NoContent() : (IActionResult)Ok(result);
        }

        public IActionResult Get(Guid id)
        {
            var result = repository.GetTeam(id);
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }

        public IActionResult Add(Team team)
        {
            var result = repository.AddTeam(team);
            return result == null ? BadRequest() : (IActionResult) Ok(result);
        }
    }
}
