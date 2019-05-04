using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TeamServices.Microservice.TDD.Domain.Models;

namespace TeamServices.Microservice.TDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController
    {
        public IList<Team> GetAll()
        {
            return new List<Team>
            {
                new Team("Team 1", new Guid()),
                new Team("Team 2", new Guid())
            };
        }
    }
}