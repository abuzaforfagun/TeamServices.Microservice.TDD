using LocationServices.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LocationServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        [Route("api/locations/{memberId}")]
        public IActionResult GetLatest(Guid memberId)
        {
            if (memberId == Guid.Empty)
            {
                return BadRequest();
            }

            var result = new List<LocationRecord>
            {
                new LocationRecord
                    { Altitude = 1, ID = Guid.NewGuid(), Latitude = 1, Longitude = 1, MemberID = Guid.NewGuid()}
            };
            return Ok(result);
        }
    }
}
