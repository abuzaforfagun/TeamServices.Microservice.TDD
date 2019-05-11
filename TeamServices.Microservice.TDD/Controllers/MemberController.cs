using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamServices.Microservice.TDD.Domain.Models;
using TeamServices.Microservice.TDD.Repository;

namespace TeamServices.Microservice.TDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ITeamRepository repository;

        public MemberController(ITeamRepository repository)
        {
            this.repository = repository;
        }
        [Route("api/team/{teamId}/")]
        public IActionResult Add(Guid teamId, Member member)
        {
            var team = repository.GetTeam(teamId);
            if (team == null)
            {
                return BadRequest();
            }

            var addedMember = repository.AddMember(teamId, member);
            return addedMember == null ? BadRequest() : (IActionResult) Ok(member);
        }
    }
}
