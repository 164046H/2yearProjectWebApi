using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]

    public class EventController : Controller
    {
        private readonly EMSContext _context;
        private readonly EventServices _service;

        public EventController(EMSContext context)
        {
            _context = context;
            _service = new EventServices(_context);
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("createEvent")]
        public IActionResult CreateEvent([FromBody]Event even)
        {

            if (_service.AddEvent(even))
            {

                return Ok(even);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }

    }
}
