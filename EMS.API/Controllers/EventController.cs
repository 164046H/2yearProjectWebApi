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
        //method for create an event

        [Produces("application/json")]
        [HttpGet("getall/{id}")]
        public Event GetEventDetails(string id)
        {
            return _service.GetEventDetails(id);
         }
        //method for get details of a selected event


        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("registerForOneDayTrip")]
        public IActionResult RegisterForOneDayTrip([FromBody]OneDayTripRegistrant reg)
        {

            if (_service.RegisterForOneDayTrip(reg))
            {
            return Ok(reg);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }
        //add a registrant for single day trip

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("registerForTwoDayTrip")]
        public IActionResult RegisterForTwoDayTrip([FromBody]TwoDayTripRegistrants reg)
        {

            if (_service.RegisterForTwoDayTrip(reg))
            {

                return Ok(reg);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }
        //add a registrant for multiple day trip

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("v")]
        public IActionResult ViewUpComingEvents()
        {

            var res = _service.ViewUpComingEvents();

            try { return Ok(res); } catch { return BadRequest("error get departments!"); }
        }
        //get details of up coming events filter by startdate

    }
}
